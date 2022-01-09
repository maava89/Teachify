using DocumentFormat.OpenXml.Wordprocessing;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyDl_BsM8r_l7vOu7vDu_nGPEhI8nsbP9vw";

        public SignInPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        
    

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLogInEmail.Text, UserLogInPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedContent);
                await Navigation.PushAsync(new HomePage());

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid E-Mail or Password", "Ok");
            }
        }
    }
}