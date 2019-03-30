using Newtonsoft.Json;
using SocialBusinessApp.Cells;
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
    public partial class Ranking : ContentPage
    {
        private List<Rank> rank;
        public Ranking()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Profesionales";
            //this.Icon = "iconoranking";
            //BtnRankingInmobiliarias.Clicked += (sender, e) => BtnRankingInmobiliariasClick();
            //RankingListView.ItemTemplate = new DataTemplate(typeof(RankingICell));
            

            /*TapGestureRecognizer Search = new TapGestureRecognizer();
            Search.Tapped += (sender, e) => BtnStandarSearchClick();
            BtnSearch.GestureRecognizers.Add(Search);
            */
            //Fin Codigo Footer

            RankingListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadRanking();
            RankingListView.ItemTapped += RankingListView_ItemTapped;

            btnSearch.Clicked += (sender, e) => BtnSearchClick(txtSearch.Text);
        }
        private void BtnSearchClick(string Param)
        {
            Navigation.PushModalAsync(new BuscarProfesionales(Param,"1"));
        }

        private async void RankingListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rank = e.Item as Rank;
            await Navigation.PushModalAsync(new OtroPerfil(rank));
        }
        private async void BtnRankingInmobiliariasClick()
        {
            Navigation.InsertPageBefore(new RankingI(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
            await Navigation.PushAsync(new RankingI());
        }
        private async void LoadRanking()
        {
           // waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                string url = string.Format("/api/RankingProfesional.php");
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

            rank = JsonConvert.DeserializeObject<List<Rank>>(result);
            RankingListView.ItemsSource = rank;
        }
    }
}