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
	public partial class Eventos : ContentPage
	{
        private List<Evento> eventos;
        public Eventos ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            this.Title = "Próximos";
            //this.Icon = "iconoeventos";
            EventosListView.ItemTemplate = new DataTemplate(typeof(EventoCell));
            this.LoadEventos();

            EventosListView.ItemTapped += EventosListView_ItemTapped;
        }
        private async void EventosListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var even = e.Item as Evento;
            await Navigation.PushModalAsync(new VerEvento(even, true, false));
        }
        private async void LoadEventos()
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("https://app.socialbusiness.com.co")
                };
                string url = string.Format("/api/Eventos.php?Profesional="+ (String)App.Current.Properties["Codigo"]);
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

            eventos = JsonConvert.DeserializeObject<List<Evento>>(result);
            EventosListView.ItemsSource = eventos;
        }
    }
}