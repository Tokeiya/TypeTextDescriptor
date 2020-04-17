using System;
using System.Collections.Generic;
using System.Text;

namespace TextTypeDescriptorTest.TinyParser
{
	class AttrElement
	{
		public AttrElement(Id key, Id value) => (Key, Value) = (key, value);

		public Id Key { get; }
		public Id Value { get; }

	}
}
