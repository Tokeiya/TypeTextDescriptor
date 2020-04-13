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
}
