using System.Collections.Generic;
using Alphaleonis.Win32.Filesystem;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace AudioAnalyzer.Tests
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter))]
	[UseApprovalSubdirectory("AudioAnalyzer_Test")]
	public class AudioAnalyzer_Test
	{
		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void AudioInfo(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "AudioInfo.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void UnknownBPM(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "UnknownBPM.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void WrongExtension(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "WrongExtension.log");
		}

		private void MakeApprovement(string inputDirectory, string outputDirectory, string logName)
		{
			using (ApprovalResults.ForScenario(outputDirectory))
			{
				var actualDirectory = Path.Combine(OutputDirectory, outputDirectory);
				audioAnalyzer.Analyze(inputDirectory, actualDirectory);

				var actual = File.ReadAllText(Path.Combine(actualDirectory, logName));
				Approvals.Verify(actual);
			}
		}

		private static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(@"d:\Dance\!MUSIC\ZOUK\DJs\DJ Brandon ZK", "DJ Brandon ZK").SetName("DJ Brandon ZK");
				yield return new TestCaseData(@"d:\Dance\!MUSIC\ZOUK\DJs\DJ Eternal", "DJ Eternal").SetName("DJ Eternal");
				yield return new TestCaseData(@"d:\Dance\!MUSIC\ZOUK\DJs\DJ Mafie Zouker", "DJ Mafie Zouker").SetName("DJ Mafie Zouker");
				yield return new TestCaseData(@"d:\Dance\!MUSIC\KIZOMBA", "Kizomba").SetName("Kizomba");
				yield return new TestCaseData(@"d:\Dance\!MUSIC\ZOUK\SINGERs", "ZoukSingers").SetName("ZoukSingers");
				yield return new TestCaseData(@"d:\Dance\!MUSIC\Для постановок", "Performance").SetName("Performance");
			}
		}

		private string OutputDirectory = @"d:\Projects\MediaAnalyzer\VideoAnalyzer.Tests\bin";
		private readonly AudioAnalyzer audioAnalyzer;

		public AudioAnalyzer_Test()
		{
			audioAnalyzer = new AudioAnalyzer();
		}
	}
}
