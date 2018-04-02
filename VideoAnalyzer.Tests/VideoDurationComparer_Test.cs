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
	[UseApprovalSubdirectory("VideoDurationComparer_Test")]
	public class VideoDurationComparer_Test
	{
		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void Duration_1(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "duration_1.log");
		}

		[Test]
		[TestCaseSource(nameof(TestCases))]
		public void Duration_2(string inputDirectory, string outputDirectory)
		{
			MakeApprovement(inputDirectory, outputDirectory, "duration_2.log");
		}

		private void MakeApprovement(string inputDirectory, string outputDirectory, string logName)
		{
			using (ApprovalResults.ForScenario(outputDirectory))
			{
				var actualDirectory = Path.Combine(OutputDirectory, outputDirectory);
				videoDurationComparer.Compare(inputDirectory, inputDirectory, actualDirectory);

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

		private string OutputDirectory = @"d:\Projects\MediaAnalyzer\VideoAnalyzer.Tests\bin";
		private readonly VideoDurationComparer videoDurationComparer;

		public VideoDurationComparer_Test()
		{
			videoDurationComparer = new VideoDurationComparer();
		}
	}
}