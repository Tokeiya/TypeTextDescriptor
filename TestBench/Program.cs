using System;
using System.IO;
using System.Linq.Expressions;

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
			string? hoge = null;
			Console.WriteLine(hoge);

			Expression<Func<Point, int>> expr = x => x.X + x.Y;
			using var vis = new TreeVisualizer(new StreamWriter("g:\\output.dot"), "hoge");

			vis.Visualize(expr);
		}

	}
}
