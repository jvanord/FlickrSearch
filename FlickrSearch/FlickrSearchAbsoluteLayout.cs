using System;
using Xamarin.Forms;

namespace FlickrSearch
{
	public class FlickrSearchAbsoluteLayout : AbsoluteLayout
	{
		public FlickrSearchAbsoluteLayout ()
		{
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			var width = base.ParentView.Width;
			var height = base.ParentView.Height;
			System.Diagnostics.Debug.WriteLine (width);
			if (width < 0) {
				return base.OnSizeRequest (widthConstraint, heightConstraint);
			} else {
				SizeRequest result = new SizeRequest (new Size (width, height - 100));
				return result;
			}
		}
	}
}

