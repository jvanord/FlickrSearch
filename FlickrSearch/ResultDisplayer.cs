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

			if (width < 0) {
				return base.OnSizeRequest (widthConstraint, heightConstraint);
			} else {
				var sizeRequest = new SizeRequest (new Size (width - 100, height - 100));
				System.Diagnostics.Debug.WriteLine ("Setting image view size to: {0:f2} x {1:f2}", sizeRequest.Request.Width, sizeRequest.Request.Height);
				return sizeRequest;
			}
		}
	}
}

