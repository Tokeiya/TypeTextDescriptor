﻿using System.IO;
using System.Text;

namespace RecordManipulator
{
	public interface IDescribable
	{
		void Describe(TextWriter writer);

		void Describe(StringBuilder builder)
		{
			using var wtr = new StringWriter(builder);
			Describe(wtr);
		}
	}
}