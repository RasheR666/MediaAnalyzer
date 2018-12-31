using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediaInfoNET;

namespace MediaAnalyzer.Core
{
	public abstract class MediaInfoProviderBase<T> where T : IMediaInfo
	{
		protected MediaInfoProviderBase(string inputDirectory)
		{
			if(!Directory.Exists(inputDirectory))
				throw new Exception("Указанный путь не является директорией");

			this.inputDirectory = inputDirectory;
		}

		public SortedSet<T> Get()
		{
			return new SortedSet<T>(GetMediaInfos());
		}

		protected abstract bool IsSuitable(MediaFile mediaFile);

		protected abstract T GetMediaInfo(MediaFile audio);

		protected abstract string Type { get; }

		private IEnumerable<T> GetMediaInfos()
		{
			return GetFiles().Select(x => new MediaFile(x)).Where(IsSuitable).Select(GetMediaInfo);
		}

		private string[] GetFiles()
		{
			return Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories);
		}

		private readonly string inputDirectory;
	}
}