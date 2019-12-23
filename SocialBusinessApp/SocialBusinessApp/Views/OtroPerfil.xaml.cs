using Plugin.Share;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtroPerfil : ContentPage
    {
        Rank rank;
        String Code;
        
        public OtroPerfil(Rank rank)
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.rank = rank;
            this.Code = rank.Codigo;
            TxtName.Text = rank.Nombre;
            if(rank.Nit!="")
            {
                TxtInmobiliaria.Text = "Inmobiliaria: " + rank.Inmobiliaria;
                TxtNit.Text = "Nit. " + rank.Nit;
                btnEquipo.IsVisible = true;
            }
            else
            {
                btnEquipo.IsVisible = false;
            }
            TxtCodigo.Text = rank.Codigo;
            TxtCelular.Text = "Celular: " + rank.Celular;
            TxtCorreo.Text = "Correo electrónico: " + rank.Correo;
            TxtPosicion.Text = "Posición Ranking: " + rank.Posicion.Substring(10);
            TxtPuntaje.Text = rank.Puntaje;
            FPerfil.Source = rank.Fotografia;
            TxtDepartamento.Text = rank.Ciudad;
            FInmobiliaria.Source = rank.FotografiaInmobiliaria;

            btnOfertas.Clicked += (sender, e) => BtnOfertasClick();
            btnWhatsapp.Clicked += (sender, e) => BtnWhatsappClick(rank.Celular);
            btnFacebook.Clicked += (sender, e) => BtnURLClick(rank.Facebook);
            btnTwitter.Clicked += (sender, e) => BtnURLClick(rank.Twitter);
            btnInstagram.Clicked += (sender, e) => BtnURLClick(rank.Instagram);
            btnYoutube.Clicked += (sender, e) => BtnURLClick(rank.Youtube);
            btnWeb.Clicked += (sender, e) => BtnURLClick(rank.Web);

//            btnComentarios.Clicked += (sender, e) => BtnComentariosClick();
            btnLogros.Clicked += (sender, e) => BtnLogrosClick();
            btnEquipo.Clicked += (sender, e) => BtnEquipoClick();
            btnCompartir.Clicked += (sender, e) => BtnCompartirClick(rank.Codigo, rank.Nombre);

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
            if(number=="")
            {
                DisplayAlert("Alerta", "El usuario no tiene configurado su whatsapp aún", "Ok");
            }else
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
        
        private async void BtnOfertasClick()
        {
            await Navigation.PushModalAsync(new OfertasUsuario(this.Code));
        }
        private async void BtnComentariosClick()
        {
            await Navigation.PushModalAsync(new Comentarios(this.Code));
        }
        private async void BtnLogrosClick()
        {
            await Navigation.PushModalAsync(new Logros(this.Code));
        }
        private async void BtnEquipoClick()
        {
            await Navigation.PushModalAsync(new Equipo(this.Code));
        }
    }
}