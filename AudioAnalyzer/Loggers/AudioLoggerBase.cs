using MediaAnalyzer.Core.Loggers;

namespace AudioAnalyzer.Loggers
{
	public abstract class AudioLoggerBase : LoggerBase<AudioInfo>
	{
		protected AudioLoggerBase(string outputDirectory, string loggerName)
			: base(outputDirectory, loggerName, AudioLoggerConstants.Header)
		{
		}

		public override void Log(AudioInfo audio)
		{
			if(NeedToBeSkipped(audio))
				return;

			Logger.WriteLine(audio);
		}

		protected abstract bool NeedToBeSkipped(AudioInfo audio);
	}
}