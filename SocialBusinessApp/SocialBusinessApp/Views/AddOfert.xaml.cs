using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Xamarin.Forms.ImagePicker;
using System.IO;
using Plugin.Media.Abstractions;
using System.Net.Http.Headers;

namespace SocialBusinessApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Listado : ContentPage
    {
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        IImagePickerService _imagePickerService;

        private ImageSource Origen1, Origen2, Origen3, Origen4, Origen5;

        public Listado ()
		{
            //NavigationPage.SetHasNavigationBar(this, false);
            _imagePickerService = DependencyService.Get<IImagePickerService>();
            InitializeComponent ();
            btnPublicar.Clicked += (sender, e) => btnPublicarClick();
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            await DependencyService.Get<IMediaService>().OpenGallery();

        }
        private void btnPublicarClick()
        {
            SendTo();
        }
        async void Button_Clicked1(object sender, System.EventArgs e)
        {
            var imageSource = await _imagePickerService.PickImageAsync();

            if (imageSource != null) // it will be null when user cancel
            {
                image1.Source = imageSource;
                Origen1 = imageSource;
            }
        }
        async void Button_Clicked2(object sender, System.EventArgs e)
        {
            var imageSource = await _imagePickerService.PickImageAsync();

            if (imageSource != null) // it will be null when user cancel
            {
                image2.Source = imageSource;
                Origen2 = imageSource;
            }
        }
        async void Button_Clicked3(object sender, System.EventArgs e)
        {
            var imageSource = await _imagePickerService.PickImageAsync();

            if (imageSource != null) // it will be null when user cancel
            {
                image3.Source = imageSource;
                Origen3 = imageSource;
            }
        }
        async void Button_Clicked4(object sender, System.EventArgs e)
        {
            var imageSource = await _imagePickerService.PickImageAsync();

            if (imageSource != null) // it will be null when user cancel
            {
                image4.Source = imageSource;
                Origen4 = imageSource;
            }
        }
        async void Button_Clicked5(object sender, System.EventArgs e)
        {
            var imageSource = await _imagePickerService.PickImageAsync();

            if (imageSource != null) // it will be null when user cancel
            {
                image5.Source = imageSource;
                Origen5 = imageSource;
            }
        }

        public async Task<bool> Upload(MediaFile mediaFile, string filename)
        {
            byte[] bitmapData;
            var stream = new MemoryStream();
            mediaFile.GetStream().CopyTo(stream);
            bitmapData = stream.ToArray();
            var fileContent = new ByteArrayContent(bitmapData);

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/octet-stream");
            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "fileUpload",
                FileName = filename
            };

            string boundary = "---8393774hhy37373773";
            MultipartFormDataContent multipartContent = new MultipartFormDataContent(boundary);
            multipartContent.Add(fileContent);


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync("http://www.url.com/upload.php", multipartContent);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                return true;
            }
            return false;
        }


        private async void SendTo()
        {
            var values = new Dictionary<string, string>
                {
                   { "Dato1",  txtNO.Text},
                   { "Dato2", txtDepartamento.Items[txtDepartamento.SelectedIndex]},
                   { "Dato3", txtCi.Text},
                   { "Dato4", txtBar.Text},
                   { "Dato5", txtDi.Text},
                   { "Dato6", txtPr.Text},
                   { "Dato7", txtAr.Text},
                   { "Dato8", txtUbicación.Items[txtUbicación.SelectedIndex]},
                   { "Dato9", txtHa.Text},
                   { "Dato10", txtBa.Text},
                   { "Dato11", txtPa.Text},
                   { "Dato12", txtEstrato.Items[txtEstrato.SelectedIndex]},
                   { "Dato13", txtAntiguedad.Items[txtAntiguedad.SelectedIndex]},
                   { "Dato14", txtTe.Text},
                   { "Dato15", TxtTerceria.Items[TxtTerceria.SelectedIndex]},

                   { "Dato19", txtDe.Text},
                   { "Dato20", txtCategoria.Items[txtCategoria.SelectedIndex]},
                   { "Dato21", txtTipo.Items[txtTipo.SelectedIndex]},
                   { "Dato22", (String)App.Current.Properties["Usuario"]}

                };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://app.socialbusiness.com.co/api/Post.php", content);
            //DisplayAlert("Alert", "You have been alerted 2", "OK");
            try
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    var photo = await CrossMedia.Current.PickPhotoAsync();
                }
                var responseString = await response.Content.ReadAsStringAsync();
                Rta = JsonConvert.DeserializeObject<Respuesta>(responseString);
                await DisplayAlert("Alerta", Rta.Mensaje, "Ok");
                await Navigation.PopModalAsync().ConfigureAwait(false);
                await Navigation.PushModalAsync(new Archivos());

                Navigation.InsertPageBefore(new Archivos(), this);
                await Navigation.PopModalAsync();
                
            }
            catch (Exception e)
            {
                await DisplayAlert("Alerta", ""+e, "Ok");

            }
        }
	}
}