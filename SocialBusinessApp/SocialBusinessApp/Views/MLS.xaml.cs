using Newtonsoft.Json;
using Plugin.Permissions.Abstractions;
using SocialBusinessApp.Cells;
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
    public partial class MLS : ContentPage
    {
        private List<Oferta> ofertas;
        public MLS()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Multiple Listing Service (MLS)";

            

            //this.Icon = "ranking.png";
            /*
            TapGestureRecognizer Ranking = new TapGestureRecognizer();
            Ranking.Tapped += (sender, e) => BtnRankingClick();
            BtnTheRanking.GestureRecognizers.Add(Ranking);

            TapGestureRecognizer Chat = new TapGestureRecognizer();
            Chat.Tapped += (sender, e) => BtnChatClick();
            BtnTheChat.GestureRecognizers.Add(Chat);

            TapGestureRecognizer Events = new TapGestureRecognizer();C:\Users\Kevin\Desktop\SocialBusiness Files\SocialBusinessApp\SocialBusinessApp.iOS\Resources\ItunesArtwork@2x.png
            Events.Tapped += (sender, e) => BtnEventosClick();
            BtnEvents.GestureRecognizers.Add(Events);
            */

            TapGestureRecognizer Search = new TapGestureRecognizer();
            Search.Tapped += (sender, e) => BtnStandarSearchClick();
            BtnSearch.GestureRecognizers.Add(Search);

            TapGestureRecognizer AddOfert = new TapGestureRecognizer();
            AddOfert.Tapped += (sender, e) => BtnAgregarOfertaClick();
            BtnAddOfert.GestureRecognizers.Add(AddOfert);

            TapGestureRecognizer AdvancedSearch = new TapGestureRecognizer();
            AdvancedSearch.Tapped += (sender, e) => BtnBuscarClick();
            BtnAdvancedSearch.GestureRecognizers.Add(AdvancedSearch);

            //BtnAgregarOferta.Clicked += (sender, e) => btnAgregarOfertaClick();
            //BtnSalir.Clicked += (sender, e) => btnSalirClick();
            //BtnRanking.Clicked += (sender, e) => btnRankingClick();
            // BtnBuscar.Clicked += (sender, e) => btnBuscarClick();
            //BtnPerfil.Clicked += (sender, e) => btnPerfilClick();
            //BtnChat.Clicked += (sender, e) => btnChatClick();
            //BtnEventos.Clicked += (sender, e) => btnEventosClick();
            OfertasListView.ItemTemplate = new DataTemplate ( typeof(OfertaCell) );
            this.LoadOfertas();
            OfertasListView.ItemTapped += OfertasListView_ItemTapped;
        }
        private void BtnEventosClick()
        {
            Navigation.PushAsync(new Eventos());
        }
        private void OnClick_u()
        {
            Navigation.PushAsync(new Eventos());
        }
        private void BtnStandarSearchClick()
        {
            Navigation.PushAsync(new Eventos());
        }
        private async void OfertasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var oferta = e.Item as Oferta;
            await Navigation.PushModalAsync(new Place(oferta));
        }
        private void BtnAgregarOfertaClick()
        {
            Navigation.PushModalAsync(new Listado());
        }
        private void BtnBuscarClick()
        {
            Navigation.PushAsync(new Filtros());
        }
        private void BtnRankingClick()
        {
            Navigation.PushAsync(new Ranking());
        }
        private void BtnChatClick()
        {
            Navigation.PushAsync(new MisListados("http://app.socialbusiness.com.co/chat"));
        }
        private void BtnPerfilClick()
        {
            //Navigation.PushAsync(new Perfil((String)App.Current.Properties["Codigo"]));
        }
        private void BtnSalirClick()
        {
            EliminarSesion();
            //Navigation.PushAsync(new InicioSesion());
            Navigation.InsertPageBefore(new InicioSesion(), this);
            Navigation.PopAsync().ConfigureAwait(false);
        }
        private void EliminarSesion()
        {
            Xamarin.Forms.Application.Current.Properties.Clear();
        }
        private async void LoadOfertas()
        {
            waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://app.socialbusiness.com.co");
                string url = string.Format("/api/Ofertas.php");
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }catch(Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                waitActivityIndicator.IsRunning = false;
                return;
            }
            waitActivityIndicator.IsRunning = false;

            ofertas = JsonConvert.DeserializeObject<List<Oferta>>(result);
            OfertasListView.ItemsSource = ofertas;
        }

    }
}