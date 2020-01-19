using System;
using Xamarin.Forms;
using WiklinClient.Services;
using WiklinClient.Views;
using Xamarin.Forms.Xaml;
using WiklinClient.Resources;
using Xamarin.Essentials;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace WiklinClient
{
	public partial class App : Application
	{
		//TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;
        const int smallWightResolution = 768;
        const int smallHeightResolution = 1280;

        public App ()
		{
			InitializeComponent();
            LoadStyles();
            if (UseMockDataStore)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<AzureDataStore>();

			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }
    }
}
