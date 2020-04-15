#nullable enable

using System;
using System.IO;
using System.Text;
using System.Threading;

namespace RecordFormatter
{
	public enum Direction
	{
		Horizontal = 1,
		Vertical
	}


	public sealed class RecordNode:IWritableElement
	{
		private static int _idSeed;

		public RecordNode(Direction initialDirection)
		{
			if (initialDirection == Direction.Horizontal) RootLabel = new RecordLabel(ImaginaryRoot.Root, false);
			else if (initialDirection == Direction.Vertical) RootLabel = new RecordLabel(ImaginaryRoot.Root);
			else throw new ArgumentOutOfRangeException(nameof(initialDirection));

			Identity = GetId();
		}

		public int Identity { get; }
		public IRecordLabel RootLabel { get; }

		private static int GetId()
		{
			return Interlocked.Increment(ref _idSeed);
		}



		public void WriteElement(TextWriter writer)
		{
			writer.Write(Identity); 
			writer.Write(" [label = \"");

			RootLabel.WriteElement(writer);

			writer.Write("\"];");
		}
	}
}