using System;
using System.IO;
using System.Linq.Expressions;
using RecordFormatter;

namespace TestBench
{

	class Point
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			var writer=new StringWriter();
			using var digraph = new DigraphWriter("sample", new StreamWriter("G:\\output.dot"));

			var a = new RecordNode(Direction.Horizontal);
			a.RootLabel.Add("a");
			a.RootLabel.Add("b");


			var b=new RecordNode(Direction.Vertical);
			b.RootLabel.Add("c");
			b.RootLabel.Add("d");

			digraph.WriteEdge(a, b);
			digraph.WriteRecord(a);
			digraph.WriteRecord(b);


		}
	}
}
