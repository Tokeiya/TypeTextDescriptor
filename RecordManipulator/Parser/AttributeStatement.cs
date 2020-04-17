using System;
using System.Collections.Generic;
using System.IO;

namespace RecordManipulator.Parser
{
	
	public abstract class AttributeStatement:IDescribable
	{
		protected AttributeStatement(IEnumerable<Attributes> attributes)
		{
#warning AttributeStatement_Is_NotImpl
			throw new NotImplementedException("AttributeStatement is not implemented");
		}
		
		public IReadOnlyList<Attributes> Attributes { get; }


		protected void ContentsDescribe(TextWriter writer)
		{
			throw new NotImplementedException();
		}

		public abstract void Describe(TextWriter writer);
	}
}