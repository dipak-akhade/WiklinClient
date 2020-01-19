using System;
using WiklinClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WiklinClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		MainPageViewModel mainPageViewModel = new MainPageViewModel();
		public MainPage ()
		{
			InitializeComponent ();
			this.BindingContext = mainPageViewModel;
		}
	}
}