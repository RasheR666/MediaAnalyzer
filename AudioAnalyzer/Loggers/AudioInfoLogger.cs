namespace AudioAnalyzer.Loggers
{
	public class AudioInfoLogger : AudioLoggerBase
	{
		public AudioInfoLogger(string outputDirectory)
			: base(outputDirectory, "AudioInfo")
		{
		}

		protected override bool NeedToBeSkipped(AudioInfo audio)
		{
			return false;
		}
	}
}