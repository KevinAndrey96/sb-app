using Newtonsoft.Json;
using SocialBusinessApp.Cells;
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
    public partial class Logros : ContentPage
    {
        private List<Logro> Logro1;
        public Logros(string code)
        {
            InitializeComponent();
            this.Title = "Logros";

            LogrosListView.ItemTemplate = new DataTemplate(typeof(LogrosCell));
            this.LoadAll(code);

        }
        private async void LoadAll(String code)
        {
            //waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://app.socialbusiness.com.co");
                string url = string.Format("/api/Logros.php?Profesional=" + code.Substring(8));
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
                //await DisplayAlert("JSON", result, "Vale");
                //await DisplayAlert("hola", result, url);
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                //waitActivityIndicator.IsRunning = false;
                return;
            }
            //waitActivityIndicator.IsRunning = false;

            Logro1 = JsonConvert.DeserializeObject<List<Logro>>(result);
            LogrosListView.ItemsSource = Logro1;
        }
    }
    
}