using System;

namespace VideoAnalyzer.Loggers
{
	public class ShortVideoLogger : VideoLoggerBase
	{
		public ShortVideoLogger(string outputDirectory) 
			: base(outputDirectory, "ShortVideo")
		{
		}

		protected override bool NeedToBeSkipped(VideoInfo video)
		{
			return TimeSpan.Parse(video.Duration) > TimeSpan.FromSeconds(10);
		}
	}
}