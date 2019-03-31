using Newtonsoft.Json;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPlace : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();

        private Oferta oferta;
        private List<OfertaFotos> ofertafotos;
        public string PlaceID;
        private string Lat;
        private string Long;
        public MyPlace(Oferta oferta, Boolean mio)
        {
           
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            this.LoadFotos();
            this.oferta = oferta;

            btnUbicacion.Clicked += (sender, e) => btnUbicacionClickAsync();
            btnGaleria.Clicked += (sender, e) => btnGaleriaF();
            //btnEditar.Clicked += (sender, e) => btnEditarClick();
            //btnEliminar.Clicked += (sender, e) => btnEliminarClick();
            //btnGaleria.Clicked += (sender, e) => btnGaleriaClickAsync();

            btnYoutube.Clicked += (sender, e) => BtnYoutubeClick(oferta.Youtube);
            btnCompartir.Clicked += (sender, e) => BtnCompartirClick(oferta.ID,oferta.Nombre);

            


            txtCategoria.Text = "Categoria: " + oferta.Categoria;
            if (oferta.Terceria == "Si")
            {
                txtTerceria.IsVisible = true;
            }
            else
            {
                txtTerceria.IsVisible = false;
            }
            if (oferta.Youtube != "")
            {
                btnYoutube.IsVisible = true;
                btnYoutube.IsEnabled = true;
            }
            else
            {
                btnYoutube.IsVisible = false;
                btnYoutube.IsEnabled = false;
            }

            TxtNombrePlace.Text = oferta.Nombre;
            TxtPrecio.Text = "Precio: " + oferta.Precio;
            TxtDireccion.Text = "Dirección: " + oferta.Direccion;
            TxtCiudad.Text = "Ciudad: " + oferta.Ciudad;
            TxtBarrio.Text = "Barrio: " + oferta.Barrio;
            TxtDepartamento.Text = "Departamento: " + oferta.Departamento;
            TxtTipo.Text = "Tipo: " + oferta.Tipo;
            TxtHabitaciones.Text = "Habitaciones: " + oferta.Habitaciones;
            TxtBanos.Text = "Baños: " + oferta.Banos;
            TxtParqueaderos.Text = "Parqueaderos: " + oferta.Parqueaderos;
            TxtEstrato.Text = "Estrato: " + oferta.Estrato;
            TxtArea.Text = "Area: " + oferta.Area;
            TxtAntiguedad.Text = "Antiguedad: " + oferta.Antiguedad;
            TxtUbicacion.Text = "Ubicación: " + oferta.Ubicacion;// + oferta.Lat + oferta.Long;
            TxtDescripcion.Text = oferta.Descripcion;
            FPlace.Source = oferta.Fotografia;
            Lat = oferta.Lat;
            Long = oferta.Long;
            DisplayAlert("uno", "Dos: " + oferta.Lat, "Tres" + oferta.Long);
            PlaceID = oferta.ID;

            if(mio)
            {
                btnEditar.IsEnabled = true;
                btnEditar.IsVisible= true;
                btnEliminar.IsEnabled = true;
                btnEliminar.IsVisible = true;
            }else
            {
                btnEditar.IsEnabled = false;
                btnEditar.IsVisible = false;
                btnEliminar.IsEnabled = false;
                btnEliminar.IsVisible = false;
            }

            btnEditar.Clicked += (sender, e) => BtnEditarClick(oferta.ID);
            btnEliminar.Clicked += (sender, e) => BtnEliminarClick();

            this.PlaceID = oferta.ID;
            //FotosInmuebleListView.ItemTemplate = new DataTemplate(typeof(FotosCell));

            this.LoadFotos();



        }
        private async void BtnYoutubeClick(string url)
        {
            await Navigation.PushModalAsync(new MisListados(url));
        }
        private async void BtnCompartirClick(string placeid,string nombre)
        {
            await CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = "Te invito a darle un vistazo a este inmueble que encontré en Social Business: "+nombre,
                Title = "Inmueble Social Business",
                Url = "https://app.socialbusiness.com.co/place/"+placeid
            });
        }
        private async void BtnEditarClick(string placeid)
        {
            await Navigation.PushModalAsync(new EditarOferta(placeid));
        }
        private async void btnUbicacionClickAsync()
        {
            await DisplayAlert("", oferta.Lat + "/" + oferta.Long,"Ok");
            await Navigation.PushModalAsync(new Mapa(oferta.Lat, oferta.Long, oferta.Nombre, oferta.Direccion));
            //await Navigation.PushModalAsync(new CustomMap());
        }
        
        private async void btnGaleriaF()
        {
            await Navigation.PushModalAsync(new MisListados("https://app.socialbusiness.com.co/gallery/?id=" + PlaceID));
        }
        
        private async void BtnEliminarClick()
        {
            var answer = await DisplayAlert("Eliminar", "¿Está seguro?", "Si", "No");
            if (answer)
            {
                Delete();
                await DisplayAlert("Correcto", "Se ha eliminado el inmueble con exito", "Ok");
                await Navigation.PopModalAsync();
            }
        }

        private async void btnGaleriaClickAsync()
        {
            await Navigation.PushModalAsync(new Gallery());
        }
        private async void LoadFotos()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();

                string url = string.Format("https://app.socialbusiness.com.co/api/Fotos.php?placeid=" + PlaceID);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            ofertafotos = JsonConvert.DeserializeObject<List<OfertaFotos>>(result);
            //FotosInmuebleListView.ItemsSource = ofertafotos;
            //imgSlider.Images = ofertafotos;
        }

        private async void Delete()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                var code = (String)App.Current.Properties["Codigo"];
                string url = string.Format("https://app.socialbusiness.com.co/api/DeletePlace.php?placeid=" + PlaceID +"&userid="+code);
                var response = await client.GetAsync(url);
                //result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }

            //imgSlider.Images = ofertafotos;
        }
    }
}