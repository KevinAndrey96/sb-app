using Newtonsoft.Json;
using SocialBusinessApp.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscarOfertas : ContentPage
    {
        private List<Oferta> ofertas;
        public BuscarOfertas(string Param, string op)
        {
            InitializeComponent();
            OfertasListView2.ItemTemplate = new DataTemplate(typeof(OfertaCell));
            if(op=="2")
            {
                this.LoadOfertas2(Param);//Estandar
            }else
            {
                this.LoadOfertas1(Param);//Avanzada
            }
            
            OfertasListView2.ItemTapped += OfertasListView_ItemTapped;
            btnSearch.Clicked += (sender, e) => BtnSearchClick();
        }
        private void BtnSearchClick()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Filtros());
        }
        private async void LoadOfertas1(string Param)
        {
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/BusquedaAvanzadaOfertas.php?" + Param);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            ofertas = JsonConvert.DeserializeObject<List<Oferta>>(result);
            OfertasListView2.ItemsSource = ofertas;
        }
        private async void LoadOfertas2(string Param)
        {
            //waitActivityIndicator2.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                //var code = (String)App.Current.Properties["Codigo"];
                //await DisplayAlert("Codigo", code, "Ok");
                string url = string.Format("/api/BuscarOfertas.php?Param=" + Param);
                //string url = string.Format("/api/MisOfertas.php?User=181505");

                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator2.IsRunning = false;
                return;
            }
            //waitActivityIndicator2.IsRunning = false;

            ofertas = JsonConvert.DeserializeObject<List<Oferta>>(result);
            OfertasListView2.ItemsSource = ofertas;
        }
        private async void OfertasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var oferta = e.Item as Oferta;
            await Navigation.PushModalAsync(new Place(oferta));
        }
    }
}