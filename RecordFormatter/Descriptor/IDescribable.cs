using System.IO;
using System.Text;

namespace RecordManipulator.Descriptor
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
