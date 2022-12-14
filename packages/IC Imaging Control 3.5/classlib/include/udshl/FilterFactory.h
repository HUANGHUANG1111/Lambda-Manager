
#ifndef _FILTERFACTORY_H_INC_
#define _FILTERFACTORY_H_INC_

#include "libbasedefs.h"
#include "smart_ptr.h"

#include "FilterDll.h"
#include "FrameFilterImpl.h"

namespace _DSHOWLIB_NAMESPACE
{

	/**
	 *	Default implementation of IFilterFactory.
	 *	You should _almost_ never have to write your own.
	 *
	 *	You should return a pointer to an instance of this class from <link>getFilterFactory</link>
	 *	inside your filter's DLL.
	 *
	 *	To register a filter class at this factory, call <link>registerFilter</link>.
	 *
	 */
	class CFilterFactory
		:	public IFilterFactory
	{
	private:
		template<class T>
		void call_getfilterinfo( FilterInfo& fi )
		{
			FilterInfo temp = T::getStaticFilterInfo();
			fi = temp;
		}
	public:
		/**
		 *	Registers a frame filter class in this factory.
		 *	Usage:
		 *		factory.registerFilter( (FilterClass*)0 );
		 *
		 */
		template<class T>
		void	registerFilter( T* /*pFilter*/ )
		{
			// Forward call to clean function trying to avoid x64 2010 optimization bug
			FilterInfo fi;
			call_getfilterinfo<T>( fi );

			m_registeredFilters[fi.name] = new FilterItem<T>;
		}
	protected:
		virtual bool enumFilters( unsigned int index, FilterInfo* pFilterInfo )
		{
			assert( pFilterInfo	);
			if( index < 0 || index >= (int) m_registeredFilters.size() )
				return false;

			tFilterMap::const_iterator it = m_registeredFilters.begin(); 
			std::advance( it, index );

			it->second->getFilterInfo( *pFilterInfo );

			return true;
		}

		virtual IFrameFilter* createFilter( const wchar_t* name )
		{
			tFilterMap::iterator it = m_registeredFilters.find( name );
			if( it != m_registeredFilters.end() )
			{
				return it->second->create();
			}
			else
			{
				return 0;
			}
		}

		virtual int	getVersion()
		{
			return FILTER_INTERFACE_VERSION;
		}
	private:
		struct FilterItemBase
		{
			virtual ~FilterItemBase() {}
			virtual IFrameFilter*	create() const = 0;
			virtual void			getFilterInfo( FilterInfo& info ) const = 0;
		};

		typedef std::map<std::wstring, smart_ptr<FilterItemBase> >	tFilterMap;

		template<class T>
		struct FilterItem :	FilterItemBase
		{
			virtual IFrameFilter*	create() const
			{
				return new T;
			}
			virtual void			getFilterInfo( FilterInfo& info ) const
			{
				info = T::getStaticFilterInfo();
			}
		};

		tFilterMap		m_registeredFilters;
	};
}

#endif
