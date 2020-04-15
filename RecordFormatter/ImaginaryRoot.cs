﻿#nullable enable
using System;
using System.IO;

namespace RecordFormatter
{
	internal class ImaginaryRoot : IRecordLabel
	{
		private ImaginaryRoot()
		{
		}

		public static IRecordLabel Root { get; } = new ImaginaryRoot();
		public IRecordLabel Parent => throw new NotSupportedException($"{nameof(Parent)} is not supported.");

		public void Add(string fieldId)
		=> throw new NotSupportedException($"{nameof(Add)} is not supported.");


		public IRecordLabel Add()
		=> throw new NotSupportedException($"{nameof(Add)} is not supported.");

		public void WriteElement(TextWriter writer)
			=> throw new NotSupportedException($"{nameof(WriteElement)} is not supported.");
	}
}