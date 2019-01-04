using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Plugin.FileUploader;
using Plugin.FileUploader.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Xamarin.Forms.ImagePicker;
using System.IO;
using Plugin.Media.Abstractions;
using System.Net.Http.Headers;
using SocialBusinessApp.Services;

namespace SocialBusinessApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Listado : ContentPage
    {
        private static HttpClient client = new HttpClient();
        Respuesta Rta;
        IImagePickerService _imagePickerService;

        private ImageSource Origen1, Origen2, Origen3, Origen4, Origen5;

        List<string> _images = new List<string>();

        Queue<string> paths = new Queue<string>();
        string filePath = string.Empty;
        bool isBusy = false;


        public Listado ()
		{
            //NavigationPage.SetHasNavigationBar(this, false);
            _imagePickerService = DependencyService.Get<IImagePickerService>();
            InitializeComponent ();
            btnPublicar.Clicked += (sender, e) => btnPublicarClick();

            //Inicio
            takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;
                filePath = file.Path;
                paths.Enqueue(filePath);
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();

                    file.Dispose();
                    return stream;
                });
            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                filePath = file.Path;
                paths.Enqueue(filePath);

                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    //  file.Dispose();
                    return stream;
                });
            };

            takeVideo.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;
                filePath = file.Path;
                paths.Enqueue(filePath);
                await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");

                file.Dispose();
            };

            pickVideo.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickVideoSupported)
                {
                    await DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickVideoAsync();

                if (file == null)
                    return;
                filePath = file.Path;
                paths.Enqueue(filePath);
                await DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
                file.Dispose();
            };

            CrossFileUploader.Current.FileUploadCompleted += Current_FileUploadCompleted;
            CrossFileUploader.Current.FileUploadError += Current_FileUploadError;
            CrossFileUploader.Current.FileUploadProgress += Current_FileUploadProgress;
        }

        private void Current_FileUploadProgress(object sender, FileUploadProgress e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                progress.Progress = e.Percentage / 100.0f;
            });
        }

        private void Current_FileUploadError(object sender, FileUploadResponse e)
        {
            isBusy = false;
            System.Diagnostics.Debug.WriteLine($"{e.StatusCode} - {e.Message}");
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("File Upload", "Upload Failed", "Ok");
                progress.IsVisible = false;
                progress.Progress = 0.0f;
            });
        }

        private void Current_FileUploadCompleted(object sender, FileUploadResponse e)
        {
            isBusy = false;
            System.Diagnostics.Debug.WriteLine($"{e.StatusCode} - {e.Message}");
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("File Upload", "Upload Completed", "Ok");
                progress.IsVisible = false;
                progress.Progress = 0.0f;
            });
        }

        void OnUpload(object sender, EventArgs args)
        {
            if (isBusy)
                return;
            isBusy = true;
            progress.IsVisible = true;


            //Uploading multiple images at once

            /*List<FilePathItem> pathItems = new List<FilePathItem>();
            while (paths.Count > 0)
            {
                pathItems.Add(new FilePathItem("image",paths.Dequeue()));
            }*/

            CrossFileUploader.Current.UploadFileAsync("<URL HERE>", new FilePathItem("<FIELD NAME HERE>", filePath), new Dictionary<string, string>()
            {
                /*<HEADERS HERE>*/
            });

            

        }
        //Fin
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelected", (s, images) =>
            {
                listItems.FlowItemsSource = images;
                _images = images;
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<App, List<string>>(this, "ImagesSelected");
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