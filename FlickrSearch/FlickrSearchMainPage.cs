using System;

using Xamarin.Forms;

namespace FlickrSearch
{
	public class FlickrSearchMainPage : ContentPage
	{
		public FlickrSearchMainPage ()
		{
			var imageURI = new Uri ("http://media-cdn.tripadvisor.com/media/photo-s/05/39/6e/d0/jumeirah-beach-hotel.jpg");

			var backButton = new Button {
				Text = "<",
				TextColor = Color.Aqua,
				WidthRequest = 40,
				HeightRequest = 40
			};
			var forwardButton = new Button {
				Text = ">",
				TextColor = Color.Aqua,
				WidthRequest = 40,
				HeightRequest = 40
			};
			var imageView = new ResultDisplayer {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Source = UriImageSource.FromUri (imageURI)
			};
			var searchBar = new SearchBar {
				Placeholder = "search term",
				CancelButtonColor = Color.FromHex("d0d0d0"),
				WidthRequest = 300
			};

			var stack = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal,
				Children = {backButton, imageView, forwardButton}
			};

			var absoluteLayout = new AbsoluteLayout {
				//VerticalOptions = LayoutOptions.Center
			};
			absoluteLayout.Children.Add (searchBar, new Point (10, 30));
			absoluteLayout.Children.Add (stack, new Point (5, 100));

			Content = absoluteLayout;
		}
	}
}


