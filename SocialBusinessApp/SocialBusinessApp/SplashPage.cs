using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            sub.HorizontalOptions = LayoutOptions.FillAndExpand;
            sub.VerticalOptions = LayoutOptions.FillAndExpand;

            splashImage = new Image
            {
                Source = "splash.png",
                //WidthRequest=(int)Application.Current.MainPage.Width,
                //HeightRequest = (int)Application.Current.MainPage.Height
                //WidthRequest = 1000,
                //HeightRequest = 1920,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.All);
            //AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            //AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, 1,1));
            //AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, 1, 1));

            sub.Children.Add(splashImage);

            //this.BackgroundColor = Color.FromHex("#9c27b0");
            this.BackgroundColor = Color.FromHex("#FFFFFF");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            //await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(0.9, 750, Easing.Linear);
            //await splashImage.ScaleTo(150, 1200, Easing.Linear);
            await splashImage.ScaleTo(150, 600, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new InicioSesion())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
                BarTextColor = Color.White,
            };
        }
    }
}
