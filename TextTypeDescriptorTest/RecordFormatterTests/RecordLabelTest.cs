using System.Buffers;
using System.IO;
using ChainingAssertion;
using System.Text;
using RecordManipulator.Descriptor;
using Xunit;
using Xunit.Abstractions;
using static RecordManipulator.Descriptor.ImaginaryRoot;


namespace TextTypeDescriptorTest.RecordFormatterTests
{
	public class RecordLabelTest
	{
		private readonly ITestOutputHelper _output;

		public RecordLabelTest(ITestOutputHelper output) => _output = output;

		static void Assert(RecordLabel actual, string expected)
		{
			var bld = new StringBuilder();
			((IDescribable) actual).Describe(bld);

			bld.ToString().Is(expected);

			bld.Clear();
			using var wtr = new StringWriter(bld);
			actual.Describe(wtr);





		}

		[Fact]
		public void InitTest()
		{
			var actual = new RecordLabel(Root);
			Assert(actual, "{}");

			actual = new RecordLabel(Root, false);
			Assert(actual, "");

			actual = new RecordLabel(Root, true);
			Assert(actual, "{}");
		}

		[Fact]
		public void AddFieldIdTest()
		{
			var actual = new RecordLabel(Root, false);
			actual.Add("hoge");
			actual.Add("piyo");

			Assert(actual, "hoge|piyo");

			actual = new RecordLabel(Root, false);
			actual.Add("single");
			Assert(actual, "single");
		}

		[Fact]
		public void AddRecordTest()
		{
			var actual = new RecordLabel(Root, false);
			var tmp = actual.Add();
			tmp.Add("nested");
			tmp.Add("foo");

			Assert(actual, "{nested|foo}");

			actual = new RecordLabel(Root, false);
			tmp = actual.Add();
			tmp.Add("single");

			Assert(actual, "{single}");

		}

		[Fact]
		public void AddComplexTest()
		{
			var actual = new RecordLabel(Root, false);
			actual.Add("parent");

			var tmp = actual.Add();
			tmp.Add("nested");

			Assert(actual, "parent|{nested}");

			actual = new RecordLabel(Root);
			actual.Add("parent");

			tmp = actual.Add();
			tmp.Add("nested");

			Assert(actual, "{parent|{nested}}");







			actual = new RecordLabel(Root, false);
			actual.Add("first");
			tmp = actual.Add();
			actual.Add("third");

			tmp.Add("nested_first");
			tmp.Add("nested_second");


			Assert(actual, "first|{nested_first|nested_second}|third");

			actual = new RecordLabel(Root);
			actual.Add("first");
			tmp = actual.Add();
			actual.Add("third");

			tmp.Add("nested_first");
			tmp.Add("nested_second");


			Assert(actual, "{first|{nested_first|nested_second}|third}");
		}

		[Fact]
		public void EmptyElementTest()
		{
			var actual = new RecordLabel(Root, false);
			Assert(actual, "");

			actual.Add(string.Empty);
			actual.Add(string.Empty);
			Assert(actual, "|");

			var tmp = actual.Add();

			Assert(actual, "||{}");


			actual = new RecordLabel(Root, true);
			Assert(actual, "{}");
			actual.Add(string.Empty);
			actual.Add(string.Empty);
			Assert(actual, "{|}");

			actual.Add();
			Assert(actual, "{||{}}");





		}







	}
}
