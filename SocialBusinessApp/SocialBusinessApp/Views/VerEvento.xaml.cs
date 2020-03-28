using Newtonsoft.Json;
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
	public partial class VerEvento : ContentPage
	{
        Evento even;
		public VerEvento (Evento even, Boolean Disponible, Boolean Cancelable)
		{
			InitializeComponent ();
            this.even = even;

            TxtNameE.Text = even.Nombre;
            TxtDepartmentE.Text = even.Departamento;
            TxtCiudadE.Text = even.Ciudad;
            TxtAddressE.Text = even.Direccion;
            FEvento.Source = even.Fotografia;

            TxtDescripcionE.Text = even.Descripcion;
            TxtHorarioE.Text = "Desde: "+even.HoraI+" hasta: "+even.HoraF;
            TxtCuposE.Text = "Cupos disponibles: "+even.CuposDisponibles+" de "+even.Cupos;
            TxtPuntajeE.Text = even.Puntos+" Puntos";

            if (!Disponible)
            {
                btnAsistir.IsEnabled = false;
                btnAsistir.IsVisible = false;
            }
            else
            {
                if (even.CuposDisponibles=="0")
                {
                    btnAsistir.IsEnabled = false;
                    btnAsistir.IsVisible = false;
                    btnOpcionado.IsEnabled = true;
                    btnOpcionado.IsVisible = true;
                }
                else
                {
                    btnAsistir.IsEnabled = true;
                    btnAsistir.IsVisible = true;
                    btnOpcionado.IsEnabled = false;
                    btnOpcionado.IsVisible = false;
                }
            }

            if (!Cancelable)
            {
                btnCancelar.IsEnabled = false;
                btnCancelar.IsVisible = false;
            }
            else
            {
                btnCancelar.IsEnabled = true;
                btnCancelar.IsVisible = true;
            }

            btnAsistir.Clicked += (sender, e) => BtnAsistirClick();
            btnCancelar.Clicked += (sender, e) => BtnCancelarClick();
            btnOpcionado.Clicked += (sender, e) => BtnOpcionadoClick();

        }
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        private async void BtnAsistirClick()
        {
            var answer = await DisplayAlert("Asistir a evento", "Recuerde que una vez inscrito solo podrá cancelar su asistencia con al menos un día de anticipación", "Aceptar", "Rechazar");
            if (answer)
            {
                var values = new Dictionary<string, string>
                {
                   { "Profesional",  (String)App.Current.Properties["Codigo"]},
                   { "Evento",  even.Id}
                };
                var content = new FormUrlEncodedContent(values);

                try
                {
                    var response = await client.PostAsync("https://app.socialbusiness.com.co/api/AsistirEvento.php", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    //await DisplayAlert("Alerta", responseString, "Ok");
                    Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);

                }
                catch (Exception e)
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde"+e, "Ok");
                    return;
                }
                if (Rta.Estado.Equals("Si"))
                {
                    await DisplayAlert("¡Éxito!", Rta.Mensaje, "Ok");
                    await Navigation.PopModalAsync();
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                }
                else
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                }
            }
            
        }
        private async void BtnOpcionadoClick()
        {
            var answer = await DisplayAlert("Postularse", "¿Está seguro?", "Si", "No");
            if (answer)
            {
                var values = new Dictionary<string, string>
                {
                   { "Profesional",  (String)App.Current.Properties["Codigo"]},
                   { "Evento",  even.Id}
                };
                var content = new FormUrlEncodedContent(values);

                try
                {
                    var response = await client.PostAsync("https://app.socialbusiness.com.co/api/OpcionadoEvento.php", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    //await DisplayAlert("Alerta", responseString, "Ok");
                    Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);

                }
                catch (Exception)
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                    return;
                }
                if (Rta.Estado.Equals("Si"))
                {
                    await DisplayAlert("¡Éxito!", Rta.Mensaje, "Ok");
                    await Navigation.PopModalAsync();
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                }
                else
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                }
            }
            
        }
        private async void BtnCancelarClick()
        {
            var answer = await DisplayAlert("Cancelar Asistencia", "¿Está seguro?", "Si", "No");
            if (answer)
            {
                var values = new Dictionary<string, string>
                {
                   { "Profesional",  (String)App.Current.Properties["Codigo"]},
                   { "Evento",  even.Id}
                };
                var content = new FormUrlEncodedContent(values);

                try
                {
                    var response = await client.PostAsync("https://app.socialbusiness.com.co/api/CancelarEvento.php", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    //await DisplayAlert("Alerta", responseString, "Ok");
                    Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);

                }
                catch (Exception)
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                    return;
                }
                if (Rta.Estado.Equals("Si"))
                {
                    await DisplayAlert("¡Éxito!", Rta.Mensaje, "Ok");
                    await Navigation.PopModalAsync();
                    Application.Current.MainPage = new NavigationPage(new TabbedPage1());
                }
                else
                {
                    //waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                }
            }
           
        }
    }
}