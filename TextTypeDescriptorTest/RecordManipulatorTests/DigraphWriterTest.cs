using System.IO;
using ChainingAssertion;
using RecordManipulator.Descriptor;
using Xunit;
using Xunit.Abstractions;

namespace TextTypeDescriptorTest.RecordManipulatorTests
{
	public class DigraphWriterTest
	{
		private readonly ITestOutputHelper _output;

		public DigraphWriterTest(ITestOutputHelper output) => _output = output;

		[Fact]
		public void InitialTest()
		{
			using var writer = new StringWriter();
			using var actual = new DigraphWriter("sample", writer);

			actual.Dispose();
			writer.Dispose();

			writer.GetStringBuilder().ToString().Is(File.ReadAllText("Expected/Simple.txt"));
		}

		[Fact]
		public void AddTest()
		{
			using var writer = new StringWriter();
			using var actual = new DigraphWriter("sample", writer);

			var a = new RecordNode(Direction.Horizontal);
			a.RootLabel.Add("first");
			a.RootLabel.Add("bar");

			var b = new RecordNode(Direction.Vertical);
			b.RootLabel.Add("hoge");
			b.RootLabel.Add("piyo");


			actual.WriteRecord(a);
			actual.WriteRecord(b);
			actual.WriteEdge(a, b);

			actual.Dispose();


			writer.GetStringBuilder().ToString().Is(File.ReadAllText("Expected/2Nodes.txt"));

		}


	}
}
