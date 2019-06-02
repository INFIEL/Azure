using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Droid;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]

namespace Azure.Droid
{
 public class AuthenticateDroid : IAuthenticate
    {
       public async Task<MobileServiceUser> Authenticate (MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
               return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);   
            }

            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
