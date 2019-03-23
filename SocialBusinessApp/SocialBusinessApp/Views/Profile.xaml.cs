using Newtonsoft.Json;
using SocialBusinessApp.Models;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        Inmobiliario Userio;
        public Profile()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            
            this.Title = "Perfil";
            this.Icon = "iconoperfil";

            Ejecucion();

            btnChangePassword.Clicked += (sender, e) => BtnChangePasswordClick();
            btnEditProfile.Clicked += (sender, e) => BtnEditProfileClick();
            btnPremium.Clicked += (sender, e) => BtnPremiumClick();
            btnLogout.Clicked += (sender, e) => BtnLogoutClick();

        }
        private async void BtnChangePasswordClick()
        {
            await Navigation.PushModalAsync(new CambiarContrasena());
        }
        private async void BtnEditProfileClick()
        {
            await Navigation.PushModalAsync(new EditarPerfil());
        }
        private async void BtnPremiumClick()
        {
            //await Navigation.PushModalAsync(new OfertasUsuario(this.Code));
        }
        private async void BtnLogoutClick()
        {
            EliminarSesion();
            await Navigation.PopModalAsync();
            Application.Current.MainPage = new NavigationPage(new InicioSesion());
        }
        private void EliminarSesion()
        {
            Xamarin.Forms.Application.Current.Properties.Clear();
        }

        private async void Ejecucion()
        {
            var responseString="";
            var code = "";
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                code=(String)App.Current.Properties["Codigo"];
                string url = string.Format("/api/Profile.php?id="+code);
                var response = await client.GetAsync(url);
                responseString = await response.Content.ReadAsStringAsync();
                Userio = JsonConvert.DeserializeObject<Inmobiliario>(responseString);

                FPerfil.Source = Userio.FotoPerfil;
                FInmobiliaria.Source = Userio.FotoInmobiliaria;

                TxtName.Text = "" + Userio.Nombre;
                TxtCodigo.Text = Userio.Codigo;
                TxtCorreo.Text = "Email: " + Userio.Correo;
                TxtCelular.Text = "Teléfono: "+Userio.Celular;
                TxtPuntaje.Text = "Puntaje acumulado: "+Userio.Puntaje;
                TxtPosicion.Text = "Posición en Ranking: "+Userio.Posicion;
                if(Userio.Premium=="Si")
                {
                    txtPremium.Text = "Sb Premium hasta "+Userio.Vencimiento;
                    btnPremium.IsVisible = false;
                }else
                {
                    txtPremium.Text = "Suscripcipción Premium Vencida";
                    btnPremium.IsVisible = true;
                }

                TxtInmobiliaria.Text = Userio.Inmobiliaria;
                TxtNit.Text = "Nit. " + Userio.Nit;
                TxtDepartamento.Text = Userio.Departamento;

            }
            catch (Exception e)
            {
                //waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde"+e+"---"+responseString+"--"+code, "Ok");
                return;
            }
            
        }
    }
}