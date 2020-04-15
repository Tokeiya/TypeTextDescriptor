using System.IO;
using System.Text;

namespace RecordFormatter
{
	public interface IWritableElement
	{
		void WriteElement(TextWriter writer);

		void WriteElement(StringBuilder builder)
		{
			using var wtr = new StringWriter(builder);
			WriteElement(wtr);
		}
	}
}
