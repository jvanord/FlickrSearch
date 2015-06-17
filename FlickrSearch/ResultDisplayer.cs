using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlickrSearch
{
	public class ResultDisplayer : Image
	{
		public ResultDisplayer ()
		{
		}

		protected override SizeRequest OnSizeRequest (double widthConstraint, double heightConstraint)
		{
			var width = base.ParentView.ParentView.Width;
			var height = base.ParentView.ParentView.Height;
			System.Diagnostics.Debug.WriteLine (width);
			if (width < 0) {
				return base.OnSizeRequest (widthConstraint, heightConstraint);
			} else {
				var limit = width;
				if (width > height) {
					limit = height;
				}
				var sizeRequest = new SizeRequest (new Size (limit - 100, limit - 100));
				return sizeRequest;
			}
		}
	}
}

