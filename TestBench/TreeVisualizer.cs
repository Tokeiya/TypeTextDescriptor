#nullable enable
using RecordFormatter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace TestBench
{
	public class TreeVisualizer : ExpressionVisitor, IDisposable
	{

		private readonly DigraphWriter _writer;
		private Stack<RecordNode> _parent = new Stack<RecordNode>();


		public TreeVisualizer(TextWriter writer, string name)
		{
			_writer = new DigraphWriter(name, writer);
		}

		public void Visualize<T>(Expression<T> node)
		{

			VisitLambda(node);
		}

		void WriteEdge(RecordNode node)
		{
			_writer.WriteRecord(node);
			if (_parent.Count != 0) _writer.WriteEdge(_parent.Peek(), node);

		}


		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			var record = new RecordNode(Direction.Vertical);
			record.RootLabel.Add("Lambda");
			WriteEdge(record);
			_parent.Push(record);
			var ret = base.VisitLambda(node);
			_parent.Pop();

			return ret;
		}

		string GetOperator(ExpressionType type) => type switch
		{
			ExpressionType.Add => "+",
			ExpressionType.AddChecked => "+",
			ExpressionType.Divide => "/",
			ExpressionType.Modulo => "%",
			ExpressionType.Multiply => "*",
			ExpressionType.MultiplyAssignChecked => "*",
			ExpressionType.Power => "Pow",
			ExpressionType.Subtract => "-",
			ExpressionType.SubtractChecked => "-",
			ExpressionType.And => "&",
			ExpressionType.Or => "|",
			ExpressionType.AndAlso => "&&",
			ExpressionType.OrElse => "||",
			ExpressionType.Equal => "==",
			ExpressionType.NotEqual => "!=",
			ExpressionType.GreaterThanOrEqual => ">=",
			ExpressionType.GreaterThan => ">",
			ExpressionType.LessThan => "<",
			ExpressionType.LessThanOrEqual => "<=",
			ExpressionType.Coalesce => "??",
			ExpressionType.ArrayIndex => "idx",
			ExpressionType.ArrayLength => "len",
			ExpressionType.Convert => "Conv",
			ExpressionType.ConvertChecked => "ConvChk",
			ExpressionType.Negate => "UnaryNeg",
			ExpressionType.NegateChecked => "UnaryNegChk",
			ExpressionType.Not => "!",
			ExpressionType.UnaryPlus => "UnaryPlus",
			_ => throw new InvalidOperationException()
		};


		protected override Expression VisitBinary(BinaryExpression node)
		{
			var record = new RecordNode(Direction.Vertical);
			record.RootLabel.Add("binary");
			record.RootLabel.Add($"Operator:{GetOperator(node.NodeType)}");


			WriteEdge(record);

			_parent.Push(record);
			var ret = base.VisitBinary(node);

			_parent.Pop();
			return ret;
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			var record = new RecordNode(Direction.Vertical);
			record.RootLabel.Add("Constant");
			record.RootLabel.Add($"Type:{node.Type.Name}");
			record.RootLabel.Add($"Value:{node.Value}");

			WriteEdge(record);
			_parent.Push(record);

			var ret = base.VisitConstant(node);

			_parent.Pop();
			return ret;
		}


		protected override Expression VisitUnary(UnaryExpression node)
		{
			var rec = new RecordNode(Direction.Vertical);
			rec.RootLabel.Add("Unary");
			rec.RootLabel.Add($"Op:{GetOperator(node.NodeType)}");

			WriteEdge(rec);
			_parent.Push(rec);

			var ret = base.VisitUnary(node);

			_parent.Pop();
			return ret;
		}

		protected override Expression VisitParameter(ParameterExpression node)
		{

			var record = new RecordNode(Direction.Vertical);
			record.RootLabel.Add("Parameter");
			record.RootLabel.Add($"Type:{node.Type.Name}");
			record.RootLabel.Add($"Name:{node.Name}");

			WriteEdge(record);
			_parent.Push(record);
			var ret = base.VisitParameter(node);
			_parent.Pop();
			return ret;
		}


		protected override Expression VisitMember(MemberExpression node)
		{
			var rec = new RecordNode(Direction.Vertical);
			rec.RootLabel.Add("MemberAccess");
			rec.RootLabel.Add($"Name:{node.Member.Name}");

			WriteEdge(rec);
			_parent.Push(rec);


			var ret = base.VisitMember(node);

			_parent.Pop();
			return ret;
		}


		public void Dispose()
		{

			_writer.Dispose();
		}
	}
}
