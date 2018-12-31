using System;
using VideoAnalyzer;

namespace MediaAnalyzer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var command = args[0];
			if(audioInfo.Equals(command, StringComparison.InvariantCultureIgnoreCase))
			{
				var analyzer = new AudioAnalyzer.AudioAnalyzer();
				analyzer.Analyze(args[1], args[2]);
			}
			else if(videoInfo.Equals(command, StringComparison.InvariantCultureIgnoreCase))
			{
				var analyzer = new VideoAnalyzer.VideoAnalyzer();
				analyzer.Analyze(args[1], args[2]);
			}
			else if(videoDurationComparison.Equals(command, StringComparison.InvariantCultureIgnoreCase))
			{
				var comparer = new VideoDurationComparer();
				comparer.Compare(args[1], args[2], args[3]);
			}
			else throw new ApplicationException("Unknown command");
		}

		private const string audioInfo = "--ai";
		private const string videoInfo = "--vi";
		private const string videoDurationComparison = "--vdc";
	}
}