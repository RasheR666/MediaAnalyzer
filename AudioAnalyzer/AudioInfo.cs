using System;
using System.Text;
using MediaAnalyzer.Core;

namespace AudioAnalyzer
{
	public class AudioInfo : IMediaInfo, IComparable<AudioInfo>
	{
		public string Name { get; set; }
		public string Extension { get; set; }
		public long Size { get; set; }
		public string Duration { get; set; }
		public long Bitrate { get; set; }
		public string BPM { get; set; }

		public int CompareTo(AudioInfo other)
		{
			return string.Compare(Name, other.Name, StringComparison.InvariantCulture);
		}

		public override string ToString()
		{
			try
			{
				var sb = new StringBuilder();
				sb.AppendFormat("{0,6}  ", Extension).Append("|");
				sb.AppendFormat("  {0,4}  ", Size/MB).Append("|");
				sb.AppendFormat("  {0,8}  ", Duration).Append("|");
				sb.AppendFormat("  {0,7}  ", Bitrate).Append("|");
				sb.AppendFormat("  {0,6}  ", BPM).Append("|");
				sb.AppendFormat($"  {Name}");
				return sb.ToString();
			}
			catch(Exception ex)
			{
				return $"Exception while trying transform to string audio file {Name}";
			}
		}

		private const int MB = 1024 * 1024;
	}
}