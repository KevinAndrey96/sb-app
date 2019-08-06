using Newtonsoft.Json;
using SocialBusinessApp.Tabbeds;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        private static HttpClient client = new HttpClient();
        private String AppUsuario;
        private String AppContrasena;
        Respuesta Rta;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

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
        /*private void GuardarSesion(String Usuario, String Contrasena, String Codigo, String VIP)
        {
            //DisplayAlert("Bienvenido","Su sesión ha sido iniciada con exito","Ok");
            App.Current.Properties["Codigo"] = Codigo;
            App.Current.Properties["Usuario"] = Usuario;
            App.Current.Properties["Contrasena"] = Contrasena;
            App.Current.Properties["VIP"] = VIP;
        }*/

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            //await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(0.9, 750, Easing.Linear);
            //await splashImage.ScaleTo(150, 1200, Easing.Linear);
            //await splashImage.ScaleTo(150, 600, Easing.Linear);
            /*Application.Current.MainPage = new NavigationPage(new InicioSesion())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
                BarTextColor = Color.White,
            };*/
           if (App.Current.Properties.ContainsKey("Usuario"))
            {
                AppUsuario = (String)App.Current.Properties["Usuario"];
                AppContrasena = (String)App.Current.Properties["Contrasena"];
                SendTo();
            }else
            {
                Application.Current.MainPage = new NavigationPage(new InicioSesion())
                {
                    BarBackgroundColor = Color.FromHex("#9c27b0"),
                    BarTextColor = Color.White,
                };
            }
        }
        private async void SendTo()
        {
            
            var values = new Dictionary<string, string>
                {
                   { "Dato1",  AppUsuario},
                   { "Dato2", AppContrasena }

                };
            var content = new FormUrlEncodedContent(values);

            try
            {
                var response = await client.PostAsync("https://app.socialbusiness.com.co/api/Login.php", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }

            //agrega
            /*
            Application.Current.MainPage = new NavigationPage(new NuevaOferta())
            {
                BarBackgroundColor = Color.FromHex("#9c27b0"),
                BarTextColor = Color.White,
            };
            */
            //finaliza
            
            if (Rta.Estado.Equals("Si"))
            {
                if (Rta.VIP.Equals("SI"))
                {
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1())
                    {
                        BarBackgroundColor = Color.FromHex("#9c27b0"),
                        BarTextColor = Color.White,
                    };
                }else
                {
                    Application.Current.MainPage = new NavigationPage(new TabbedPrincipal2())
                    {
                        BarBackgroundColor = Color.FromHex("#9c27b0"),
                        BarTextColor = Color.White,
                        //BarTintColor = Color.Black,
                        //TintColor = Color.Red,
                };
                }
                
            }
            else
            {
                //EliminarSesion();
                Application.Current.MainPage = new NavigationPage(new InicioSesion())
                {
                    BarBackgroundColor = Color.FromHex("#9c27b0"),
                    BarTextColor = Color.White,
                };
            }
            
        }
        private void EliminarSesion()
        {
            Xamarin.Forms.Application.Current.Properties.Clear();
        }

    }
}
