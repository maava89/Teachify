using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Teachify.Services;
using Teachify.Views;
using Xamarin.Forms;

namespace Teachify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        

        public LoginViewModel()
        {
            Title = "Log In";
            Onboardings = GetOnboarding();
         
        }

        public List<Onboarding> Onboardings { get; set; }
        
        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding  { Heading = "Explore Our Content", Caption = "From several Cyber Security topics to Animated Videos" },
                new Onboarding  { Heading = "Your security in one place", Caption = "Browse all of the topics to get a better understanding" },
                new Onboarding  { Heading = "Learn about privacy now!", Caption = "Cybercrime is the biggest threat there is to the modern world" }
            };
        }
       
        public class Onboarding
        {
            public string Heading { get; set; }
            public string Caption { get; set; }
        }

    }
}
