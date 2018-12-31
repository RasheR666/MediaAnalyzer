using System;

namespace VideoAnalyzer.Loggers
{
	public class WrongFileExtensionLogger : VideoLoggerBase
	{
		public WrongFileExtensionLogger(string outputDirectory)
			: base(outputDirectory, "WrongExtension")
		{
		}

		protected override bool NeedToBeSkipped(VideoInfo video)
		{
			return correctExtension.Equals(video.Extension, StringComparison.InvariantCultureIgnoreCase);
		}

		private const string correctExtension = ".mp4";
	}
}