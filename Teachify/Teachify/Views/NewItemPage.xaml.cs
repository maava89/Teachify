using Teachify.Models;
using Teachify.ViewModels;
using System;
using Xamarin.Forms;


namespace Teachify.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        
    }
}