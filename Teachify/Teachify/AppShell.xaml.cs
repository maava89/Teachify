using System;
using System.Collections.Generic;
using Teachify.ViewModels;
using Teachify.Views;
using Xamarin.Forms;

namespace Teachify
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private LoginPage loginPage;

        public AppShell()
        {
        }

        public AppShell(HomePage homePage)
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        public AppShell(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            
                await Shell.Current.GoToAsync("//HomePage");
            
        }
    }
}
