using System.IO;
using System.Text;

namespace MediaAnalyzer.Core.Loggers
{
	public class LogFactory
	{
		public static StreamWriter GetLog(string outputDirectory, string name)
		{
			var directory = !string.IsNullOrWhiteSpace(outputDirectory) ? outputDirectory : Directory.GetCurrentDirectory();
			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);
			return new StreamWriter(Path.Combine(directory, $"{name}.log"), false, Encoding.UTF8, 8192);
		}
	}
}