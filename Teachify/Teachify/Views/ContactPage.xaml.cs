using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Teachify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private void YoutubeButton_Clicked(object sender, EventArgs e)
        {
            
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _ = CrossShare.Current.Share(new Button_Clicked
            {
                Title = subject.Text,
                Text = message.Text
            });
        }
    }
}
