using System;
using System.Collections.Generic;

namespace FlickrSearch
{
	public class PhotoInfo
	{
		public string id {
			get;
			set;
		}

		public string owner {
			get;
			set;
		}

		public string secret {
			get;
			set;
		}

		public string server {
			get;
			set;
		}

		public string farm {
			get;
			set;
		}

		public string title {
			get;
			set;
		}

		public bool ispublic {
			get;
			set;
		}

		public bool isfriend {
			get;
			set;
		}

		public bool isfamily {
			get;
			set;
		}

		public PhotoInfo ()
		{
		}
	}

	public class GlobalPhotoInfo {

		public int page {
			get;
			set;
		}

		public int pages {
			get;
			set;
		}

		public int perpage {
			get;
			set;
		}

		public int total {
			get;
			set;
		}

		public PhotoInfo[] photo {
			get;
			set;
		}

		public GlobalPhotoInfo () {
		}
	}

	public class SearchResult {
		public GlobalPhotoInfo photos {
			get;
			set;
		}

		public SearchResult () {
		}
	}
}

