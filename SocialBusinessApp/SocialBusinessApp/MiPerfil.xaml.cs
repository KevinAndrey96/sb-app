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
    public partial class MiPerfil : ContentPage
    {
        private static HttpClient client = new HttpClient();

        private Usuario User;

        public MiPerfil()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            btnActualizarPerfil.Clicked += (sender, e) => btnActualizarPerfilClick();            
        }
        protected override void OnAppearing()
        {
            TraerDatosAsync();
        }
        private void btnActualizarPerfilClick()
        {
            SendToAsync();
        }
        private async void TraerDatosAsync()
        {
            var values = new Dictionary<string, string>
                {
                   //{ "Dato1",  "kaherreras@unal.edu.co"}
                   { "Dato1",  (String)App.Current.Properties["Usuario"] }                   
                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://app.socialbusiness.com.co/api/Profile.php", content);
            //DisplayAlert("Alert", "You have been alerted 2", "OK");
            var responseString = await response.Content.ReadAsStringAsync();
            User = JsonConvert.DeserializeObject<Usuario>(responseString);
            BindingContext = User;
        }
        private async void SendToAsync()
        {
            var values = new Dictionary<string, string>
                {
                   //{ "Dato1",  "kaherreras@unal.edu.co"},
                   { "Dato1",  (String)App.Current.Properties["Usuario"] },
                   { "Dato2", txtNombres.Text},
                   { "Dato3", txtApellidos.Text},
                   { "Dato4", txtCiudad.Text},
                   { "Dato5", txtPais.Text},
                   { "Dato6", txtGenero.Items[txtGenero.SelectedIndex]},
                   { "Dato7", txtNAno.Text},
                   { "Dato8", txtNMes.Items[txtNMes.SelectedIndex]},
                   { "Dato9", txtNDia.Text}
                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://app.socialbusiness.com.co/api/SetProfile.php", content);
            var responseString = await response.Content.ReadAsStringAsync();
            Respuesta Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
            
        }

    }
    
}