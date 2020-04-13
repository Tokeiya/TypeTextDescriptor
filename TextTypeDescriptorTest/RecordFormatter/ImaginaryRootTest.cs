using System;
using Xunit;
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
