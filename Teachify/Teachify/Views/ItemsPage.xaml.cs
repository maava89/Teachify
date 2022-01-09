using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Models;
using Teachify.ViewModels;
using Teachify.Views;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Views
{
    public partial class ItemsPage : ContentPage
    {
       

        public ItemsPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MyEvents = GetEvents();
            this.BindingContext = this;
        }

        public ObservableCollection<Event> MyEvents { get; set; }
         
        private ObservableCollection<Event> GetEvents()
        {
            return new ObservableCollection<Event>
            {
                new Event { Title = "Malware", Video = new Uri ("https://www.youtube.com/embed/H-b22X8_Jlg"), Venue = "Tap Here For More!", Number = 1, Description = "Malware is intrusive software that is designed to damage and destroy computers and computer systems. That Includes smartphones, tablets and other devices."},
                new Event { Title = "Social Engineering", Video = new Uri ("https://www.youtube.com/embed/JsEj7sT7POM"), Venue = "Tap Here For More!", Number = 2, Description = "Social engineering is a manipulation technique that exploits human error to gain private information, access, or valuables."},
                new Event { Title = "Phishing", Image = "phishing.png", Venue = "Tap Here For More!", Number = 3, Description = "Phishing is a type of social engineering attack often used to steal user data, including login credentials and credit card numbers. This normally happens through E-mails or Text Messages."},
                new Event { Title = "Passwords", Image = "password.png", Venue = "Tap Here For More!", Number = 4, Description = "A password attack is simply when a hacker trys to steal your password.Because passwords can only contain so many letters and numbers, passwords are becoming less safe."},
                new Event { Title = "Cloud-Software Attacks", Image = "cloud.png", Venue = "Tap Here For More!", Number = 5, Description = "Cloud-Software attack's main goal is used for stealing users credentials and eventually any sensitive information inside of the Cloud."}
            };
        }

        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }


        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DescriptionView");

            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
                await CloseAnimation(imgView);
            }
        }

        public class Event
        {
            public string Title { get; set; }
            public string Venue { get; set; }
            public string Description { get; set; }
            public string Image { get; set; }
            public Uri Video { get; set; }
            public int Number { get; set; }

            
        }
    }
}