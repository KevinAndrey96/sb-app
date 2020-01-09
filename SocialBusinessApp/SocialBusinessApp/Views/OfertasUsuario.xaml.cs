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
    public partial class OfertasUsuario : ContentPage
    {
        private List<Oferta> ofertas;
        public OfertasUsuario(string Code)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Ofertas";


            OfertasListView2.ItemTemplate = new DataTemplate(typeof(OfertaCell));
            this.LoadOfertas2(Code);
            OfertasListView2.ItemTapped += OfertasListView_ItemTapped;
        }

        private async void LoadOfertas2(string Code)
        {
            waitActivityIndicator2.IsRunning = true;
            string result;
            try
            {

                

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                //var code = (String)App.Current.Properties["Codigo"];
                //await DisplayAlert("Codigo", code, "Ok");
                string url = string.Format("/api/MisOfertas.php?User=" + Code.Substring(8));
                //string url = string.Format("/api/MisOfertas.php?User=181505");

                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                waitActivityIndicator2.IsRunning = false;
                return;
            }
            waitActivityIndicator2.IsRunning = false;

            ofertas = JsonConvert.DeserializeObject<List<Oferta>>(result);
            OfertasListView2.ItemsSource = ofertas;
        }
        private async void OfertasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var oferta = e.Item as Oferta;
            await Navigation.PushModalAsync(new MyPlace(oferta,false));
        }
    }
}