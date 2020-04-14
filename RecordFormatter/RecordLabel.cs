#nullable enable
using System.Collections.Generic;
using System.Text;

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

		public void ToRecord(StringBuilder buffer)
		{
			if (_hasBrackets) buffer.Append('{');

			foreach (var elem in _elements)
			{
				elem.ToRecord(buffer);
				buffer.Append("|");
			}

			if (_elements.Count > 0) buffer.Remove(buffer.Length - 1, 1);

			if (_hasBrackets) buffer.Append('}');
		}
	}
}