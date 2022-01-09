using System;
using Teachify.Services;
using Teachify.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Teachify
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {
                MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            
            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental" });
            Device.SetFlags(new[] { "Expander_Experimental" });
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
