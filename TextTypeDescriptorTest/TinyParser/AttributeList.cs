using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextTypeDescriptorTest.TinyParser
{
	class AttributeList
	{
		public AttributeList(string target, IEnumerable<AttrElement> attributes) =>
			(Target, Attributes) = (target, attributes.ToArray());

		public string Target { get; }
		public IReadOnlyList<AttrElement> Attributes { get; }
	}


}
