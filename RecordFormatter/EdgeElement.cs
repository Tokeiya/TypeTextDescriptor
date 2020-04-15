using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RecordFormatter
{
	public class EdgeElement:IDescribable
	{

		public EdgeElement(int from, int to, string label) => (From, To, Label) = (from, to, label);

			public int From { get; }
			public int To { get; }
			public string Label { get; }

			public void Describe(TextWriter writer)
				=> writer.WriteLine($"{From} -> {To} [label=\"{TextNormalizer.Normalize(Label)}\"];");

	}
}
