using System;
using System.Linq.Expressions;
using ChainingAssertion;
using Tokeiya3.TypeTextDescriptor;
using Xunit;
using Xunit.Abstractions;
using RecordFormatter;
using static RecordFormatter.ImaginaryRoot;
namespace TextTypeDescriptorTest.RecordFormatter
{
	public class ImaginaryRootTest
	{
		[Fact]
		public void Add()
		{
			Assert.Throws<NotSupportedException>(() => Root.Add());
			Assert.Throws<NotSupportedException>(() => Root.Add("hoge"));
		}

		[Fact]
		public void GetParent()
		{
			Assert.Throws<NotSupportedException>(() => Root.Parent);
		}

	}
}
