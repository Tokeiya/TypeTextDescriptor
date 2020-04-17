using System;
using System.Collections.Generic;
using System.IO;

namespace RecordManipulator.Parser
{
	public sealed class GraphAttributeStatements:AttributeStatement
	{
		public GraphAttributeStatements(IEnumerable<Attributes> attributes) : base(attributes)
		{
		}

		public override void Describe(TextWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}