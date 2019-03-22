using Newtonsoft.Json;
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
    public partial class CambiarContrasena : ContentPage
    {
        private static HttpClient Client = new HttpClient();
        public CambiarContrasena()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btnCambiarContrasena.Clicked += (sender, e) => BtnCambiarContrasenaClick();
        }
        private async void BtnCambiarContrasenaClick()
        {
            if (txtContraNue.Text.Equals(txtContraNue2.Text))
            {
                SendToAsync2();
            }
            else
            {
                await DisplayAlert("Alerta", "Las contraseñas no coinciden, por favor verifiquelas", "Ok");
            }
            
        }
        private async void SendToAsync2()
        {
            var values = new Dictionary<string, string>
                {
                   { "Dato1",  (String)App.Current.Properties["Usuario"] },
                   { "Dato2", txtContraAct.Text},
                   { "Dato3", txtContraNue.Text}
                };
            var content = new FormUrlEncodedContent(values);

            var response = await Client.PostAsync("https://app.socialbusiness.com.co/api/ChangePassword.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Respuesta Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
            //Navigation.InsertPageBefore(new MLS(), this);
            //await Navigation.PopAsync().ConfigureAwait(false);
            await Navigation.PopModalAsync();
        }
    }
}