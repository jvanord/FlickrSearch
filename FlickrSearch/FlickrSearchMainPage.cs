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
			backButton.Clicked += BackButton_Clicked;
			var forwardButton = new Button {
				Text = ">",
				TextColor = Color.Aqua,
				WidthRequest = 40,
				HeightRequest = 40
			};
			forwardButton.Clicked += ForwardButton_Clicked;
			var imageView = new ResultDisplayer {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Source = ImageSource.FromUri (imageURI)
			};
			var searchBar = new FlickrSearchSearchBar {
				Placeholder = "search term",
				CancelButtonColor = Color.FromHex("d0d0d0")
			};
			searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;
			var stack = new StackLayout {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal,
				Children = {backButton, imageView, forwardButton}
			};

			var absoluteLayout = new AbsoluteLayout {
				//VerticalOptions = LayoutOptions.Center
			};
			absoluteLayout.Children.Add (searchBar, new Point (10, 20));
			absoluteLayout.Children.Add (stack, new Point (5, 90));

			Content = absoluteLayout;
		}

		void SearchBar_SearchButtonPressed (object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("search bar searches now...");
		}

		void ForwardButton_Clicked (object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("next button touched");
		}

		void BackButton_Clicked (object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("back button touched");
		}
	}
}


