using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Bindings;

namespace SocialBusinessApp.ViewModels
{
    public class MapViewModel
    {
        public ObservableCollection<Pin> Pins4 { get; set; }


        public Command<MapClickedEventArgs> MapClickedCommand =>
            new Command<MapClickedEventArgs>(args =>
            {
                Pins4.Clear();
                Pins4.Add(new Pin
                {
                    Label = $"Inmueble Social Business",
                    Position = args.Point
                });
                

                //DisplayAlert("Alerta", "Ubicación colocada" + args.Point, "Ok");
            });

        public Command MoveToTokyoCommand => new Command(() =>
        {
                MapSpan.FromCenterAndRadius(
                    new Position(35.681298, 139.766247),
                    Distance.FromKilometers(2));
        });



        public Command Continuarcom => new Command( async() => await Continuar());

        //(async () => await Mensajes("Hola"));
        public async Task Continuar()
        {
            ////await Application.Current.MainPage.DisplayAlert("Alerta", ""+Pins4.First().Position.ToString(), "Ok");
            //await Application.Current.MainPage.DisplayAlert("Alerta", "" + Pins4.First().Position.Latitude, "Ok");
            

            try
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
                string lat = Pins4.First().Position.Latitude.ToString();
                string lon = Pins4.First().Position.Longitude.ToString();
                await Application.Current.MainPage.Navigation.PushModalAsync(new NuevaOferta(lat, lon));
            }catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Seleccione una ubicación en el mapa para continuar", "Ok");
            }
        }
    }
    
}
