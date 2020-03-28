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
    public partial class RankingI : ContentPage
    {
        private List<RankI> ranki;
        public RankingI()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Inmobiliarias";
            //BtnRankingProfesional.Clicked += (sender, e) => BtnRankingProfesionalClick();
            RankingIListView.ItemTemplate = new DataTemplate(typeof(RankingICell));
            this.LoadRankingI();

            TapGestureRecognizer Search = new TapGestureRecognizer();
            Search.Tapped += (sender, e) => BtnStandarSearchClick();
            //BtnSearch.GestureRecognizers.Add(Search);

            //Fin Codigo Footer
            RankingIListView.ItemTapped += RankingIListView_ItemTapped;
            btnSearch.Clicked += (sender, e) => BtnSearchClick(txtSearch.Text);
        }
        private void BtnSearchClick(string Param)
        {
            Navigation.PushAsync(new BuscarInmobiliarias(Param, "1"));
        }

        private async void RankingIListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ranki = e.Item as RankI;
            await Navigation.PushAsync(new Inmobiliaria(ranki));
        }
        /*private void BtnEventosClick()
        {
            Navigation.PushAsync(new Eventos());
        }*/
        private void BtnStandarSearchClick()
        {
            Navigation.PushAsync(new Eventos());
        }
        /*private void BtnBuscarClick()
        {
            Navigation.PushAsync(new Filtros());
        }
        private void BtnRankingClick()
        {
            Navigation.PushAsync(new Ranking());
        }
        private void BtnChatClick()
        {
            Navigation.PushAsync(new MisListados("https://app.socialbusiness.com.co/chat"));
        }
        private void BtnPerfilClick()
        {
            //Navigation.PushAsync(new Perfil((String)App.Current.Properties["Codigo"]));
        }
        *//*
        private async void BtnRankingProfesionalClick()
        {
            Navigation.InsertPageBefore(new Ranking(), this);
            await Navigation.PopAsync().ConfigureAwait(false);
            await Navigation.PushAsync(new Ranking());
        }*/
        private async void LoadRankingI()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                //string url = string.Format("/api/RankingInmobiliario.php");
                string url = string.Format("/api/Inmobiliarias.php");
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

            ranki = JsonConvert.DeserializeObject<List<RankI>>(result);
            RankingIListView.ItemsSource = ranki;
        }
    }
}