#pragma once
#include <future>
#include <stdexcept>
#include <vector>
#include <queue>
#include <atomic>
using Task = std::function<void()>;

#define MAX_THREADPOOL_NUM 10

class ThreadPool {
private:
	std::vector<std::thread> threads;
	std::queue<Task> tasks;
	std::mutex mx;
	std::condition_variable taskCondition;
	std::atomic<bool> running{ true };
	std::atomic<int>  idleCount{ 0 };

	void AddThread(unsigned short count) {
		for (; threads.size() < MAX_THREADPOOL_NUM && count > 0; --count)
		{
			threads.emplace_back([this] {
				while (running)
				{
					Task task; // ��ȡһ����ִ�е� task
					{
						// unique_lock ��� lock_guard �ĺô��ǣ�������ʱ unlock() �� lock()
						std::unique_lock<std::mutex> lock{ mx };
						taskCondition.wait(lock, [this] {
							return !running || !tasks.empty();
						}); // wait ֱ���� task
						if (!running && tasks.empty())
							return;
						task = std::move(tasks.front()); // ���Ƚ��ȳ��Ӷ���ȡһ�� task
						tasks.pop();
					}
					idleCount--;
					task();//ִ������
					idleCount++;
				}
			});
			idleCount++;
		}
	};

public:
	inline ThreadPool(unsigned short size = 4) {
		AddThread(size);
	};

	inline ~ThreadPool() {
		running = false;
		taskCondition.notify_all(); // ���������߳�ִ��
		for (std::thread& thread : threads) {
			if (thread.joinable())
				thread.join(); // �ȴ���������� ǰ�᣺�߳�һ����ִ����
		}
	};

	template<class F, class... Args>
	auto Commit(F&& f, Args&&... args)->std::future<decltype(f(args...))> {
		if (!running)
			throw std::runtime_error("committing ThreadPool is stopped.");

		using RetType = decltype(f(args...));
		auto task = std::make_shared<std::packaged_task<RetType()>>(std::bind(std::forward<F>(f), std::forward<Args>(args)...)); // �Ѻ�����ڼ�����,���(��)
		std::future<RetType> future = task->get_future();
		{
			std::lock_guard<std::mutex> lock{ mx };
			tasks.emplace([task]() {
				(*task)();
			});
		}
		if (idleCount < 1 && threads.size() < MAX_THREADPOOL_NUM)
			AddThread(1);
		taskCondition.notify_one(); // ����һ���߳�ִ��

		return future;
	};

	size_t IdleCount() { return idleCount; };
	size_t Size() { return threads.size(); };
	void Stop() { running = false; };
	bool IsStopped() { return !running; };
};
