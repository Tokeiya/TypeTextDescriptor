using System;

namespace TextTypeDescriptorTest.TinyParser
{
	class AttributeStatement:ParsedEntity
	{
		public AttributeStatement(Id attributeTo, AttributeList attributes) =>
			(AttributeTo, Attributes) = (attributeTo, Attributes);
		
		public Id AttributeTo { get; }
		public AttributeList Attributes { get; }

	}
}
