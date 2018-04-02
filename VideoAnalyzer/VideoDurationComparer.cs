using System.Collections.Generic;
using VideoAnalyzer.Loggers;

namespace VideoAnalyzer
{
	public class VideoDurationComparer
	{
		public void Compare(string firstInputDirectory, string secondInputDirectory, string outputDirectory)
		{
			LogVideoDurations(firstInputDirectory, outputDirectory, "duration_1");
			LogVideoDurations(secondInputDirectory, outputDirectory, "duration_2");
		}

		private void LogVideoDurations(string inputDirectory, string outputDirectory, string logName)
		{
			var videos = new VideoInfoProvider(inputDirectory).Get();
			Log(videos, outputDirectory, logName);
		}

		private void Log(SortedSet<VideoInfo> videos, string outputDirectory, string logName)
		{
			using (var logger  = new VideoDurationLogger(outputDirectory, logName))
			{
				logger.LogHeader();
				foreach (var video in videos)
				{
					logger.Log(video);
				}
			}
		}
	}
}