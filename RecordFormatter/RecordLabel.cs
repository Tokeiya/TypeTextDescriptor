#nullable enable
using System.Collections.Generic;
using System.IO;

namespace RecordFormatter
{
	internal sealed class RecordLabel : IRecordLabel
	{
		private readonly List<IRecordLabel> _elements = new List<IRecordLabel>();
		private readonly bool _hasBrackets;

		public RecordLabel(IRecordLabel parent, bool hasBrackets = true)
		{
			(Parent, _hasBrackets) = (parent, hasBrackets);
		}


		public IRecordLabel Parent { get; }

		public void Add(string fieldId)
		{
			_elements.Add(new FieldId(fieldId, this));
		}

		public IRecordLabel Add()
		{
			var ret = new RecordLabel(this);
			_elements.Add(ret);
			return ret;
		}


		public void Describe(TextWriter writer)
		{
			if (_hasBrackets) writer.Write('{');


			for (int i = 0; i < _elements.Count; i++)
			{
				_elements[i].Describe(writer);

				if (i < _elements.Count - 1) writer.Write('|');
			}


			if (_hasBrackets) writer.Write('}');
		}
	}
}