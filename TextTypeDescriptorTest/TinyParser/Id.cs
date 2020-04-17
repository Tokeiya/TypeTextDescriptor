using System;
using System.Collections.Generic;
using System.Text;

namespace TextTypeDescriptorTest.TinyParser
{
	class Id
	{
		public Id(string value, bool isQuoted) => (Value, IsQuoted) = (value, isQuoted);

		public bool IsQuoted { get; }
		public string Value { get; }

	}
}
