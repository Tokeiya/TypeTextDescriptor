using System;
using System.IO;
using System.Text;
using ChainingAssertion;
using RecordManipulator;
using RecordManipulator.Descriptor;
using Xunit;
using Xunit.Abstractions;

namespace TextTypeDescriptorTest.RecordManipulatorTests
{
	public class RecordNodeTests
	{
		private readonly ITestOutputHelper _output;


		public RecordNodeTests(ITestOutputHelper output) => _output = output;

		private static void Assert(RecordNode actual, string expectedRecord)
		{

			var buff=new StringBuilder();
			((IDescribable) actual).Describe(buff);

			buff.ToString().Is($"{actual.Identity} [label = \"{expectedRecord}\"];");

			buff.Clear();
			using var wtr = new StringWriter(buff);
			actual.Describe(wtr);

			buff.ToString().Is($"{actual.Identity} [label = \"{expectedRecord}\"];");

		}

		[Fact]
		public void CtorTest()
		{
			Xunit.Assert.Throws<ArgumentOutOfRangeException>(() => new RecordNode((Direction)10));
		}


		[Fact]
		public void InitialDirectionTest()
		{
			var actual = new RecordNode(Direction.Horizontal);
			actual.RootLabel.Add("horizontal");
			Assert(actual, "horizontal");

			actual = new RecordNode(Direction.Vertical);
			actual.RootLabel.Add("vertical");
			Assert(actual, "{vertical}");
		}

		[Fact]
		public void EmptyTest()
		{
			var actual = new RecordNode(Direction.Horizontal);
			Assert(actual, "");
		}

		[Fact]
		public void ComplexTest()
		{
			var actual = new RecordNode(Direction.Vertical);
			actual.RootLabel.Add("top");
			var tmp = actual.RootLabel.Add();
			tmp.Add("nestedA");
			tmp.Add("nestedB");

			tmp = actual.RootLabel.Add();
			tmp.Add("nestedC");
			tmp.Add("nestedD");

			Assert(actual, "{top|{nestedA|nestedB}|{nestedC|nestedD}}");




		}

	}
}
