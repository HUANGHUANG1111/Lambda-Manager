using LambdaUtils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lambda;

public class LambdaControl : Control
{
	private static event LogHandler? LogHandler;

	private static event LogHandler? LogHandler2;

	private static event AddEventHandler? AddEventHandler;

	private static event CallEventHandler? CallEventHandler;

	private static event RegisterImageViewHandler? RegisterImageViewHandler;

	private static View[]? Views { get; set; }

	//保留原先的写法，记忆错乱，lambda.dll 并未做出正确的更改
	public static void Initialize(LogHandler logHandler, LogHandler logHandler2, AddEventHandler addEventHandler, CallEventHandler callEventHandler, RegisterImageViewHandler registerImageViewHandler, View[] views)
	{
		//LogHandler = logHandler;
		//LogHandler2 = logHandler2;
		//AddEventHandler = addEventHandler;
		//CallEventHandler = callEventHandler;
		//RegisterImageViewHandler = registerImageViewHandler;
		//Views = views;

        if (logHandler != null)
            LogHandler = (LogHandler)Delegate.Combine(LogHandler, logHandler);

        if (logHandler2 != null)
            LogHandler2 = (LogHandler)Delegate.Combine(LogHandler2, logHandler2);

        if (addEventHandler != null)
            AddEventHandler = (AddEventHandler)Delegate.Combine(AddEventHandler, addEventHandler);

        if (callEventHandler != null)
            CallEventHandler = (CallEventHandler)Delegate.Combine(CallEventHandler, callEventHandler);

        if (registerImageViewHandler != null)
            RegisterImageViewHandler = (RegisterImageViewHandler)Delegate.Combine(RegisterImageViewHandler, registerImageViewHandler);

        if (views != null)
            Views = views;

    }

    public static void Log(Message message)
	{
		LogHandler?.Invoke(message);
	}

	public static void Log2(Message message)
	{
		LogHandler2?.Invoke(message);
	}

	public void Trigger(string type, Dictionary<string, object>? json)
	{
		CallEventHandler?.Invoke(type, this, new LambdaArgs
		{
			Data = json
		});
	}

	public  async void Dispatch(string type, Dictionary<string, object>? json)
	{
		string type2 = type;
		Dictionary<string, object> json2 = json;
		await Task.Run(() => CallEventHandler?.Invoke(type2, this, new LambdaArgs
		{
			Data = json2
		}));
	}

	public void Trigger(string type, string? json)
	{
		CallEventHandler?.Invoke(type, this, new LambdaArgs
		{
			Data = json
		});
	}

	public async void Dispatch(string type, string? json)
	{
		string type2 = type;
		string json2 = json;
		await Task.Run(() => CallEventHandler?.Invoke(type2, this, new LambdaArgs
		{
			Data = json2
		}));
	}

	public void Trigger(string type, EventArgs e)
	{
		CallEventHandler?.Invoke(type, this, e);
	}

	public async void Dispatch(string type, EventArgs e)
	{
		string type2 = type;
		EventArgs e2 = e;
		await Task.Run(() => CallEventHandler?.Invoke(type2, this, e2));
	}

	public static void Trigger(string type, object sender, Dictionary<string, object>? json)
	{
        if (json != null)
        {
            Log(new Message { Severity = Severity.INFO, Text = type + JSON.Stringify(json) });
        }
        else
        {
            Log(new Message { Severity = Severity.INFO, Text = type });
        }
        CallEventHandler?.Invoke(type, sender, new LambdaArgs
		{
			Data = json
		});
    }

	public static void Trigger(string type, object sender, Array? array)
	{
		CallEventHandler?.Invoke(type, sender, new LambdaArgs
		{
			Data = array
		});
	}

	public static async void Dispatch(string type, object sender, Dictionary<string, object>? json)
	{
		string type2 = type;
		object sender2 = sender;
		Dictionary<string, object> json2 = json;
		await Task.Run(() => CallEventHandler?.Invoke(type2, sender2, new LambdaArgs
		{
			Data = json2
		}));
	}

	public static void Trigger(string type, object sender, string? json)
	{
        Log(new Message { Severity = Severity.INFO, Text = type + json });
        CallEventHandler?.Invoke(type, sender, new LambdaArgs
		{
			Data = json
		});


    }

	public static async void Dispatch(string type, object sender, string? json)
	{
		string type2 = type;
		object sender2 = sender;
		string json2 = json;
		await Task.Run(() => CallEventHandler?.Invoke(type2, sender2, new LambdaArgs
		{
			Data = json2
		}));
	}

	public static void Trigger(string type, object sender, EventArgs e)
	{
		CallEventHandler?.Invoke(type, sender, e);
        Log(new Message { Severity = Severity.INFO, Text = type });
    }

    public static async void Dispatch(string type, object sender, EventArgs e)
	{
		string type2 = type;
		object sender2 = sender;
		EventArgs e2 = e;
		await Task.Run(() => CallEventHandler?.Invoke(type2, sender2, e2));
	}

	public static void AddLambdaEventHandler(string type, LambdaHandler handler, bool once)
	{
		AddEventHandler?.Invoke(type, handler, once);
	}

	public static View GetImageView(int index)
	{
		if (Views == null)
		{
			throw new Exception("error!");
		}
		return Views[index];
	}

	public static int RegisterImageView(Image image)
	{
		return RegisterImageViewHandler?.Invoke(image) ?? 0;
	}
}
