using System;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using static Xunit.Assert;
using ChainingAssertion;
using RecordFormatter;


namespace TextTypeDescriptorTest.RecordFormatterTests
{
	using static Dummy;
	class Dummy : IRecordLabel
	{
		public static IRecordLabel Instance { get; } = new Dummy();

		private Dummy()
		{

		}
		public void Add(string fieldId)
		{
			throw new NotImplementedException();
		}

		public IRecordLabel Add()
		{
			throw new NotImplementedException();
		}

		public IRecordLabel Parent { get; }
		public void ToRecord(StringBuilder buffer)
		{
			throw new NotImplementedException();
		}
	}

	public class FieldIdTest
	{
		private readonly ITestOutputHelper _output;
		public FieldIdTest(ITestOutputHelper output) => _output = output;


		[Fact]
		public void CtorTest()
		{
			Throws<ArgumentException>(() => new FieldId("", ImaginaryRoot.Root));
		}


		[Fact]
		public void Add()
		{
			var actual = new FieldId("id", Instance);

			Throws<NotSupportedException>(() => actual.Add());
			Throws<NotSupportedException>(() => actual.Add("id"));
		}

		[Fact]
		public void GetParentTest()
		{
			var actual = new FieldId("id", Instance);
			actual.Parent.Is(Instance);
		}

		void Assert(FieldId actual, string expected)
		{

			var bld = new StringBuilder();
			actual.ToRecord(bld);
			_output.WriteLine(bld.ToString());
			bld.ToString().Is(expected);
		}


		[Fact]
		public void ToRecordTest()
		{ 

			var actual=new FieldId("id",Instance);
			Assert(actual, "id");

			actual = new FieldId("hoge\rpiyo", Instance);
			Assert(actual, "hoge\\rpiyo");

			actual=new FieldId("hoge\npiyo",Instance);
			Assert(actual,"hoge\\npiyo");

			actual = new FieldId("hoge\r\npiyo", Instance);
			Assert(actual, "hoge\\r\\npiyo");

			actual = new FieldId("\"", Instance);
			Assert(actual, "\\\"");

			actual = new FieldId("{}", Instance);
			Assert(actual, "\\{\\}");

			actual = new FieldId("<>|", Instance);
			Assert(actual, "\\<\\>\\|");
		}


		[Fact]
		public void EmptyTest()
		{
			var actual = new FieldId(string.Empty, Instance);
			Assert(actual, string.Empty);
		}





	}
}
