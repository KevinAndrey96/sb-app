using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamd.ImageCarousel.Forms.Plugin.Abstractions;

namespace SocialBusinessApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gallery : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();
        private string PlaceID = "1202";
        public Gallery()
        {
            InitializeComponent();
            this.LoadFotos();
            imageSources.Add("https://i.etsystatic.com/11805514/r/il/3fe133/1001694695/il_570xN.1001694695_lcrp.jpg");
            imageSources.Add("comentarios.png");
            imageSources.Add("logo.png");

            imgSlider.Images = imageSources;
        }

        private async void LoadFotos()
        {
            waitActivityIndicator.IsRunning = true;
            string result;
            try
            {
                HttpClient client = new HttpClient();

                string url = string.Format("http://app.socialbusiness.com.co/api/Fotos.php?placeid=" + PlaceID);
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "No se detecta conexión a internet, por favor intente más tarde", "Ok");
                waitActivityIndicator.IsRunning = false;
                return;
            }
            await DisplayAlert("ok", "hola" + PlaceID, "ok");
            waitActivityIndicator.IsRunning = false;

        }
    }
}