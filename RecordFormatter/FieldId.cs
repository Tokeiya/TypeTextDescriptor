using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace RecordFormatter
{
	internal sealed class FieldId : IRecordLabel
	{

		private readonly string _id;

		internal FieldId(string id,IRecordLabel parent)
		{
			if (parent is ImaginaryRoot) throw new ArgumentException($"{nameof(parent)} is ImaginaryRoot");
			Parent = parent;
			_id = id;
		}

		public IRecordLabel Parent { get; }


		public void Add(string fieldId) => throw new NotSupportedException($"{nameof(Add)} not supported.");

		public IRecordLabel Add() => throw new NotSupportedException($"{nameof(Add)} not supported.");


		public void ToRecord(StringBuilder buffer)
		{
			var ret = Regex.Replace(_id, "[\\r\\n\\\"{}<>\\|]", m => m.Groups[0].Value switch
				{
					"\r" => "\\r",
					"\n" => "\\n",
					"\"" => "\\\"",
					"{" => "\\{",
					"}" => "\\}",
					"<" => "\\<",
					">" => "\\>",
					"|"=>"\\|",
					_ => throw new InvalidOperationException()
			});

			buffer.Append(ret);
		}
	}
}
