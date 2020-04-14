using System;
using System.Text;

namespace RecordFormatter
{

	internal class ImaginaryRoot : IRecordLabel
	{
		public static IRecordLabel Root { get; } = new ImaginaryRoot();
		public IRecordLabel Parent => throw new NotSupportedException($"{nameof(Parent)} is not supported.");


		private ImaginaryRoot() { }

		public void Add(string fieldId)
			=> throw new NotSupportedException($"{nameof(Add)} is not supported.");

		public IRecordLabel Add()
			=> throw new NotSupportedException($"{nameof(Add)} is not supported.");

		public void ToRecord(StringBuilder buffer)
			=> throw new NotSupportedException($"{nameof(ToRecord)} is not supported.");
	}





}
