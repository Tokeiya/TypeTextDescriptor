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
		private ParameterExpression _topLevelParameter;
		private bool _isSimple;

		bool IsSimple(Expression expression) => expression switch
		{
			BinaryExpression _ => true,
			UnaryExpression _ => true,
			MethodCallExpression _ => true,
			MemberExpression _ => true,
			ConstantExpression _ => true,
			_ => false
		};

		

		public string ExtractName<T>(Expression<Func<T,object>> expression,string ifComplex="Complex")
		{
			_buffer.Clear();
			_topLevelParameter = expression.Parameters[0];
			_isSimple = true;

			Visit(expression.Body);

			if (_isSimple) return ifComplex;
			return _buffer.ToString();
		}

		public override Expression Visit(Expression node)
		{
			_isSimple &= IsSimple(node);
			return base.Visit(node);
		}

		protected override Expression VisitBinary(BinaryExpression node)
		{

#warning VisitBinary_Is_NotImpl
			throw new NotImplementedException("VisitBinary is not implemented");

			return base.VisitBinary(node);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
#warning VisitMethodCall_Is_NotImpl
			throw new NotImplementedException("VisitMethodCall is not implemented");

			return base.VisitMethodCall(node);
		}

		protected override Expression VisitMember(MemberExpression node)
		{
#warning VisitMember_Is_NotImpl
			throw new NotImplementedException("VisitMember is not implemented");

			return base.VisitMember(node);
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
#warning VisitUnary_Is_NotImpl
			throw new NotImplementedException("VisitUnary is not implemented");
			return base.VisitUnary(node);


		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
#warning VisitConstant_Is_NotImpl
			throw new NotImplementedException("VisitConstant is not implemented");
			return base.VisitConstant(node);

		}


	}
}
