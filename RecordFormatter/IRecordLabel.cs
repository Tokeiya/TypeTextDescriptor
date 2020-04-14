#nullable enable
using System.Text;

namespace RecordFormatter
{
	public interface IRecordLabel
	{
		IRecordLabel Parent { get; }
		void Add(string fieldId);
		IRecordLabel Add();

		void ToRecord(StringBuilder buffer);
	}
}