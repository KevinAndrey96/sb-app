using Newtonsoft.Json;
using SocialBusinessApp.Cells;
using SocialBusinessApp.Models;
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
	public partial class Comentarios : ContentPage
	{
        private List<Comentario> Comentario1;
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        public Comentarios (string code)
		{
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Comentarios";

            ComentariosListView.ItemTemplate = new DataTemplate(typeof(ComentarioCell));
            this.LoadAll(code);

            /*TapGestureRecognizer Search = new TapGestureRecognizer();
            Search.Tapped += (sender, e) => BtnStandarSearchClick();
            BtnSearch.GestureRecognizers.Add(Search);
            */
            //AsociacionesListView.ItemTapped += AsociacionesListView_ItemTapped;
            btnComentar.Clicked += (sender, e) => btnComentarClick(code);

        }
        private async void btnComentarClick(string code)
        {
            var values = new Dictionary<string, string>
                {
                   { "Autor",  (String)App.Current.Properties["Codigo"]},
                   { "Comentario",  Comentario.Text},
                   { "Profesional", code }
                };
            var content = new FormUrlEncodedContent(values);

            try
            {
                var response = await client.PostAsync("https://app.socialbusiness.com.co/api/RealizarComentario.php", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            }
            catch (Exception)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            if (Rta.Estado.Equals("Si"))
            {
                await DisplayAlert("¡Éxito!", Rta.Mensaje, "Ok");
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
            }
        }
        private async void SendTo()
        {
            //waitActivityIndicator.IsRunning = true;
            

        }
        /*private async void ComentariosListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var asoc = e.Item as Asociacion;
            await Navigation.PushModalAsync(new VerAsociacion(asoc));
        }*/

        private async void LoadAll(String code)
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/Comentarios.php?Profesional="+code.Substring(8));
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
                //await DisplayAlert("JSON", result, "Vale");
                //await DisplayAlert("hola", result, url);
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            Comentario1 = JsonConvert.DeserializeObject<List<Comentario>>(result);
            ComentariosListView.ItemsSource = Comentario1;
        }
    }
}