using System;
using System.Collections.Generic;
using System.IO;

namespace RecordManipulator.Parser
{
	public class Attributes : IDescribable
	{
		public Attributes(IEnumerable<Attribute> attributes)
		{
#warning Attributes_Is_NotImpl
			throw new NotImplementedException("Attributes is not implemented");
		}
		public IReadOnlyList<Attribute> Contents
		{
			get
			{
#warning Contents_Is_NotImpl
				throw new NotImplementedException("Contents is not implemented");
			}
		}
		public void Describe(TextWriter writer)
		{
#warning Describe_Is_NotImpl
			throw new NotImplementedException("Describe is not implemented");
		}
	}
}