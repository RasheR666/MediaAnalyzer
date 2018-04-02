namespace VideoAnalyzer.Loggers
{
    public class VideoInfoLogger : VideoLoggerBase
	{
        public VideoInfoLogger(string outputDirectory) 
			: base(outputDirectory, "VideoInfo")
        {
        }

		protected override bool NeedToBeSkipped(VideoInfo video)
		{
			return false;
		}
	}
}
