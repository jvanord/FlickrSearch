using System;
using System.Collections.Generic;

namespace FlickrSearch
{
	public class ImageSize {

		public String label {
			get;
			set;
		}

		public int width {
			get;
			set;
		}

		public int height {
			get;
			set;
		}

		public String source {
			get;
			set;
		}

		public String url {
			get;
			set;
		}

		public String media {
			get;
			set;
		}


		public ImageSize () {
		}
	}

	public class PhotoSizeInfo {

		public bool canblog {
			get;
			set;
		}

		public bool canprint {
			get;
			set;
		}

		public bool candownload {
			get;
			set;
		}

		public List<ImageSize> size {
			get;
			set;
		}

		public String stat {
			get;
			set;
		}

		public PhotoSizeInfo () {
		}

		public ImageSize SizeForLabel(String label) {
			foreach (ImageSize imageSize in size) {
				if (imageSize.label.Equals (label)) {
					return imageSize;
				}
			}
			return null;
		}

		public String UriStringForOriginal (){
			ImageSize imageSize = null;
			if ((imageSize = SizeForLabel("Original")) != null) {
				return imageSize.source;
			} else {
				return "";
			}
		}

		public String UriStringForHighestAvailableResolution () {
			ImageSize imageSize = null;
//			if ((imageSize = SizeForLabel("Large 1600")) != null) {
//				return imageSize.source;
//			}
//			if ((imageSize = SizeForLabel("Large")) != null) {
//				return imageSize.source;
//			}
//			if ((imageSize = SizeForLabel("Medium 800")) != null) {
//				return imageSize.source;
//			}
//			if ((imageSize = SizeForLabel("Medium 640")) != null) {
//				return imageSize.source;
//			}
			if ((imageSize = SizeForLabel("Medium")) != null) {
				return imageSize.source;
			}
			if ((imageSize = SizeForLabel("Small 320")) != null) {
				return imageSize.source;
			}
			if ((imageSize = SizeForLabel("Small")) != null) {
				return imageSize.source;
			}
			if ((imageSize = SizeForLabel("Thumbnail")) != null) {
				return imageSize.source;
			}

			return "";
		}
	}

	public class GlobalPhotoSizeInfo {

		public PhotoSizeInfo sizes;

		public GlobalPhotoSizeInfo () {
		}
	}
}

