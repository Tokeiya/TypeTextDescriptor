using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace RecordFormatter
{
	public sealed class DigraphWriter:IDisposable
	{
		private readonly ObjectPool<StringBuilder> _pool =
			ObjectPool.Create<StringBuilder>(new DefaultPooledObjectPolicy<StringBuilder>());

		private readonly TextWriter _writer;
		private bool _isDisposed = false;
		

		public DigraphWriter(string name,TextWriter writer)
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

		public void WriteRecord(RecordNode node)
		{
			var bld = _pool.Get();

			try
			{
				node.ToRecordNode(bld);
				_writer.Write('\t');
				_writer.WriteLine(bld.ToString());
			}
			finally
			{
				bld.Clear();
				_pool.Return(bld);
			}
		}

		public void WriteEdge(RecordNode from, RecordNode to) => _writer.WriteLine($"\t{from.Identity}->{to.Identity}");

		public void Dispose()
		{
			if (!_isDisposed)
			{
				_isDisposed = true;
				_writer.WriteLine("}");
				_writer.Dispose();
			}
		}
	}
}
