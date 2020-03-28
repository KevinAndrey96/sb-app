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
    public partial class HistoricoEventos : ContentPage
    {
        private List<Evento> eventos1;
        public HistoricoEventos()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Histórico";
            EventosListView1.ItemTemplate = new DataTemplate(typeof(EventoCell));
            this.LoadEventos1();
            EventosListView1.ItemTapped += EventosListView_ItemTapped;
        }
        private async void EventosListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var even = e.Item as Evento;
            await Navigation.PushModalAsync(new VerEvento(even, false, false));
        }
        private async void LoadEventos1()
        {
            //waitActivityIndicator.IsRunning = true;
            string result1;
            try
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/HistoricoEventos.php");
                var response = await client1.GetAsync(url);
                result1 = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            eventos1 = JsonConvert.DeserializeObject<List<Evento>>(result1);
            EventosListView1.ItemsSource = eventos1;
        }
    }
}