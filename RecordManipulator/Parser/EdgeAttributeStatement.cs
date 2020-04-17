using System;
using System.Collections.Generic;
using System.IO;

namespace RecordManipulator.Parser
{
	public sealed class EdgeAttributeStatement : AttributeStatement
	{
		public EdgeAttributeStatement(IEnumerable<Attributes> attributes) : base(attributes)
		{
		}

		public override void Describe(TextWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}