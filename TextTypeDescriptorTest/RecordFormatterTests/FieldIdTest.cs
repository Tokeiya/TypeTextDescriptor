using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using static Xunit.Assert;
using ChainingAssertion;
using RecordFormatter;


namespace TextTypeDescriptorTest.RecordFormatterTests
{
	public class FieldIdTest
	{
		private readonly ITestOutputHelper _output;

		public FieldIdTest(ITestOutputHelper output) => _output = output;



		[Fact]
		public void Add()
		{
			var actual = new FieldId("id", ImaginaryRoot.Root);

			Throws<NotSupportedException>(() => actual.Add());
			Throws<NotSupportedException>(() => actual.Add("id"));
		}

		[Fact]
		public void GetParentTest()
		{
			var actual = new FieldId("id", ImaginaryRoot.Root);
			actual.Parent.Is(ImaginaryRoot.Root);
		}

		void Assert(FieldId actual, string expected)
		{

			var bld = new StringBuilder();
			actual.ToRecord(bld);
			_output.WriteLine(bld.ToString());
			bld.ToString().Is($"\"{expected}\"");
		}


		[Fact]
		public void ToRecordTest()
		{ 

			var actual=new FieldId("id",ImaginaryRoot.Root);
			Assert(actual, "id");

			actual = new FieldId("hoge\rpiyo", ImaginaryRoot.Root);
			Assert(actual, "hoge\\rpiyo");

			actual=new FieldId("hoge\npiyo",ImaginaryRoot.Root);
			Assert(actual,"hoge\\npiyo");

			actual = new FieldId("hoge\r\npiyo", ImaginaryRoot.Root);
			Assert(actual, "hoge\\r\\npiyo");

			actual = new FieldId("\"", ImaginaryRoot.Root);
			Assert(actual, "\\\"");

			actual = new FieldId("{", ImaginaryRoot.Root);
			Assert(actual, "\\{");





		}



	}
}
