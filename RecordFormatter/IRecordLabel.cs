#nullable enable
using System.Text;

namespace RecordFormatter
{
	public interface IRecordLabel:IDescribable
	{
		IRecordLabel Parent { get; }
		void Add(string fieldId);
		IRecordLabel Add();
	}
}