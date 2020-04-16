#nullable enable
namespace RecordManipulator.Descriptor
{
	public interface IRecordLabel:IDescribable
	{
		IRecordLabel Parent { get; }
		void Add(string fieldId);
		IRecordLabel Add();
	}
}