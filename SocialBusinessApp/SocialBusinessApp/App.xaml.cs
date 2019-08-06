using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using AndroidSpecific = Xamarin.Forms.PlatformConfiguration.AndroidSpecific;


namespace SocialBusinessApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this, AndroidSpecific.WindowSoftInputModeAdjust.Resize);
            
            MainPage = new NavigationPage(new SplashPage())
            {
                BarBackgroundColor = Color.FromHex("#FFFFFF"),
                //#9c27b0
                BarTextColor = Color.White,
            };
            
            /*MainPage = new NavigationPage(new Page1())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
                BarTextColor = Color.White,
            };*/
            

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
