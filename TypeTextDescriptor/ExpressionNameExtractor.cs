using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.Extensions.ObjectPool;

namespace Tokeiya3.TypeTextDescriptor
{
	internal static class ExpressionNameExtractor
	{
		private static readonly ObjectPool<ExpressionTreeWalker> Pool = ObjectPool.Create<ExpressionTreeWalker>();

		public static string ExtractName<T>(Expression<Func<T, object>> expression)
		{
			ExpressionTreeWalker walker = default;
			try
			{
				walker = Pool.Get();
				return walker.ExtractName(expression);
			}
			finally
			{
				if (walker != null) Pool.Return(walker);
			}
		}

	}
}
