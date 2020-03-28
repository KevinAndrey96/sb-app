using Newtonsoft.Json;
using Plugin.Share;
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

            btnOfertas.Clicked += (sender, e) => BtnOfertasClick(Perfil);
            //btnComentarios.Clicked += (sender, e) => BtnComentariosClick(Perfil);
            btnLogros.Clicked += (sender, e) => BtnLogrosClick(Perfil);
            btnEquipo.Clicked += (sender, e) => BtnEquipoClick(Perfil);
            btnCompartir.Clicked += (sender, e) => BtnCompartirClick(Userio.Codigo, Userio.Nombre+" "+Userio.Apellidos);


        }
        private async void BtnCompartirClick(string code, string nombre)
        {
            await CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = "Te invito a darle un vistazo a este colega: " + nombre,
                Title = "Colega Social Business",
                Url = "https://app.socialbusiness.com.co/profile/" + code
            });
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
        private async void BtnOfertasClick(string Code)
        {
            await Navigation.PushAsync(new OfertasUsuario("Código: "+Code));
        }
        private async void BtnComentariosClick(string Code)
        {
            await Navigation.PushAsync(new Comentarios("Código: "+Code));
        }
        private async void BtnLogrosClick(string Code)
        {
            await Navigation.PushAsync(new Logros("Código: "+Code));
        }
        private async void BtnEquipoClick(string Code)
        {
            await Navigation.PushAsync(new Equipo("Código: " + Code));
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


                if (Userio.Celular == "")
                {
                    btnWhatsapp.IsVisible = false;
                }
                if (Userio.Facebook == "")
                {
                    btnFacebook.IsVisible = false;
                }
                if (Userio.Twitter == "")
                {
                    btnTwitter.IsVisible = false;
                }
                if (Userio.Instagram == "")
                {
                    btnInstagram.IsVisible = false;
                }
                if (Userio.Youtube == "")
                {
                    btnYoutube.IsVisible = false;
                }
                if (Userio.Web == "")
                {
                    btnWeb.IsVisible = false;
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