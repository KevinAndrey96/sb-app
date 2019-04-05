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
    public partial class Constructoras : ContentPage
    {
        public Constructoras()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Constructoras";

            OfertasListView.ItemTemplate = new DataTemplate(typeof(OfertaCell));
            this.LoadOfertas();
            OfertasListView.ItemTapped += OfertasListView_ItemTapped;
        }
        private List<Oferta> ofertas;
        private async void LoadOfertas()
        {
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                string url = string.Format("/api/MisOfertas.php?User=1");
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            ofertas = JsonConvert.DeserializeObject<List<Oferta>>(result);
            OfertasListView.ItemsSource = ofertas;
        }
        private async void OfertasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var oferta = e.Item as Oferta;
            await Navigation.PushModalAsync(new MyPlace(oferta, true));
        }
    }
}