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
    public partial class Registro : ContentPage
    {
        private static HttpClient client = new HttpClient();
        
        public Registro()
        {
            InitializeComponent();
            btnRegistrarmeRegistro.Clicked += (sender, e) => AlistaDatos();
        }
        private void AlistaDatos()
        {
            if (txtContrasena.Text.Equals(txtContrasena2.Text))
                SendTo();
            else
                DisplayAlert("Alerta", "Las Contraseñas no coinciden, por favor verifique", "Ok");
        }
        private async void SendTo()
        {
            var values = new Dictionary<string, string>
                {
                   { "Dato1", txtNombres.Text },
                   { "Dato2", txtApellidos.Text },
                   { "Dato3", txtEmail.Text },
                   //{ "TelefonoUsuario", txtTelefono.Text },
                   //{ "DocumentoUsuario", txtDocumento.Text },
                   { "Dato4", txtContrasena.Text },
                   //{ "Contrasena2", txtContrasena2.Text }

                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://app.socialbusiness.com.co/api/SignUp.php", content);

            var responseString = await response.Content.ReadAsStringAsync();
            Respuesta Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
            if (Rta.Estado.Equals("Si"))
            {
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                Navigation.InsertPageBefore(new InicioSesion(), this);
                await Navigation.PopAsync().ConfigureAwait(false);

            }
            else
            {
                await DisplayAlert("Ups", "Algo ha sucedido intentalo de nuevo", "Ok");

            }
        }
    }
}