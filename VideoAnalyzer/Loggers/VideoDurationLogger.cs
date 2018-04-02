using System.IO;
using MediaAnalyzer.Core.Loggers;

namespace VideoAnalyzer.Loggers
{
    public class VideoDurationLogger : ILog<VideoInfo>
	{
        private StreamWriter log;

        public VideoDurationLogger(string outputDirectory, string name)
        {
            log = LogFactory.GetLog(outputDirectory, name);
        }

        public void Dispose()
        {
            log.Dispose();
        }

        public void LogHeader()
        {
        }

        public void Log(VideoInfo video)
        {
            log.WriteLine($"{video.Duration} | {video.Name}");
        }
    }
}
