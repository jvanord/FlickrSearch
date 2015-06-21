using System;
using FlickrSearch;

namespace FlickrSearch
{
	public class FlickrSearchDataSource
	{
		PhotoInfo[] photos {
			get;
			set;
		}

		public int numberOfPhotos {
			get;
			set;
		}

		public int currentSelectedPhoto {
			get;
			private set;
		}

		public FlickrSearchDataSource (GlobalPhotoInfo globalPhotoInfo) {
			photos = globalPhotoInfo.photo;
			numberOfPhotos = globalPhotoInfo.perpage;
			currentSelectedPhoto = -1;
		}

		public FlickrSearchDataSource () {
			photos = null;
			numberOfPhotos = 0;
			currentSelectedPhoto = -1;
		}

		public PhotoInfo PhotoInfoAtIndex(int index) {
			if (index < numberOfPhotos) {
				currentSelectedPhoto = index;
				return photos [index];
			} else {
				return null;
			}
		}

	}
}

