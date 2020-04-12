using System;
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
			//X+Y
			Expression<Func<Point,int>> expr = (p) => Math.Abs(p.X + p.Y);

			

			var hoge = new SampleWalker();

			hoge.Visit(expr);
		}
	}
}
