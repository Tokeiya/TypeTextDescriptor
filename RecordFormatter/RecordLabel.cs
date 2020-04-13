using System;
using System.Text;

namespace RecordFormatter
{
	public interface IRecordLabel
	{
		void Add(string fieldId);
		IRecordLabel Add();

		IRecordLabel Parent { get; }

		void ToRecord(StringBuilder buffer);
	}

	internal class ImaginaryRoot : IRecordLabel
	{
		public static IRecordLabel Root { get; } = new ImaginaryRoot();
		public IRecordLabel Parent => throw new NotImplementedException();


		private ImaginaryRoot() { }

		public void Add(string fieldId)
		{
			throw new NotImplementedException();
		}

		public IRecordLabel Add()
		{
			throw new NotImplementedException();
		}

		public void ToRecord(StringBuilder buffer)
		{
			throw new NotImplementedException();
		}
	}
}
