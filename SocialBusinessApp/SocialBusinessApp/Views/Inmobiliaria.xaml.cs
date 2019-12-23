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
    public partial class Inmobiliaria : ContentPage
    {
        RankI ranki;
        private List<Rank> rank;
        public Inmobiliaria(RankI ranki)
        {
            InitializeComponent();
            this.ranki = ranki;

            TxtName.Text = ranki.Nombre;
            TxtPosition.Text = ranki.Posicion+" en ranking inmobiliario";
            FInmobiliaria.Source = ranki.Fotografia;
            TxtIntegrantes.Text = "Total de integrantes: " + ranki.Integrantes;
            TxtDepartments.Text = "Ciudad: "+ranki.Departamento;
            TxtNit.Text = "Nit. "+ranki.Nit;

            TxtScore.Text = ranki.Puntaje;

            btnInmuebles.Clicked += (sender, e) => BtnInmueblesClick(ranki.Nombre);
            //btnIntegrantes.Clicked += (sender, e) => BtnIntegrantesClick();
            IntegrantesListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadRanking(ranki.Nombre);
            IntegrantesListView.ItemTapped += IntegrantesListView_ItemTapped;
        }
        
        private async void BtnInmueblesClick(string name)
        {
            await Navigation.PushModalAsync(new OfertasInmobiliaria(name));
        }
        /*private void BtnIntegrantesClick()
        {
            //await Navigation.PushModalAsync(new OfertasUsuario(this.Code));
        }*/
        private async void IntegrantesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rank = e.Item as Rank;
            await Navigation.PushModalAsync(new OtroPerfil(rank));
        }
        private async void LoadRanking(string name)
        {
            // waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://app.socialbusiness.com.co")
                };
                string url = string.Format("/api/IntegrantesInmobiliaria.php?Inmobiliaria=" + name);
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
            IntegrantesListView.ItemsSource = rank;
        }

    }
}