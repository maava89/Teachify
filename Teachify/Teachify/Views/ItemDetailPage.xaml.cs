using Teachify.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using System;

namespace App1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}