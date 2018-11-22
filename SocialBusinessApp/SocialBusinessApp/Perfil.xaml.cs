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
    public partial class Perfil : ContentPage
    {
        private static HttpClient client = new HttpClient();
        PerfilUsuario PU;
        private String Codigo;

        public Perfil()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Perfil";
            this.Icon = "iconoperfil";
            DisplayAlert("uno", "dos", "tres");
            this.Codigo = (String)App.Current.Properties["Codigo"];
            Codigo =(String)App.Current.Properties["Codigo"];
            //btnEditarP.Clicked += (sender, e) => btnEditarPClick();
            //btnCambiarC.Clicked += (sender, e) => btnCambiarCClick();
            //btnOfertas.Clicked += (sender, e) => btnOfertasClick();
            //btnPagar.Clicked += (sender, e) => btnPagarClick();
            //this.Codigo = Code;
            /*if(Code!= (String)App.Current.Properties["Codigo"])
            {
                btnEditarP.IsVisible = false;
                btnCambiarC.IsVisible = false;
                btnOfertas.IsVisible = false;
                btnPagar.IsVisible = false;
            }*/
            this.LoadUsuario();
        }
        private void BtnEditarPClick()
        {
            Navigation.PushAsync(new MiPerfil());
        }
        private void BtnCambiarCClick()
        {
            Navigation.PushAsync(new CambiarContrasena());
        }
        private void BtnOfertasClick()
        {
            //Navigation.PushAsync(new MisListados());
        }
        private void BtnPagarClick()
        {
            Navigation.PushAsync(new MisListados("https://gateway.payulatam.com/ppp-web-gateway/page-redirect.zul"));
        }
        private async void LoadUsuario()
        {
            waitActivityIndicator.IsRunning = true;
            Codigo=(String)App.Current.Properties["Codigo"];
            await DisplayAlert("Alerta", "Su código profesional es: "+Codigo, "Ok");
            var values = new Dictionary<string, string>
                {
                   { "Dato1",  Codigo}
                };
            var content = new FormUrlEncodedContent(values);

            try
            {
                var response = await client.PostAsync("http://app.socialbusiness.com.co/api/Perfil.php", content);
                var responseString = await response.Content.ReadAsStringAsync();
                PU = JsonConvert.DeserializeObject<PerfilUsuario>(responseString);
            }
            catch (Exception)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                return;
            }
            waitActivityIndicator.IsRunning = false;
            TxtName.Text = PU.Nombre;
            TxtInmobiliaria.Text = "Inmobiliaria: "+PU.Inmobiliaria;
            TxtNit.Text = "Nit. "+PU.Nit;
            TxtCelular.Text = "Celular: "+PU.Celular;
            TxtCorreo.Text = "Correo: "+PU.Correo;
            TxtCodigo.Text = "Código: " + PU.Codigo;
            FPerfil.Source=PU.FotografiaPersonal;
            FInmobiliaria.Source = PU.FotografiaInmobiliaria;

            TxtPosicion.Text = "Posición: " + PU.Posicion;
            TxtPuntaje.Text = "Puntaje: " + PU.Puntaje;


        }
    }
}