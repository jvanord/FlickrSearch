using System;
using Xamarin.Forms;

namespace FlickrSearch
{
	public class FlickrSearchSearchBar : SearchBar
	{
		public FlickrSearchSearchBar ()
		{
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			var width = base.ParentView.Width;
			var height = base.ParentView.Height;

			if (width < 0) {
				return base.OnSizeRequest (widthConstraint, heightConstraint);
			} else {
				var result = new SizeRequest (new Size (width - 20, 40));
				return result;
			}
		}
	}
}

