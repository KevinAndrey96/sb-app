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
                TxtNit.Text = "Nit: " + rank.Nit;
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
            FInmobiliaria.Source = rank.FotografiaInmobiliaria;

            btnOfertas.Clicked += (sender, e) => btnOfertasClick();
            btnComentarios.Clicked += (sender, e) => btnComentariosClick();
            btnLogros.Clicked += (sender, e) => btnLogrosClick();
            btnEquipo.Clicked += (sender, e) => btnEquipoClick();

        }
        private async void btnOfertasClick()
        {
            await Navigation.PushModalAsync(new OfertasUsuario(this.Code));
        }
        private async void btnComentariosClick()
        {
            await Navigation.PushModalAsync(new Comentarios(this.Code));
        }
        private async void btnLogrosClick()
        {
            await Navigation.PushModalAsync(new Logros(this.Code));
        }
        private async void btnEquipoClick()
        {
            await Navigation.PushModalAsync(new Equipo(this.Code));
        }
    }
}