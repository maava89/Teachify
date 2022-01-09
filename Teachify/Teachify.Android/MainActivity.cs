using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MediaManager;
using Android.Views;
using CarouselView.FormsPlugin.Droid;
using Android.Gms.Common;
using Xamarin.Essentials;

namespace Teachify.Droid
{
    [Activity(Label = "Teachify", Icon = "@drawable/teachify_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
        
            base.OnCreate(savedInstanceState);
            IsPlayServicesAvailable();
            Xam.Forms.VideoPlayer.Android.VideoPlayerRenderer.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CarouselViewRenderer.Init();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void IsPlayServicesAvailable()
        {
            int resultcode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            bool isGooglePlayService = resultcode != ConnectionResult.Success;
            Preferences.Set("isGooglePlayService", isGooglePlayService);
        }
    }
}