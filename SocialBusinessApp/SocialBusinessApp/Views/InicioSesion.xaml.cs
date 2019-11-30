using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SocialBusinessApp.Views;
using SocialBusinessApp.Tabbeds;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioSesion : ContentPage
    {
        // Importar Nuget System.Net.Http
        // Importar Nuget Netonsoft.JSON
        private static HttpClient client = new HttpClient();
        private String AppUsuario;
        private String AppContrasena;
        Respuesta Rta;

        public InicioSesion()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //btnOlvidoClave.Clicked += (sender, e) => btnOlvidoClaveClick();
            /*
            TapGestureRecognizer SignUp = new TapGestureRecognizer();
            SignUp.Tapped += (sender, e) => BtnRegistroClick();
            BtnSignUp.GestureRecognizers.Add(SignUp);

            TapGestureRecognizer Login = new TapGestureRecognizer();
            Login.Tapped += (sender, e) => BtnIngresarClick();
            BtnLogin.GestureRecognizers.Add(Login);

            TapGestureRecognizer Password = new TapGestureRecognizer();
            Password.Tapped += (sender, e) => BtnOlvidoClaveClick();
            BtnPassword.GestureRecognizers.Add(Password);*/

        }


        //private void BtnOlvidoClaveClick()
        async void BtnOlvidoClaveClick(object sender, System.EventArgs e)
        {
            //Device.OpenUri(new Uri("https://app.socialbusiness.com.co/user/password-request.php"));
            await Navigation.PushAsync(new OlvidoClave());

        }
        protected override void OnAppearing()
        {
            if (App.Current.Properties.ContainsKey("Usuario"))
            {
                AppUsuario = (String)App.Current.Properties["Usuario"];
                AppContrasena = (String)App.Current.Properties["Contrasena"];
                SendTo();
            }
        }


        //private void BtnRegistroClick()
        async void BtnRegistroClick(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }


        //private void BtnIngresarClick()
        async void BtnIngresarClick(object sender, System.EventArgs e)
        {
            AppUsuario = txtEmail.Text;
            AppContrasena = txtContrasena.Text;
            
            SendTo();
        }
        private async void SendTo()
        {
            waitActivityIndicator.IsRunning = true;
            var values = new Dictionary<string, string>
                {
                   { "Dato1",  AppUsuario},
                   { "Dato2", AppContrasena }

                };
            var content = new FormUrlEncodedContent(values);
            
            try
            {
                var response = await client.PostAsync("https://app.socialbusiness.com.co/api/Login.php", content);
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
                waitActivityIndicator.IsRunning = false;
                GuardarSesion(AppUsuario, AppContrasena, Rta.Codigo, Rta.VIP);
                
                if (Rta.VIP.Equals("SI"))
                {
                    Navigation.InsertPageBefore(new TabbedPage1(), this);
                    await Navigation.PopAsync().ConfigureAwait(false);
                    await Navigation.PushAsync(new TabbedPage1());
                }else
                {
                    Navigation.InsertPageBefore(new TabbedPrincipal2(), this);
                    await Navigation.PopAsync().ConfigureAwait(false);
                    await Navigation.PushAsync(new TabbedPrincipal2());
                }
            }
            else
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
            }
            
        }

        private void GuardarSesion(String Usuario, String Contrasena, String Codigo, String VIP)
        {
            App.Current.Properties["Codigo"] = Codigo;
            App.Current.Properties["Usuario"] = Usuario;
            App.Current.Properties["VIP"] = VIP;
            App.Current.Properties["Contrasena"] = Contrasena;
            
        }
    }
}           