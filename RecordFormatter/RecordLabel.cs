using System.Text;

namespace RecordFormatter
{
	internal sealed class RecordLabel : IRecordLabel
	{
		public IRecordLabel Parent => throw new System.NotImplementedException();

		public void Add(string fieldId)
		{
			throw new System.NotImplementedException();
		}

		public IRecordLabel Add()
		{
			throw new System.NotImplementedException();
		}

		public void ToRecord(StringBuilder buffer)
		{
			throw new System.NotImplementedException();
		}
	}
}
