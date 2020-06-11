using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using xfgoogleLogin.Constants;
using xfgoogleLogin.Interface;

namespace xfgoogleLogin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static OAuth2Authenticator authenticator;
        public static MainPage mainPage;

       

        public MainPage()
        {
            InitializeComponent();
            mainPage = this;
        }

        public void OnPageLoading(Uri uri)
        {
            authenticator.OnPageLoading(uri);
        }
        private void btnLoginClickedEvent(object sender, EventArgs e)
        {

            authenticator = new OAuth2Authenticator(
                                                            AppConstants.ClientId,
                                                            string.Empty,
                                                            "email",
                                                            new Uri(AppConstants.authorizeUrl),
                                                            new Uri(AppConstants.RedirectUrl),
                                                            new Uri(AppConstants.accessTokenUrl),
                                                            isUsingNativeUI: true);

            authenticator.AllowCancel = true;

            authenticator.Completed += authenticator_Completed;

            Xamarin.Forms.DependencyService.Register<INativePages>();
            DependencyService.Get<INativePages>().StartActivityInAndroid(authenticator);


            authenticator.Error += onAuthError;
        }

        private async void authenticator_Completed(object sender, AuthenticatorCompletedEventArgs obj)
        {
            if (obj.IsAuthenticated)
            {
                var clientData = new HttpClient();

                //call google api to fetch logged in user profile info 
                var resData = await clientData.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo?access_token=" + obj.Account.Properties["access_token"]);
                var jsonData = await resData.Content.ReadAsStringAsync();

                // deserlize the jsondata and intilize in GoogleAuthClass
                GoogleAuthClass googleObject = JsonConvert.DeserializeObject<GoogleAuthClass>(jsonData);

                //you can access following property after login
                string email = googleObject.email;
                string photo = googleObject.picture;
                string name = googleObject.name;
                btnLogin.IsVisible = false;

                lblemail.Text = "Logged In as "+ email;
                lblemail.FontSize = 30;
                lblemail.FontAttributes = FontAttributes.Bold;
            }
            else
            {
                //Authentication fail
                // write the code to handle when auth failed
            }
        }

        private void onAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            DisplayAlert("Google Authentication Error", e.Message, "OK");
        }
    }
}

