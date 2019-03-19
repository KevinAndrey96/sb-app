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

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarPerfil : ContentPage
    {
        Inmobiliario Userio;
        public BuscarPerfil(String Perfil)
        {
            InitializeComponent();
            Ejecucion(Perfil);
            //await Navigation.PushModalAsync(new OfertasUsuario(this.Code));

            btnOfertas.Clicked += (sender, e) => btnOfertasClick(Perfil);
            btnComentarios.Clicked += (sender, e) => btnComentariosClick(Perfil);
            btnLogros.Clicked += (sender, e) => btnLogrosClick(Perfil);
            btnEquipo.Clicked += (sender, e) => btnEquipoClick();
        }

        private async void btnOfertasClick(string Code)
        {
            await Navigation.PushModalAsync(new OfertasUsuario("Código: "+Code));
        }
        private async void btnComentariosClick(string Code)
        {
            await Navigation.PushModalAsync(new Comentarios("Código: "+Code));
        }
        private async void btnLogrosClick(string Code)
        {
            await Navigation.PushModalAsync(new Logros("Código: "+Code));
        }
        private async void btnEquipoClick()
        {
            await DisplayAlert("Alerta", "Opción no implementada aún", "Ok");
        }

        private async void Ejecucion(String Perfil)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                var code = Perfil;
                string url = string.Format("/api/Profile.php?id=" + code);
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                Userio = JsonConvert.DeserializeObject<Inmobiliario>(responseString);


                FPerfil.Source = Userio.FotoPerfil;
                FInmobiliaria.Source = Userio.FotoInmobiliaria;
                
                TxtName.Text = "" + Userio.Nombre;
                TxtCodigo.Text = "Código: "+Userio.Codigo;
                TxtCorreo.Text = "Email: " + Userio.Correo;
                TxtCelular.Text = "Teléfono: " + Userio.Celular;
                TxtPuntaje.Text = "Puntaje acumulado: " + Userio.Puntaje;
                TxtPosicion.Text = "Posición en Ranking: " + Userio.Posicion;

                TxtInmobiliaria.Text = Userio.Inmobiliaria;
                TxtNit.Text = "Nit. " + Userio.Nit;
                if (Userio.Inmobiliaria=="No")
                {
                    TxtInmobiliaria.Text = "";
                    TxtNit.Text = "";
                }
                
                //TxtDepartamento.Text = Userio.Departamento;
                
            }
            catch (Exception e)
            {
                //waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde" + e, "Ok");
                return;
            }

        }
    }
}