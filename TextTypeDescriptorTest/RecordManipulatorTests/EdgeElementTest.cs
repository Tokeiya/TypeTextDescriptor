using System.IO;
using System.Text;
using ChainingAssertion;
using RecordManipulator;
using RecordManipulator.Descriptor;
using Xunit;
using Xunit.Abstractions;

namespace TextTypeDescriptorTest.RecordManipulatorTests
{
	public class EdgeElementTest
	{
		private readonly ITestOutputHelper _output;

		public EdgeElementTest(ITestOutputHelper output) => _output = output;

		static void Check(EdgeElement actual, string expected)
		{
			var act = actual as IDescribable;
			act.IsNotNull();
			
			var bld=new StringBuilder();
			act.Describe(bld);
			bld.ToString().Is(expected+"\r\n");
			bld.Clear();
			
			using var wtr=new StringWriter(bld);
			act.Describe(wtr);
			bld.ToString().Is(expected+"\r\n");
		}
		
		
		[Fact]
		public void InitTest()
		{
			var actual = new EdgeElement(42, 114514, "hoge");
			actual.From.Is(42);
			actual.To.Is(114514);
			actual.Label.Is("hoge");
			
			Check(actual,"42 -> 114514 [label=\"hoge\"];");
		}
		
		

	}
}