namespace AudioAnalyzer.Loggers
{
	public class UnknownBPMLogger : AudioLoggerBase
	{
		public UnknownBPMLogger(string outputDirectory)
			: base(outputDirectory, "UnknownBPM")
		{
		}

		protected override bool NeedToBeSkipped(AudioInfo audio)
		{
			return !string.IsNullOrWhiteSpace(audio.BPM) && audio.BPM != "0";
		}
	}
}