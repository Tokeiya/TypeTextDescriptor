using System;

namespace TextTypeDescriptorTest.TinyParser
{
	class NodeStatement:ParsedEntity
	{
		public NodeStatement(Id identifier, AttributeList attributes) =>
			(Identifier, Attributes) = (identifier, attributes);
		
		public Id Identifier { get; }
		public AttributeList Attributes { get; }
	}
}