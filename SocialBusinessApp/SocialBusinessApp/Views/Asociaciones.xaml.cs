using Newtonsoft.Json;
using SocialBusinessApp.Cells;
using SocialBusinessApp.Models;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Asociaciones : ContentPage
    {
        private List<Asociacion> Asociacion1;
        public Asociaciones()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Asociaciones";

            AsociacionesListView.ItemTemplate = new DataTemplate(typeof(AsociacionCell));
            this.LoadAll();

            TapGestureRecognizer Search = new TapGestureRecognizer();
            Search.Tapped += (sender, e) => BtnStandarSearchClick();
            BtnSearch.GestureRecognizers.Add(Search);

            AsociacionesListView.ItemTapped += AsociacionesListView_ItemTapped;
        }

        private async void AsociacionesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var asoc= e.Item as Asociacion;
            await Navigation.PushModalAsync(new VerAsociacion(asoc));
        }
        private void BtnStandarSearchClick()
        {
            DisplayAlert("Social Business", "Error", "Ok");
        }
        private async void LoadAll()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://app.socialbusiness.com.co");
                string url = string.Format("/api/Asociaciones.php");
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
                //await DisplayAlert("JSON", result, "Vale");
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            Asociacion1 = JsonConvert.DeserializeObject<List<Asociacion>>(result);
            AsociacionesListView.ItemsSource = Asociacion1;
        }
    }
}