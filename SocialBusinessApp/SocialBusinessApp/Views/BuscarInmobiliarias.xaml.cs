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
    public partial class BuscarInmobiliarias : ContentPage
    {
        private List<RankI> ranki;
        public BuscarInmobiliarias(string Param)
        {
            InitializeComponent(); InmobiliariasListView.ItemTemplate = new DataTemplate(typeof(RankingICell));
            this.LoadOfertas2(Param);
            InmobiliariasListView.ItemTapped += InmobiliariasListView_ItemTapped;
            btnSearch.Clicked += (sender, e) => BtnSearchClick();
        }
        private void BtnSearchClick()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new Filtros());
        }
        private async void LoadOfertas2(string Param)
        {
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/BuscarInmobiliarias.php?Param=" + Param);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            ranki = JsonConvert.DeserializeObject<List<RankI>>(result);
            InmobiliariasListView.ItemsSource = ranki;
        }
        private async void InmobiliariasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ranki = e.Item as RankI;
            await Navigation.PushModalAsync(new Inmobiliaria(ranki));
        }
    }
}