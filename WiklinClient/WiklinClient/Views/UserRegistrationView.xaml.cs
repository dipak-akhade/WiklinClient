using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiklinClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace WiklinClient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserRegistrationView : ContentPage
	{
        //UserRegistrationViewModel viewModel;

        public UserRegistrationView ()
		{
			InitializeComponent ();

            //BindingContext = viewModel = new UserRegistrationViewModel();

        }
        async void btnSendSms_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumber.Text))
            {
                await SendSms(txtMessage.Text, txtNumber.Text);
            }

        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                var message = new SmsMessage(messageText, recipient);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                await DisplayAlert("Failed", "Sms is not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}