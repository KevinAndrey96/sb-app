using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        public Mapa(string Lat, string Long, string Nombre, string Direccion)
        {
            InitializeComponent();
            //DisplayAlert("1", "uno: "+Lat, "Dos: "+Long);
            

            map.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(Convert.ToSingle(Lat), Convert.ToSingle(Long)), Distance.FromMiles(1)));

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Xamarin.Forms.Maps.Position(Convert.ToSingle(Lat), Convert.ToSingle(Long)),
                Label = Nombre,
                Address = Direccion,
                Id = "Social Business"
            };

            map.Pins.Add(pin);
        }

    }
}