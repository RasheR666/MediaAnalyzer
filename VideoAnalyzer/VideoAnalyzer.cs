using System.Collections.Generic;
using MediaAnalyzer.Core.Loggers;
using VideoAnalyzer.Loggers;

namespace VideoAnalyzer
{
	public class VideoAnalyzer
	{
		public void Analyze(string inputDirectory, string outputDirectory)
		{
			var videos = new VideoInfoProvider(inputDirectory).Get();
			Log(videos, outputDirectory);
		}

		private void Log(SortedSet<VideoInfo> videos, string outputDirectory)
		{
			using (var logger = CreateLogger(outputDirectory))
			{
				logger.LogHeader();
				foreach (var video in videos)
				{
					logger.Log(video);
				}
			}
		}

		private CompositeLogger<VideoInfo> CreateLogger(string outputDirectory)
		{
			return new CompositeLogger<VideoInfo>(
				new VideoInfoLogger(outputDirectory),
				new VideoBitrateOverheadLogger(outputDirectory),
				new WrongFileExtensionLogger(outputDirectory),
				new ShortVideoLogger(outputDirectory),
				new UnknownVideoResolutionLogger(outputDirectory)
			);
		}
	}
}