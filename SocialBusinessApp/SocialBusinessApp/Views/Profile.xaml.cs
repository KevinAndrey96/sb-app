using Newtonsoft.Json;
using SocialBusinessApp.Models;
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

        }
        
        private async void Ejecucion()
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://app.socialbusiness.com.co")
                };
                var code=(String)App.Current.Properties["Codigo"];
                string url = string.Format("/api/Profile.php?id="+code);
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                Userio = JsonConvert.DeserializeObject<Inmobiliario>(responseString);

                FPerfil.Source = Userio.FotoPerfil;
                FInmobiliaria.Source = Userio.FotoInmobiliaria;

                TxtName.Text = "" + Userio.Nombre;
                TxtCodigo.Text = Userio.Codigo;
                TxtCorreo.Text = "Email: " + Userio.Correo;
                TxtCelular.Text = "Teléfono: "+Userio.Celular;
                TxtPuntaje.Text = "Puntaje acumulado: "+Userio.Puntaje;
                TxtPosicion.Text = "Posición en Ranking: "+Userio.Posicion;

                TxtInmobiliaria.Text = Userio.Inmobiliaria;
                TxtNit.Text = "Nit. " + Userio.Nit;
                TxtDepartamento.Text = Userio.Departamento;

            }
            catch (Exception e)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde"+e, "Ok");
                return;
            }
            
        }
    }
}