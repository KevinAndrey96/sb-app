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
using SocialBusinessApp.Behaviors;
using SocialBusinessApp.ViewModels;
using Position = Xamarin.Forms.Maps.Position;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa : ContentPage
    {
        
        public Mapa(string Lat, string Long, string Nombre, string Direccion)
        {
            InitializeComponent();

            //DisplayAlert("1", "uno: "+Lat, "Dos: "+Long);
            
            map2.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(Convert.ToDouble(Lat), Convert.ToDouble(Long)), Distance.FromMiles(1)));

            var pin2 = new Pin
            {
                Position = new Xamarin.Forms.Maps.Position(Convert.ToDouble(Lat), Convert.ToDouble(Long)),
                Label = Nombre,
                Address = Direccion,
                Id = "Social Business"
            };

            map2.Pins.Add(pin2);
        }
        /*private static void OnItemsSourceChanged(BindableObject view, object oldValue, object newValue)
        {

            if (view is MapBehavior mapBehavior)
            {
                mapBehavior.AddPins();
                mapBehavior.PositionMap();
            }
        }*/

    }
}