#nullable enable
using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Microsoft.Extensions.ObjectPool;

namespace RecordFormatter
{
	public sealed class DigraphWriter : IDisposable
	{

		private readonly TextWriter _writer;
		private bool _isDisposed;


		public DigraphWriter(string name, TextWriter writer)
		{
			_writer = writer;

			_writer.WriteLine($"digraph {name}{{");
			_writer.WriteLine("\tgraph[");
			_writer.WriteLine("\t\tcharset=\"UTF-8\",");
			_writer.WriteLine("\t]");
			_writer.WriteLine();
			_writer.WriteLine("\tnode[");
			_writer.WriteLine("\t\tshape=record");
			_writer.WriteLine("\t]");
			_writer.WriteLine();
		}

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_isDisposed = true;
				_writer.WriteLine("}");
				_writer.Dispose();
			}
		}

		public void WriteRecord(RecordNode node)
		{
			_writer.Write('\t');
			node.WriteElement(_writer);
			_writer.WriteLine();
		}

		public void WriteEdge(RecordNode from, RecordNode to)
		{
			_writer.WriteLine($"\t{from.Identity}->{to.Identity}");
		}
	}
}