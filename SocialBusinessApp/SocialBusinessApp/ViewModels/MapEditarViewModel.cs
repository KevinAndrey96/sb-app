using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace SocialBusinessApp.ViewModels
{
    public class MapEditarViewModel
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

        private string username = null;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
            }
        }



        public Command Continuarcom => new Command(async () => await Continuar());

        //(async () => await Mensajes("Hola"));
        public async Task Continuar()
        {
            ////await Application.Current.MainPage.DisplayAlert("Alerta", ""+Pins4.First().Position.ToString(), "Ok");
            //await Application.Current.MainPage.DisplayAlert("Alerta", "" + Pins4.First().Position.Latitude, "Ok");


            try
            {
                
                string lat = Pins4.First().Position.Latitude.ToString();
                string lon = Pins4.First().Position.Longitude.ToString();
                string placeid = Username;
                //await Application.Current.MainPage.DisplayAlert("Alerta", "Hola: "+placeid, "Ok");
                await Application.Current.MainPage.Navigation.PopModalAsync();
                await Application.Current.MainPage.Navigation.PushModalAsync(new GuardarUbicacion(lat, lon, placeid));

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Seleccione una ubicación en el mapa para continuar", "Ok");
            }
        }
    }
}
