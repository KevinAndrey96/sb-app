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
        
        public OtroPerfil(Rank rank)
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.rank = rank;
            TxtName.Text = rank.Nombre;
            TxtInmobiliaria.Text = "Inmobiliaria: " + rank.Inmobiliaria;
            TxtNit.Text = "Nit: " + rank.Nit;
            TxtCodigo.Text = "Código: " + rank.Codigo;
            TxtCelular.Text = "Celular: " + rank.Celular;
            TxtCorreo.Text = "Correo electrónico: " + rank.Correo;
            TxtPosicion.Text = "Posición Ranking: " + rank.Posicion;
            TxtPuntaje.Text = "Puntaje: " + rank.Puntaje;
            FPerfil.Source = rank.Fotografia;
            FInmobiliaria.Source = rank.FotografiaInmobiliaria;

        }
    }
}