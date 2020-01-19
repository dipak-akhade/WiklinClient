using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WiklinClient.ViewModels
{
    public class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ICommand PlaceQuickOrderCommand { get; set; }
        public const string ServiceNumber = "8007227997";
        public const string txtMessage = "I need a quick luandry service!";

        public MainPageViewModel()
        {
            PlaceQuickOrderCommand = new Command(ExecutePlaceQuickOrder);
        }

        private async void ExecutePlaceQuickOrder(object obj)
        {
            if (!string.IsNullOrEmpty(ServiceNumber))
            {
                await SendSms(txtMessage, ServiceNumber);
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
                //await DisplayAlert("Failed", "Sms is not supported on this device.", "OK");
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}
