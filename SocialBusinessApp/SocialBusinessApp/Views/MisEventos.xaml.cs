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
    public partial class MisEventos : ContentPage
    {
        private List<Evento> eventos2;
        public MisEventos()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Mis Eventos";
            EventosListView2.ItemTemplate = new DataTemplate(typeof(EventoCell));
            this.LoadEventos2();
            EventosListView2.ItemTapped += EventosListView_ItemTapped;
        }
        private async void EventosListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var even = e.Item as Evento;
            await Navigation.PushModalAsync(new VerEvento(even, false, true));
        }
        private async void LoadEventos2()
        {
            //waitActivityIndicator.IsRunning = true;
            string result2;
            try
            {
                HttpClient client2 = new HttpClient();
                var AppCodigo = (String)App.Current.Properties["Codigo"];
                client2.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/MisEventos.php?id="+AppCodigo);
                var response = await client2.GetAsync(url);
                result2 = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            eventos2 = JsonConvert.DeserializeObject<List<Evento>>(result2);
            EventosListView2.ItemsSource = eventos2;
        }
    }
}