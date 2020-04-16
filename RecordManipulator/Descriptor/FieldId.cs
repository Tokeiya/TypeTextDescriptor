using System;
using System.IO;

#nullable enable

namespace RecordManipulator.Descriptor
{
	internal sealed class FieldId : IRecordLabel
	{
		private readonly string _id;

		internal FieldId(string id, IRecordLabel parent)
		{
			if (parent is ImaginaryRoot) throw new ArgumentException($"{nameof(parent)} is ImaginaryRoot");
			Parent = parent;
			_id = id;
		}

		public IRecordLabel Parent { get; }


		public void Add(string fieldId)
		{
			throw new NotSupportedException($"{nameof(Add)} not supported.");
		}

		public IRecordLabel Add()
		{
			throw new NotSupportedException($"{nameof(Add)} not supported.");
		}


		public void Describe(TextWriter writer)
		{
			var ret = TextNormalizer.Normalize(_id);
			writer.Write(ret);
		}
	}
}