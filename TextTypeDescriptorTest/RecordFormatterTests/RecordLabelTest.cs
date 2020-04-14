using System.Text;
using RecordFormatter;
using Xunit;
using Xunit.Abstractions;
using static RecordFormatter.ImaginaryRoot;
using ChainingAssertion;


namespace TextTypeDescriptorTest.RecordFormatterTests
{
	public class RecordLabelTest
	{
		private readonly ITestOutputHelper _output;

		public RecordLabelTest(ITestOutputHelper output) => _output = output;

		static void Assert(RecordLabel actual, string expected)
		{
			var bld = new StringBuilder();
			actual.ToRecord(bld);

			bld.ToString().Is($"\"{expected}\"");
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






	}
}
