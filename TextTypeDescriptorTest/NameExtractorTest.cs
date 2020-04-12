using System;
using System.Linq.Expressions;
using ChainingAssertion;
using Tokeiya3.TypeTextDescriptor;
using Xunit;
using Xunit.Abstractions;

namespace TextTypeDescriptorTest
{
	using expression=Expression<Func<SampleClass,object>>;
	using static ExpressionNameExtractor;

	class SampleClass
	{
		public int Field;
		public int Property { get; set; }

		public int Method(int i) => Field + Property + i;
	}

	public class NameExtractorTest
	{
		private readonly ITestOutputHelper _output;
		public NameExtractorTest(ITestOutputHelper output) => _output = output;

		static void Assert(expression actual, string expected) => ExtractName(actual).Is(expected);


		[Fact]
		public void BinaryOperationTest()
		{
			Assert(x => x.Property + x.Field, "Property+Field");
			Assert(x => x.Field - x.Property, "Field-Property");
			Assert(x => x.Field * x.Property, "Field*Property");
			Assert(x => x.Property / 10, "Property/10");
		}

		[Fact]
		public void ComplexOperatorTest()
		{
			Assert(x => x.Property * x.Field + 42, "Property*Field+42");
			Assert(x => x.Property * (x.Field + 42), "Property*(Field+42)");
		}

		[Fact]
		public void MethodCallTest()
		{
			Assert(x => x.Method(10), "Method(10)");
			Assert(x => x.Method(x.Property + x.Field), "Method(Property+Field)");
			Assert(x => Math.Abs(x.Property), "Abs(Property)");

		}


		[Fact]
		public void UnaryOperatorTest()
		{
			Assert(x => +x.Field, "+Field");
			Assert(x => -x.Property, "-Property");
		}





	}
}
