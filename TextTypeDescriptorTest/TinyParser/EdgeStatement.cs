using System;

namespace TextTypeDescriptorTest.TinyParser
{
	class EdgeStatement
	{
		public EdgeStatement(Id from, Id to) => (From, To) = (from, to);

		public Id From { get; }
		public Id To { get; }
	}
}