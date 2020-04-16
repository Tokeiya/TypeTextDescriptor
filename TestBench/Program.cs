using Microsoft.Extensions.ObjectPool;
using ParsecSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using static ParsecSharp.Parser;
using static ParsecSharp.Text;
using Console = System.Console;

namespace TestBench
{

	public class FixedPoint<TToken,T>
	{
		private Option<Parser<TToken, T>> _parser;

		public void SetParser(Parser<TToken, T> parser)
		{
			if (_parser.HasValue) throw new InvalidOperationException("Parser already exist.");
			_parser = Option.Some<Parser<TToken, T>>(parser);
		}

		public Parser<TToken, T> Parser
		{
			get
			{
				if (!_parser.HasValue) throw new InvalidOperationException("Parser not exists.");
				return _parser.Value;
			}
		}
	}

	static class Helper
	{
		private static readonly ObjectPool<StringBuilder> Pool =
			ObjectPool.Create(new StringBuilderPooledObjectPolicy());

		public static string GetString(this IEnumerable<char> source)
		{
			var bld = Pool.Get();
			try
			{
				foreach (var c in source) bld.Append(c);

				return bld.ToString();
			}
			finally
			{
				bld.Clear();
				Pool.Return(bld);
			}
		}

		public static string GetString(params IEnumerable<char>[] source)
		{
			var bld = Pool.Get();

			try
			{
				foreach (var elem in source)
				{
					foreach (var c in elem)
					{
						bld.Append(c);
					}
				}

				return bld.ToString();

			}
			finally
			{
				bld.Clear();
				Pool.Return(bld);
			}
		}


		public static int GetInteger(this IEnumerable<char> source) => int.Parse(source.GetString());

		public static int GetSignedInteger(int i, Option<char> sign)
		{
			if (sign.HasValue)
			{
				switch (sign.Value)
				{
					case '+':
						return i;

					case '-':
						return -i;

					default:
						throw new Exception();
				}
			}

			return i;
		}

		public static void Dump(this Parser<char, string> parser, string source)
			=> Console.WriteLine(parser.Parse(source).Value);

		public static string GetString(this IEnumerable<string> source)
		{
			var bld = new StringBuilder();

			foreach (var elem in source)
			{
				Console.WriteLine(elem);
				bld.Append(elem);
			}

			Console.WriteLine();
			return bld.ToString();
		}

	}


	class Program
	{
		
		
		static void Main(string[] args)
		{
			var numberExpr = Many1(DecDigit()).Select(x => x.GetString());

			var exprExpr = new FixedPoint<char, string>();

			var tmp = from _ in Char('(')
				from expr in exprExpr.Parser
				from __ in Char(')').Ignore()
				select $"({expr})";

			var primaryExpr = Choice(numberExpr, tmp);

			tmp = from op in OneOf("*/")
				from p in primaryExpr
				select $"{op}{p}";

			var multitiveExpr = from first in primaryExpr
				from following in Many(tmp).Select(x => x.GetString())
				select $"{first}{following}";

			var piyo = from op in OneOf("+-")
				from m in multitiveExpr
				select $"{op}{m}";

			var additiveExpr = from first in multitiveExpr
				from following in Parser.Many(piyo).Select(x => x.GetString())
				select $"{first}{following}";

			exprExpr.SetParser(additiveExpr);

			var hoge = from s in exprExpr.Parser
				from _ in Text.EndOfInput()
				select s;
			
			
			

			hoge.Dump("((10+100)*100)");
		}

	}
}
