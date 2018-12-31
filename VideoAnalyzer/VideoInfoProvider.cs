using System;
using System.Linq;
using MediaAnalyzer.Core;
using MediaInfoNET;

namespace VideoAnalyzer
{
	public class VideoInfoProvider : MediaInfoProviderBase<VideoInfo>
	{
		public VideoInfoProvider(string inputDirectory)
			: base(inputDirectory)
		{
		}

		protected override bool IsSuitable(MediaFile mediaFile)
		{
			return mediaFile.AllStreams.Any(x => Type.Equals(x.StreamType, StringComparison.InvariantCultureIgnoreCase));
		}

		protected override VideoInfo GetMediaInfo(MediaFile video)
		{
			var videoInfo = new VideoInfo();

			videoInfo.Name = video.File;
			videoInfo.Extension = video.Extension.ToLower();
			videoInfo.Size = video.FileSize;
			if(video.Video.Count > 0)
			{
				var streamVideo = video.Video[0];
				videoInfo.Duration = streamVideo.DurationString;

				videoInfo.Width = streamVideo.Width;
				videoInfo.Height = streamVideo.Height;

				videoInfo.VideoBitrate = streamVideo.Bitrate;
			}

			if(video.Audio.Count > 0)
				videoInfo.AudioBitrate = video.Audio[0].Bitrate;

			return videoInfo;
		}

		protected override string Type => "video";
	}
}