using Newtonsoft.Json;
using SocialBusinessApp.Cells;
using SocialBusinessApp.Models;
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
    public partial class BuscarFranquicias : ContentPage
    {
        private List<Asociacion> Asociacion1;
        public BuscarFranquicias(string Param)
        {
            InitializeComponent();
            FranquiciasListView.ItemTemplate = new DataTemplate(typeof(AsociacionCell));
            this.LoadOfertas2(Param);
            FranquiciasListView.ItemTapped += FranquiciasListView_ItemTapped;
            //btnSearch.Clicked += (sender, e) => BtnSearchClick();
        }
        /*private void BtnSearchClick()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Filtros());
        }*/
        private async void LoadOfertas2(string Param)
        {
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/BuscarFranquicias.php?Param=" + Param);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            Asociacion1 = JsonConvert.DeserializeObject<List<Asociacion>>(result);
            FranquiciasListView.ItemsSource = Asociacion1;
        }
        private async void FranquiciasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var asoc = e.Item as Asociacion;
            await Navigation.PushModalAsync(new VerAsociacion(asoc));
        }
    }
}