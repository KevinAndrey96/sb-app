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
    public partial class Equipo : ContentPage
    {
        private List<Rank> rank;
        public Equipo(string code)
        {
            InitializeComponent();
            EquipoListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadRanking(code);
            EquipoListView.ItemTapped += EquipoListView_ItemTapped;
        }
        private async void EquipoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rank = e.Item as Rank;
            await Navigation.PushModalAsync(new OtroPerfil(rank));
        }
        private async void LoadRanking(string code)
        {
            // waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                string url = string.Format("/api/Equipo.php?Profesional="+code.Substring(8));
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
                //await DisplayAlert("hola", result, url);
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            rank = JsonConvert.DeserializeObject<List<Rank>>(result);
            if (rank.Count == 0)
            {
                await DisplayAlert("Alerta", "No hay resultados disponibles", "Ok");
            }
            EquipoListView.ItemsSource = rank;
        }
    }
}