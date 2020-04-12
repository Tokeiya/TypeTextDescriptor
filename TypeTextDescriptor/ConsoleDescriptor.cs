using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Tokeiya3.TypeTextDescriptor
{
	public static class ConsoleDescriptor
	{
		public static void Describe<T>(this T value,string nullSurrogation="NULL")
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this T value,string nullSurrogation="NULL",
			params Expression<Func<T,string>>[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this T value,string nullSurrogateion="NULL",
			params (Func<T,string> selector,string title)[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value, string nullSurrogation = "NULL",bool pause=false)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value, string nullSurrogation = "NULL", bool pause=false,
			params Expression<Func<T,string>>[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}

		public static void Describe<T>(this IEnumerable<T> value,string nullSurrogation="NULL",bool pause=false,
			params (Func<T,string> selector,string title)[] presenter)
		{
#warning NotImplemented
			throw new NotImplementedException();
		}
	}
}
