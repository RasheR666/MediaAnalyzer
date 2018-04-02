using System;
using System.Text;
using MediaAnalyzer.Core;

namespace VideoAnalyzer
{
    public class VideoInfo : IMediaInfo, IComparable<VideoInfo>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Duration { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public long VideoBitrate { get; set; }
        public long AudioBitrate { get; set; }

        public int CompareTo(VideoInfo other)
        {
            return string.Compare(Name, other.Name, StringComparison.InvariantCulture);
        }

        public override string ToString()
        {
			var sb = new StringBuilder();
			sb.AppendFormat("{0,10}  ", Width + "x" + Height).Append("|");
	        sb.AppendFormat("  {0,5}  ", VideoBitrate).Append("|");
	        sb.AppendFormat("  {0,5}  ", AudioBitrate).Append("|");
	        sb.AppendFormat("  {0,4}  ", Size/MB).Append("|");
			sb.AppendFormat("  {0,8}  ", Duration).Append("|");
			sb.AppendFormat($"  {Name}");
	        return sb.ToString();
        }

	    private const int MB = 1024*1024;
    }
}
