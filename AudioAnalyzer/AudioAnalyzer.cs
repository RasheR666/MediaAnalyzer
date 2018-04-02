using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AudioAnalyzer.Loggers;
using MediaAnalyzer.Core.Loggers;
using File = System.IO.File;

namespace AudioAnalyzer
{
	public class AudioAnalyzer
	{
		public void Analyze(string inputDirectory, string outputDirectory)
		{
			var audioInfos = GetAudios(inputDirectory);
			Log(outputDirectory, audioInfos);
		}

		private SortedSet<AudioInfo> GetAudios(string inputDirectory)
		{
			return new AudioInfoProvider(inputDirectory).Get();
		}

		private void Log(string outputDirectory, IEnumerable<AudioInfo> audioInfos)
		{
			using (var logger = CreateLogger(outputDirectory))
			{
				logger.LogHeader();
				foreach (var audioInfo in audioInfos)
				{
					logger.Log(audioInfo);
				}
			}
		}

		private static CompositeLogger<AudioInfo> CreateLogger(string outputDirectory)
		{
			return new CompositeLogger<AudioInfo>(
				new AudioInfoLogger(outputDirectory),
				new UnknownBPMLogger(outputDirectory),
				new WrongFileExtensionLogger(outputDirectory)
			);
		}
	}
}