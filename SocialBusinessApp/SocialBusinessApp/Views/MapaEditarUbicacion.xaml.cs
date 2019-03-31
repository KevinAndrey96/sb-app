using SocialBusinessApp.ViewModels;
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
    public partial class MapaEditarUbicacion : ContentPage
    {
        public MapaEditarUbicacion(string placeid)
        {
            InitializeComponent();
            BindingContext = new MapEditarViewModel();
            place.Text = placeid;
        }
    }
}