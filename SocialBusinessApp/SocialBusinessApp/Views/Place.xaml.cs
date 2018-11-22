using Newtonsoft.Json;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Place : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();

        private Oferta oferta;
        private List<OfertaFotos> ofertafotos;
        public string PlaceID;
        private string Lat;
        private string Long;
        public Place(Oferta oferta)
        {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            this.LoadFotos();
            this.oferta = oferta;

            btnUbicacion.Clicked += (sender, e) => btnUbicacionClickAsync();
            //btnGaleria.Clicked += (sender, e) => btnGaleriaClickAsync();

            TxtNombrePlace.Text = oferta.Nombre;
            TxtPrecio.Text = "Precio: "+oferta.Precio;
            TxtDireccion.Text = "Dirección: "+oferta.Direccion;
            TxtCiudad.Text = "Ciudad: "+oferta.Ciudad;
            TxtBarrio.Text = "Barrio: "+oferta.Barrio;
            TxtDepartamento.Text = "Departamento: "+oferta.Departamento;
            TxtTipo.Text = "Tipo: "+oferta.Tipo;
            TxtHabitaciones.Text = "Habitaciones: " + oferta.Habitaciones;
            TxtBanos.Text = "Baños: " + oferta.Banos;
            TxtParqueaderos.Text = "Parqueaderos: " + oferta.Parqueaderos;
            TxtEstrato.Text = "Estrato: "+oferta.Estrato;
            TxtArea.Text = "Area: " + oferta.Area;
            TxtAntiguedad.Text = "Antiguedad: "+ oferta.Antiguedad;
            TxtUbicacion.Text = "Ubicación: " + oferta.Ubicacion+ oferta.Lat+oferta.Long;
            TxtDescripcion.Text = oferta.Descripcion;
            FPlace.Source = oferta.Fotografia;
            Lat = oferta.Lat;
            Long = oferta.Long;
            DisplayAlert("uno", "Dos: " + oferta.Lat, "Tres" + oferta.Long);
            PlaceID = oferta.ID;
            this.PlaceID = oferta.ID;
            FotosInmuebleListView.ItemTemplate = new DataTemplate(typeof(FotosCell));
            
            this.LoadFotos();




            
            //imageSources.Add("comentarios.png");
            //imageSources.Add(Uri("https://i.etsystatic.com/11805514/r/il/3fe133/1001694695/il_570xN.1001694695_lcrp.jpg"));
            //imgSlider.Images = imageSources;
        }
        
        private async void btnUbicacionClickAsync()
        {
            //var objects = new Oferta();
            await Navigation.PushModalAsync(new Mapa(oferta.Lat,oferta.Long, oferta.Nombre, oferta.Direccion));
        }
        private async void btnGaleriaClickAsync()
        {
            await Navigation.PushModalAsync(new Gallery());
        }
        private async void LoadFotos()
        {
            waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                
                string url = string.Format("http://app.socialbusiness.com.co/api/Fotos.php?placeid=" + PlaceID);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                waitActivityIndicator.IsRunning = false;
                return;
            }
            waitActivityIndicator.IsRunning = false;

            ofertafotos = JsonConvert.DeserializeObject<List<OfertaFotos>>(result);
            FotosInmuebleListView.ItemsSource = ofertafotos;
            //imgSlider.Images = ofertafotos;
        }
    }
}