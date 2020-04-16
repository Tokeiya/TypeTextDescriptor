using System;
using System.IO;

namespace RecordManipulator.Parser
{
	public class Id:IDescribable
	{
		public Id(string value, bool isQuoted)
		{
#warning Id_Is_NotImpl
			throw new NotImplementedException("Id is not implemented");
		}
		
		public bool IsQuoted { get; }
		public string Value { get; }
		public void Describe(TextWriter writer)
		{
			throw new NotImplementedException();
		}
	}
}