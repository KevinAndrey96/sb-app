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
            btnEquipo.Clicked += (sender, e) => btnEquipoClick(Perfil);

        }

        private void BtnWhatsappClick(string number)
        {
            if (number == "")
            {
                DisplayAlert("Alerta", "El usuario no tiene configurado su whatsapp aún", "Ok");
            }
            else
            {
                Device.OpenUri(new Uri("https://api.whatsapp.com/send?phone=57" + number));
            }
        }
        private void BtnURLClick(string url)
        {
            if (url == "")
            {
                DisplayAlert("Alerta", "El usuario no tiene configurada esta red social aún", "Ok");
            }
            else
            {
                Device.OpenUri(new Uri(url));
            }

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
        private async void btnEquipoClick(string Code)
        {
            await Navigation.PushModalAsync(new Equipo("Código: " + Code));
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
                TxtDepartamento.Text = Userio.Ciudad;

                TxtInmobiliaria.Text = Userio.Inmobiliaria;
                TxtNit.Text = "Nit. " + Userio.Nit;
                if (Userio.Inmobiliaria=="No")
                {
                    TxtInmobiliaria.Text = "";
                    TxtNit.Text = "";
                    btnEquipo.IsVisible = false;
                }


                btnWhatsapp.Clicked += (sender, e) => BtnWhatsappClick(Userio.Celular);
                btnFacebook.Clicked += (sender, e) => BtnURLClick(Userio.Facebook);
                btnTwitter.Clicked += (sender, e) => BtnURLClick(Userio.Twitter);
                btnInstagram.Clicked += (sender, e) => BtnURLClick(Userio.Instagram);
                btnYoutube.Clicked += (sender, e) => BtnURLClick(Userio.Youtube);
                btnWeb.Clicked += (sender, e) => BtnURLClick(Userio.Web);

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