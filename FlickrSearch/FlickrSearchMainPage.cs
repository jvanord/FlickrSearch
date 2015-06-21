using System;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FlickrSearch
{
	public class FlickrSearchMainPage : ContentPage
	{
		public static FlickrSearchDataSource dataSource;
		public Button backButton;
		public Button forwardButton;
		public FlickrSearchSearchBar searchBar;
		public ResultDisplayer imageView;

		public FlickrSearchMainPage () {

			dataSource = new FlickrSearchDataSource ();

			backButton = new Button {
				Text = "<",
				TextColor = Color.Aqua,
				WidthRequest = 40,
				HeightRequest = 40,
				IsEnabled = false
			};
			backButton.Clicked += BackButton_Clicked;

			forwardButton = new Button {
				Text = ">",
				TextColor = Color.Aqua,
				WidthRequest = 40,
				HeightRequest = 40,
				IsEnabled = false
			};
			forwardButton.Clicked += ForwardButton_Clicked;

			imageView = new ResultDisplayer {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			ReloadImageView ();

			searchBar = new FlickrSearchSearchBar {
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

			var absoluteLayout = new AbsoluteLayout();
			absoluteLayout.Children.Add (searchBar, new Point (10, 20));
			absoluteLayout.Children.Add (stack, new Point (5, 90));

			Content = absoluteLayout;
		}

		async public void ReloadImageView() {
			var imageInfo = dataSource.PhotoInfoAtIndex (0);
			if (imageInfo == null) {
				backButton.IsEnabled = false;
				forwardButton.IsEnabled = false;
				return;
			}
			await loadImageWithInfo (imageInfo);
			backButton.IsEnabled = dataSource.currentSelectedPhoto > 0;
			forwardButton.IsEnabled = dataSource.currentSelectedPhoto < (dataSource.numberOfPhotos - 1);
		}

		async void SearchBar_SearchButtonPressed (object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("search bar searches now...");

			FlickrSearchSearchBar mySearchBar = (FlickrSearchSearchBar)sender;
			var client = new HttpClient ();
			var uri = new Uri(String.Format("https://api.flickr.com/services/rest/?method=flickr.photos.search&api_key=a7a0c39eac2e0a720c4d911b13a43197&text={0}&sort=relevance&content_type=7&per_page=200&page=1&format=json&nojsoncallback=1", mySearchBar.Text));
			var json = await client.GetStringAsync (uri);
			SearchResult result = JsonConvert.DeserializeObject<SearchResult> (json);
			dataSource = new FlickrSearchDataSource (result.photos);
			this.ReloadImageView ();
		}

		async void ForwardButton_Clicked (object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("next button touched");
			var imageInfo = dataSource.PhotoInfoAtIndex (dataSource.currentSelectedPhoto + 1);
			if (imageInfo == null) {
				backButton.IsEnabled = false;
				forwardButton.IsEnabled = false;
				return;
			}
			await loadImageWithInfo (imageInfo);
			backButton.IsEnabled = dataSource.currentSelectedPhoto > 0;
			forwardButton.IsEnabled = dataSource.currentSelectedPhoto < (dataSource.numberOfPhotos - 1);
		}

		async void BackButton_Clicked (object sender, EventArgs e) {
			System.Diagnostics.Debug.WriteLine("back button touched");
			var imageInfo = dataSource.PhotoInfoAtIndex (dataSource.currentSelectedPhoto - 1);
			if (imageInfo == null) {
				backButton.IsEnabled = false;
				forwardButton.IsEnabled = false;
				return;
			}
			await loadImageWithInfo (imageInfo);
			backButton.IsEnabled = dataSource.currentSelectedPhoto > 0;
			forwardButton.IsEnabled = dataSource.currentSelectedPhoto < (dataSource.numberOfPhotos - 1);
		}


		async Task loadImageWithInfo(PhotoInfo info) {
			var uri = new Uri (String.Format ("https://api.flickr.com/services/rest/?method=flickr.photos.getSizes&api_key=15765d6abdfa25d50bee0645b12591ff&photo_id={0}&format=json&nojsoncallback=1", info.id));
			var client = new HttpClient ();
			var json = await client.GetStringAsync (uri);
			GlobalPhotoSizeInfo sizeInfo = JsonConvert.DeserializeObject<GlobalPhotoSizeInfo> (json);
			var photoUriString = sizeInfo.sizes.UriStringForOriginal ();
			if (photoUriString.Length == 0) {
				photoUriString = sizeInfo.sizes.UriStringForHighestAvailableResolution ();
			}
			imageView.Source = ImageSource.FromUri (new Uri (photoUriString));
		}
	}
}


