namespace VideoAnalyzer.Loggers
{
    public class VideoBitrateOverheadLogger : VideoLoggerBase
	{
        public VideoBitrateOverheadLogger(string outputDirectory) 
			: base(outputDirectory, "VideoBitrateOverhead")
        {
        }

		protected override bool NeedToBeSkipped(VideoInfo video)
		{
			return video.Width <= 1280 && video.VideoBitrate <= 2650;
		}
	}
}
