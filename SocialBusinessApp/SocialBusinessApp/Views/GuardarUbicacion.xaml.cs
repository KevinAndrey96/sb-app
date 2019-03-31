using Newtonsoft.Json;
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
    public partial class GuardarUbicacion : ContentPage
    {
        private static HttpClient Client = new HttpClient();
        public GuardarUbicacion(string lat, string lon, string placeid)
        {
            InitializeComponent();
            SendTo(lat, lon, placeid);
        }
        private async void SendTo(string lat, string lon, string placeid)
        {
            var values = new Dictionary<string, string>
                {
                   { "Profesional",  (String)App.Current.Properties["Codigo"] },
                   { "Oferta",  placeid },
                   { "Lat", lat},
                   { "Lon", lon}
                };
            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("https://app.socialbusiness.com.co/api/EditarUbicacion.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Respuesta Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
            //Navigation.InsertPageBefore(new MLS(), this);
            //await Navigation.PopAsync().ConfigureAwait(false);
            await Navigation.PopModalAsync();
        }
    }
}