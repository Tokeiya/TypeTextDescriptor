using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.Extensions.ObjectPool;

namespace Tokeiya3.TypeTextDescriptor
{
	internal class ExpressionTreeWalker:ExpressionVisitor
	{
		private readonly StringBuilder _buffer = new StringBuilder();

		public string ExtractName(LambdaExpression expression)
		{
			_buffer.Clear();


#warning NotImplemented
			throw new NotImplementedException();

		}

		public override Expression Visit(Expression node)
		{
			return base.Visit(node);
		}

		protected override Expression VisitBinary(BinaryExpression node)
		{
		
			return base.VisitBinary(node);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			return base.VisitMethodCall(node);
		}

		protected override Expression VisitMember(MemberExpression node)
		{

			return base.VisitMember(node);
		}
	}
}
