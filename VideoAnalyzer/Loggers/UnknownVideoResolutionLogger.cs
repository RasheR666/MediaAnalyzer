namespace VideoAnalyzer.Loggers
{
	public class UnknownVideoResolutionLogger : VideoLoggerBase
	{
		public UnknownVideoResolutionLogger(string outputDirectory)
			: base(outputDirectory, "UnknownVideoResolution")
		{
		}

		protected override bool NeedToBeSkipped(VideoInfo video)
		{
			return video.Width > 0 && video.Height > 0;
		}
	}
}