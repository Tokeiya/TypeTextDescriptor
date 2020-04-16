using System;
using System.Text.RegularExpressions;

namespace RecordManipulator.Descriptor
{
	internal static class TextNormalizer
	{
		public static string Normalize(string source)=> Regex.Replace(source, "[\\r\\n\\\"{}<>\\|]", m => m.Groups[0].Value switch
		{
			"\r" => "\\r",
			"\n" => "\\n",
			"\"" => "\\\"",
			"{" => "\\{",
			"}" => "\\}",
			"<" => "\\<",
			">" => "\\>",
			"|" => "\\|",
			_ => throw new InvalidOperationException()
		});
	}
}
