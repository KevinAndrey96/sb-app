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

            //MainPage = new SocialBusinessApp.MainPage();
            //MainPage = new SocialBusinessApp.InicioSesion();#
            /*MainPage = new NavigationPage(new InicioSesion())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
        		BarTextColor = Color.White,
	        };*/
            //Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);

            MainPage = new NavigationPage(new SplashPage())
            {
                BarBackgroundColor = Color.FromHex("#FFFFFF"),
                //#9c27b0
                BarTextColor = Color.White,
            };

            //MainPage = new SocialBusinessApp.MenuPrincipal();

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
