using System;
using System.IO;
using System.Text;
using Xunit;
using static RecordFormatter.ImaginaryRoot;

namespace TextTypeDescriptorTest.RecordFormatterTests
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

		[Fact]
		public void ToRecordTest()
		{
			var buff=new StringBuilder();
			using var wtr=new StringWriter();
			

			Assert.Throws<NotSupportedException>(() => Root.Describe(buff));
			Assert.Throws<NotSupportedException>(() => Root.Describe(wtr));

		}


	}
}
