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
    public partial class MisOfertas : ContentPage
    {
        private List<Oferta> ofertas;
        public MisOfertas()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Mis ofertas";

            OfertasListView.ItemTemplate = new DataTemplate(typeof(OfertaCell));
            this.LoadOfertas();
            OfertasListView.ItemTapped += OfertasListView_ItemTapped;
        }

        private async void LoadOfertas()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                var code = (String)App.Current.Properties["Codigo"];
                
                string url = string.Format("/api/MisOfertas.php?User="+code);
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