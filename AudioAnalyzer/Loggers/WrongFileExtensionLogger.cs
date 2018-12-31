using System;

namespace AudioAnalyzer.Loggers
{
	public class WrongFileExtensionLogger : AudioLoggerBase
	{
		public WrongFileExtensionLogger(string outputDirectory)
			: base(outputDirectory, "WrongExtension")
		{
		}

		protected override bool NeedToBeSkipped(AudioInfo audio)
		{
			return correctExtension.Equals(audio.Extension, StringComparison.InvariantCultureIgnoreCase);
		}

		private const string correctExtension = ".mp3";
	}
}