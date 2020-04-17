using System;
using System.IO;

namespace RecordManipulator.Parser
{
	public class Attribute:IDescribable
	{
		public Attribute(Id key,Id value)
		{
#warning Attribute_Is_NotImpl
			throw new NotImplementedException("Attribute is not implemented");
		}
		
		public Id Key { get; }
		public Id Value { get; }
		public void Describe(TextWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}