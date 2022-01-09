using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrowsePage : ContentPage
    {
        public BrowsePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.BindingContext = this;
        }

        private Timer timer;

        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }


        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(20).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (cvWalkthrough.Position == 2)
                {
                    cvWalkthrough.Position = 0;
                    return;
                }

                cvWalkthrough.Position += 1;
            });
        }

        private ObservableCollection<Walkthrough> Load()
        {
            return new ObservableCollection<Walkthrough>(new[]
            {
                new Walkthrough
                {
                    Heading ="Mountains",
                    Caption = "Explore the world from your own point of view. Visit mountains and enjoy the freshness of life.",
                    Image = "parents.png"
                },

                new Walkthrough
                {
                    Heading ="Cities",
                    Caption = "Experience the blue and grey sights of high rise buildings around the world",
                    Image = "social_media.png"
                },

                new Walkthrough
                {
                    Heading ="Ancient",
                    Caption = "Understand the history and heritage of different cultures around the world.",
                    Image = "malware.png"
                },
                 new Walkthrough
                {
                    Heading ="Ancient",
                    Caption = "Understand the history and heritage of different cultures around the world.",
                    Image = "social_engineering.png"
                },
                  new Walkthrough
                {
                    Heading ="Ancient",
                    Caption = "Understand the history and heritage of different cultures around the world.",
                    Image = "passwords.png"
                }
            });
        }
    }

    public class Walkthrough
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }
}
