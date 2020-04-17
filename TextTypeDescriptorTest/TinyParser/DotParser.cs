using ParsecSharp;
using static ParsecSharp.Text;
using static ParsecSharp.Parser;

namespace TextTypeDescriptorTest.TinyParser
{
	static class DotParser
	{
		public static Parser<char,Id> IdExpr{ get; }
		public static Parser<char,AttributeStatement> AttributeStatementExpr { get; }
		public static Parser<char, NodeStatement> NodeExpr { get; }
		public static Parser<char,EdgeStatement> EdgeExpr { get; }
		

	}
}