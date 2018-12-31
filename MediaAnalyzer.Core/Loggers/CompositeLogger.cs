using System;

namespace MediaAnalyzer.Core.Loggers
{
	public class CompositeLogger<T> : ILog<T> where T : IMediaInfo
	{
		public CompositeLogger(params ILog<T>[] loggers)
		{
			this.loggers = loggers;
		}

		public void Dispose()
		{
			PerformActionForAll(x => x.Dispose());
		}

		public void LogHeader()
		{
			PerformActionForAll(x => x.LogHeader());
		}

		public void Log(T mediaInfo)
		{
			PerformActionForAll(x => x.Log(mediaInfo));
		}

		private void PerformActionForAll(Action<ILog<T>> action)
		{
			foreach(var log in loggers)
				action(log);
		}

		private readonly ILog<T>[] loggers;
	}
}