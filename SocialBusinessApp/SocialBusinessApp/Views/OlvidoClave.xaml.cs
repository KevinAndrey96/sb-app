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
    public partial class OlvidoClave : ContentPage
    {
        private static HttpClient client = new HttpClient();
        public OlvidoClave()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btnOlvidoClave.Clicked += (sender, e) => BtnOlvidoClaveClick();
        }
        private async void BtnOlvidoClaveClick()
        {
            var values = new Dictionary<string, string>
                {
                   { "Correo", txtEmail.Text }
                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://app.socialbusiness.com.co/api/OlvidoClave.php", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Respuesta Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            if (Rta.Estado.Equals("Si"))
            {
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                await Navigation.PopAsync().ConfigureAwait(false);
            }
            else
            {
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");

            }
        }
    }
}