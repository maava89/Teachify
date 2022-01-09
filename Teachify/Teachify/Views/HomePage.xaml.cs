using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDl_BsM8r_l7vOu7vDu_nGPEhI8nsbP9vw";
        public HomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }

        private async void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of the login.
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are refreshing the token.
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now here lets grab user information.
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no!", "Ok");
            }
        }

        private void TapTopics_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemsPage());
        }


        private void TapAboutUs_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        private void TapContact_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContactPage());
        }

        private void TapLogOut_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void TapBrowse_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BrowsePage());
        }
    }
}