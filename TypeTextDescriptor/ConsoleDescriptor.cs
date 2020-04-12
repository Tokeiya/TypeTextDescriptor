using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tokeiya3.TypeTextDescriptor
{
	public static class ConsoleDescriptor
	{
		public static void Describe<T>(this T value,string nullSurrogation="NULL",int indent=2)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this T value,string nullSurrogation="NULL",int indent=2,
			params Expression<Func<T,object>>[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this T value,string nullSurrogateion="NULL",int indent=2,
			params (Func<T,object> selector,string title)[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value, string nullSurrogation = "NULL",int indent=2
			,bool pause=false)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value, string nullSurrogation = "NULL", bool pause=false,
			int indent=2,params Expression<Func<T,object>>[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value,string nullSurrogation="NULL",bool pause=false,
			int indent=2,params (Func<T,object> selector,string title)[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}
	}
}
