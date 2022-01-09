using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Teachify.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamVideoPlayer;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            AnimateCarousel();
        }

        Timer timer;
        private void AnimateCarousel()
        {
            timer = new Timer(7000) { AutoReset = true, Enabled = true };

            timer.Elapsed += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if(cvOnboarding.Position == 2)
                    {
                        cvOnboarding.Position = 0;
                        return;
                    }

                    cvOnboarding.Position += 1;
                });
            };
        }


        private void TapSignUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void TapSignIn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage());
        }

        private void TapForgotPassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }

        private void TapForgotPassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}