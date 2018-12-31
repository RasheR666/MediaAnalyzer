using System.Collections.Generic;
using Alphaleonis.Win32.Filesystem;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace VideoAnalyzer.Tests
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter))]
	[UseApprovalSubdirectory("VideoAnalyzer_Test")]
	public class VideoAnalyzer_Test
	{
		public VideoAnalyzer_Test()
		{
			videoAnalyzer = new VideoAnalyzer();
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void ShortVideo(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "ShortVideo.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void UnknownVideoResolution(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "UnknownVideoResolution.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void VideoInfo(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "VideoInfo.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void VideoBitrateOverhead(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "VideoBitrateOverhead.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void WrongExtension(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "WrongExtension.log");
		}

		private void MakeApprovement(string inputDirectory, string outputDirectory, string logName)
		{
			using(ApprovalResults.ForScenario(outputDirectory))
			{
				var actualDirectory = Path.Combine(OutputDirectory, outputDirectory);
				videoAnalyzer.Analyze(inputDirectory, actualDirectory);

				var actual = File.ReadAllText(Path.Combine(actualDirectory, logName));
				Approvals.Verify(actual);
			}
		}

		private static IEnumerable<TestCaseData> TestCases
		{
			get
			{
				yield return new TestCaseData(@"d:\Dance\!VIDEO\!ZOUK\!DISCs", "Discs").SetName("Discs");
				yield return new TestCaseData(@"d:\Dance\!VIDEO\!ZOUK\!INDIVIDUALS", "Individuals").SetName("Individuals");
				yield return new TestCaseData(@"d:\Dance\!VIDEO\!ZOUK\!INSTRUCTORS COURSE", "InstructorsCourse").SetName("InstructorsCourse");
				yield return new TestCaseData(@"d:\Dance\!VIDEO\!ZOUK\!OTHER EVENTS", "OtherEvents").SetName("OtherEvents");
				yield return new TestCaseData(@"d:\Dance\!VIDEO\!ZOUK\!PEOPLE", "People").SetName("People");
			}
		}

		private readonly string OutputDirectory = @"d:\Projects\MediaAnalyzer\VideoAnalyzer.Tests\bin";
		private readonly VideoAnalyzer videoAnalyzer;
	}
}