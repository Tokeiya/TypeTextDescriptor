using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RecordFormatter
{
	public enum Direction
	{
		Horizontal = 1,
		Vertical
	}


	public sealed class RecordNode
	{
		private static int _idSeed = 0;
		static int GetId() => Interlocked.Increment(ref _idSeed);

		public RecordNode(Direction initialDirection)
		{
			if (initialDirection == Direction.Horizontal) RootLabel = new RecordLabel(ImaginaryRoot.Root, false);
			else if (initialDirection == Direction.Vertical) RootLabel = new RecordLabel(ImaginaryRoot.Root);
			else throw new ArgumentOutOfRangeException(nameof(initialDirection));

			Identity = GetId();
		}

		public int Identity { get; }
		public IRecordLabel RootLabel { get; }

		public void ToRecordNode(StringBuilder buffer)
		{
			buffer.Append(Identity);
			buffer.Append(" [label = \"");

			RootLabel.ToRecord(buffer);

			buffer.Append("\"];");
		}
	}
}
