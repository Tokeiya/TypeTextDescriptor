#nullable enable
using System.Text;

namespace RecordFormatter
{
	public interface IRecordLabel:IWritableElement
	{
		IRecordLabel Parent { get; }
		void Add(string fieldId);
		IRecordLabel Add();
	}
}