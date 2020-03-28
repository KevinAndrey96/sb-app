using FFImageLoading.Forms;
using SocialBusinessApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    public class OfertaCell: ViewCell
    {
        public OfertaCell()
        {
            var NombreLabel = new Label
            {
                FontSize=17/*,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center*/
            };
            NombreLabel.SetBinding(Label.TextProperty, new Binding("NombreCorto"));
            
            var PrecioLabel = new Label
            {
                FontSize = 13
            };
            PrecioLabel.SetBinding(Label.TextProperty, new Binding("Precio"));

            var AreaLabel = new Label
            {
                FontSize = 13
            };
            AreaLabel.SetBinding(Label.TextProperty, new Binding("Area"));

            var ABHPLabel = new Label
            {
                FontSize = 13
            };
            ABHPLabel.SetBinding(Label.TextProperty, new Binding("ABHP"));

            var CiudadLabel = new Label
            {
                FontSize = 13
            };
            CiudadLabel.SetBinding(Label.TextProperty, new Binding("Ciudad"));
            /*
            var ImagenOferta = new Image
            {
                //Source = ImageSource.FromUri(new Uri (String.Format("https://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            ImagenOferta.SetBinding(Image.SourceProperty, new Binding("Fotografia"));*/
            var ImagenOferta = new CachedImage()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 110,
                HeightRequest = 110,
                CacheDuration = TimeSpan.FromDays(30),
                DownsampleToViewSize = true,
                RetryCount = 0,
                RetryDelay = 250,
                BitmapOptimizations = false,
                //LoadingPlaceholder = "loading.png",
                //ErrorPlaceholder = "error.png",
                //Source = "http://loremflickr.com/600/600/nature?filename=simple.jpg"
            };
            ImagenOferta.SetBinding(CachedImage.SourceProperty, new Binding("Fotografia")); 

             Button button = new Button
            {
                Image = "user_icon",
                WidthRequest = 40,
                HeightRequest = 40,
                //BackgroundColor = Color.FromHex("9c27b0")
                BackgroundColor = Color.Transparent,

                //Text = "Hola"
                //Clicked = "OnClick_u"
            };
            //button.SetBinding(Button.ClassIdProperty, new Binding("ID"));
            button.SetBinding(Button.TextProperty, new Binding("UserId"));
            button.Clicked += PlusClicked;


            var View2 = new StackLayout
            {
                Children = {PrecioLabel, ABHPLabel, CiudadLabel},
                Orientation = StackOrientation.Vertical
            };

            var View3 = new StackLayout
            {
                Children = { /*button, */View2  },
                Orientation = StackOrientation.Horizontal
            };

            var View4 = new StackLayout
            {
                Children = { NombreLabel, View3 },
                Orientation = StackOrientation.Vertical
            };

            View = new StackLayout
            {
                Children = { ImagenOferta, View4},
                Orientation = StackOrientation.Horizontal
            };

            
        }
        private void PlusClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Application.Current.MainPage.Navigation.PushModalAsync(new BuscarPerfil(btn.Text));
        }
    }
}

