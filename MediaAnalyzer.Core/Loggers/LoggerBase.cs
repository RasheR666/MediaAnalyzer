using System.IO;

namespace MediaAnalyzer.Core.Loggers
{
	public abstract class LoggerBase<T> : ILog<T> where T : IMediaInfo
	{
		private readonly string logHeader;

		protected LoggerBase(string outputDirectory, string loggerName, string logHeader)
		{
			this.logHeader = logHeader;
			Logger = LogFactory.GetLog(outputDirectory, loggerName);
		}

		public void Dispose()
		{
			Logger.Dispose();
		}

		public void LogHeader()
		{
			Logger.WriteLine(logHeader);
		}

		public abstract void Log(T mediaInfo);

		protected StreamWriter Logger { get; }
	}
}