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
    public partial class BuscarProfesionales : ContentPage
    {
        private List<Rank> rank;
        public BuscarProfesionales(string Param)
        {
            InitializeComponent();
            ProfesionalesListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadOfertas2(Param);
            ProfesionalesListView.ItemTapped += ProfesionalesListView_ItemTapped;
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
                string url = string.Format("/api/BuscarProfesionales.php?Param=" + Param);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            rank = JsonConvert.DeserializeObject<List<Rank>>(result);
            ProfesionalesListView.ItemsSource = rank;
        }
        private async void ProfesionalesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rank = e.Item as Rank;
            await Navigation.PushModalAsync(new OtroPerfil(rank));
        }
    }
}