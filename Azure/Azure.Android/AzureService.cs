using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace Azure.Droid
{
   public class AzureService
    {
        static readonly string AppUrl = "https://URL_PARA_SEU_BACKEND.azurewebsites.net";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthenticate>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("Ops", "Não conseguimos efeturar o seu login, tente novamente", "OK");
                    });
                return null;
            }
            return user;
        }
    }
}