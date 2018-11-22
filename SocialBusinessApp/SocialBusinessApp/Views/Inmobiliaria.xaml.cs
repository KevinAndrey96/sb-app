using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inmobiliaria : ContentPage
    {
        RankI ranki;
        public Inmobiliaria(RankI ranki)
        {
            InitializeComponent();
            this.ranki = ranki;

            TxtName.Text = ranki.Nombre;
            TxtPosition.Text = ranki.Posicion+" en Ranking";
            FInmobiliaria.Source = ranki.Fotografia;

            TxtDepartments.Text = ranki.Departamento;
            TxtNit.Text = "Nit. "+ranki.Nit;
            TxtScore.Text = ranki.Puntaje+" puntos";
        }
    }
}