using System;
using System.Linq;
using MediaAnalyzer.Core;
using MediaInfoNET;

namespace AudioAnalyzer
{
	public class AudioInfoProvider : MediaInfoProviderBase<AudioInfo>
	{
		public AudioInfoProvider(string inputDirectory)
			: base(inputDirectory)
		{
		}

		protected override bool IsSuitable(MediaFile mediaFile)
		{
			return mediaFile.AllStreams.Count != 0
					&& mediaFile.AllStreams.All(x => Type.Equals(x.StreamType, StringComparison.InvariantCultureIgnoreCase));
		}

		protected override AudioInfo GetMediaInfo(MediaFile audio)
		{
			var audioInfo = new AudioInfo();

			audioInfo.Name = audio.File;
			audioInfo.Extension = audio.Extension.ToLower();
			audioInfo.Size = audio.FileSize;
			if(audio.Audio.Count > 0)
			{
				var streamAudio = audio.Audio[0];
				audioInfo.Duration = streamAudio.DurationString;
				audioInfo.Bitrate = streamAudio.Bitrate;
			}
			string bpm = null;
			if(audio.General.Properties.TryGetValue("BPM", out bpm))
				audioInfo.BPM = bpm;

			return audioInfo;
		}

		protected override string Type => "audio";
	}
}