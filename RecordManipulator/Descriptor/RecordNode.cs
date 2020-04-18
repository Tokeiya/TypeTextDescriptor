#nullable enable

using System;
using System.IO;
using System.Threading;

namespace RecordManipulator.Descriptor
{
	public enum Direction
	{
		Horizontal = 1,
		Vertical
	}


	public sealed class RecordNode:IDescribable
	{

		public RecordNode(int id,Direction initialDirection)
		{
			if (initialDirection == Direction.Horizontal) RootLabel = new RecordLabel(ImaginaryRoot.Root, false);
			else if (initialDirection == Direction.Vertical) RootLabel = new RecordLabel(ImaginaryRoot.Root);
			else throw new ArgumentOutOfRangeException(nameof(initialDirection));

			Identity = id;
		}

		public int Identity { get; }
		public IRecordLabel RootLabel { get; }


		public void Describe(TextWriter writer)
		{
			writer.Write(Identity); 
			writer.Write(" [label = \"");

			RootLabel.Describe(writer);

			writer.Write("\"];");
		}
	}
}