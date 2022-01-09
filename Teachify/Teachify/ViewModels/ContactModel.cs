using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace Teachify.ViewModels
{
    public class ContactModel: BaseViewModel
    {
        public ContactModel()
        {
            Title = "Contact";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.facebook.com/Teachify-Mobile-Security-114121974106092"));
            OpenWebCommand_1 = new Command(async () => await Browser.OpenAsync("https://www.instagram.com/teachify_mobsec/"));
            OpenWebCommand_2 = new Command(async () => await Browser.OpenAsync("https://www.youtube.com/channel/UCajXifQTBjHPHKCEtfO4VFw"));
        }

        public ICommand OpenWebCommand { get; }

        public ICommand OpenWebCommand_1 { get; }

        public ICommand OpenWebCommand_2 { get; }
    }
}
