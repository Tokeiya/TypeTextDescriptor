using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace TestBench
{
	class SampleWalker : ExpressionVisitor
	{
		private int indent = 0;

		void Enter(string name)
		{
			for (int i = 0; i < indent; i++) Console.Write(' ');
			Console.WriteLine($"Enter:{name}");
			indent += 2;
		}

		void Exit(string name)
		{
			indent -= 2;
			for (int i = 0; i < indent; i++) Console.Write(' ');
			Console.WriteLine($"Exit:{name}");
		}


		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			Enter($"Method:{node.Method.Name}");
			var ret= base.VisitMethodCall(node);
			Exit($"Exit:{node.Method.Name}");
			return ret;
		}

		public override Expression Visit(Expression node)
		{
			Enter("Expression");
			var ret = base.Visit(node);
			Exit("Expression");
			return ret;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{
			Enter($"Parameter:{node.Name}");
			var ret = base.VisitParameter(node);
			Exit($"Parameter:{node.Name}");

			return ret;
		}



		protected override Expression VisitBinary(BinaryExpression node)
		{
			Enter("Binary");
			var ret = base.VisitBinary(node);
			Exit("Binary");

			return ret;
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			Enter("Constant");
			var ret = base.VisitConstant(node);
			Exit("Constant");
			return ret;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			Enter($"Member:{node.Member.Name}");
			var ret= base.VisitMember(node);
			Exit($"Member:{node.Member.Name}");

			return ret;
		}

		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			Enter("Lambda");
			var ret= base.VisitLambda(node);
			Exit("Lambda");
			return ret;
		}
	}

}
