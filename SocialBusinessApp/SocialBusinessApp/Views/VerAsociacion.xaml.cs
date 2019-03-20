
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SocialBusinessApp.Cells;
using SocialBusinessApp.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerAsociacion : ContentPage
    {
        Asociacion asoc;
        private List<Rank> rank;
        public VerAsociacion(Asociacion asoc)
        {
            InitializeComponent();
            this.asoc= asoc;
            TxtName.Text = asoc.Nombre;
            TxtDepartment.Text = "Departamento: "+asoc.Departamento;
            TxtAddress.Text = "Dirección: "+asoc.Direccion;
            TxtPhone.Text = "Teléfono: "+asoc.Telefono;
            TxtEmail.Text = "Email: "+asoc.Correo;
            TxtAffiliate.Text = asoc.Afiliados+" afiliados";
            FAsociacionF.Source = asoc.Fotografia;

            IntegrantesListView.ItemTemplate = new DataTemplate(typeof(RankingCell));
            this.LoadRanking(asoc.Id);
            IntegrantesListView.ItemTapped += IntegrantesListView_ItemTapped;
        }
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
                string url = string.Format("/api/IntegrantesAsociacion.php?Asociacion=" + name);
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