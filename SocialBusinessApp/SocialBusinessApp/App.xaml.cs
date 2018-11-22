using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SocialBusinessApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new SocialBusinessApp.MainPage();
            //MainPage = new SocialBusinessApp.InicioSesion();#
            /*MainPage = new NavigationPage(new InicioSesion())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
        		BarTextColor = Color.White,
	        };*/

            MainPage = new NavigationPage(new SplashPage())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
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
