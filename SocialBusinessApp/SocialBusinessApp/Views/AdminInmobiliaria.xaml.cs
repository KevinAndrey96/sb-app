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
	public partial class AdminInmobiliaria : ContentPage
	{
        private List<Rank> rank;
        public AdminInmobiliaria()
		{
			InitializeComponent();
            EquipoListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadRanking((String)App.Current.Properties["Codigo"]);
            EquipoListView.ItemTapped += EquipoListView_ItemTapped;
            btnAgregarProfesional.Clicked += (sender, e) => BtnAgregarProfesionalClick();
        }
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        private async void BtnAgregarProfesionalClick()
        {
            var values = new Dictionary<string, string>
                {
                   { "Agregar", txtCProfesional.Text},
                   { "Profesional", (String)App.Current.Properties["Codigo"]}

                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://app.socialbusiness.com.co/api/AgregarProfesionalE.php", content);
            try
            {

                var responseString = await response.Content.ReadAsStringAsync();
                Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
                
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                
                await Navigation.PopModalAsync();

            }
            catch (Exception e)
            {
                await DisplayAlert("Alerta", "" + e, "Ok");

            }
        }
        private async void EquipoListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var rank = e.Item as Rank;
            await Navigation.PushModalAsync(new OtroPerfil(rank));
            var answer = await DisplayAlert("Eliminar de inmobiliaria", "Desea eliminar este profesional de su inmobiliaria?", "Eliminar", "Cancelar");
            if (answer)
            {
                var values = new Dictionary<string, string>
                {
                   { "Eliminar", rank.Codigo.Substring(8)},
                   { "Profesional", (String)App.Current.Properties["Codigo"]}

                };
                //await DisplayAlert("", rank.Codigo + "-" + (String)App.Current.Properties["Codigo"], "Ok");
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://app.socialbusiness.com.co/api/EliminarProfesionalE.php", content);
                try
                {

                    var responseString = await response.Content.ReadAsStringAsync();
                    Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);

                    await DisplayAlert("Alerta", Rta.Mensaje, "Ok");

                    await Navigation.PopModalAsync();

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Alerta", "" + ex, "Ok");

                }
            }
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
                string url = string.Format("/api/Equipo.php?Profesional=" + code);
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
            EquipoListView.ItemsSource = rank;
        }
    }
}