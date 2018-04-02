using System;

namespace MediaAnalyzer.Core.Loggers
{
	public interface ILog<T> : IDisposable where T : IMediaInfo
	{
		void LogHeader();

		void Log(T mediaInfo);
	}
}