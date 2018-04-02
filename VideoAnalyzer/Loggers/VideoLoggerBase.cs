using MediaAnalyzer.Core.Loggers;

namespace VideoAnalyzer.Loggers
{
	public abstract class VideoLoggerBase : LoggerBase<VideoInfo>
	{
		protected VideoLoggerBase(string outputDirectory, string loggerName) 
			: base(outputDirectory, loggerName, VideoLoggerConstants.Header)
		{
		}

		public override void Log(VideoInfo video)
		{
			if (NeedToBeSkipped(video))
				return;

			if (lastWidth != video.Width || lastHeight != video.Height)
				Logger.WriteLine();
			Logger.WriteLine(video);

			lastWidth = video.Width;
			lastHeight = video.Height;
		}

		protected abstract bool NeedToBeSkipped(VideoInfo video);

		private int lastWidth;
		private int lastHeight;
	}
}