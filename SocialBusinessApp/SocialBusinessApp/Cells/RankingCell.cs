using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    public class RankingCell : ViewCell
    {
        public RankingCell()
        {
            var NombreLabel = new Label
            {
                FontSize = 17
            };
            NombreLabel.SetBinding(Label.TextProperty, new Binding("Nombre"));
            var CodigoLabel = new Label
            {
                FontSize = 17
            };
            CodigoLabel.SetBinding(Label.TextProperty, new Binding("Codigo"));
            var PosicionLabel = new Label
            {
                FontSize = 17
            };
            PosicionLabel.SetBinding(Label.TextProperty, new Binding("Posicion"));
            var PuntajeLabel = new Label
            {
                FontSize = 17
            };
            PuntajeLabel.SetBinding(Label.TextProperty, new Binding("Puntaje"));
            var MedallaImage = new Image
            {
                //Source = ImageSource.FromUri(new Uri(String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                Source = "logo.png",
                WidthRequest = 110,
                HeightRequest = 110
            };
            /*var FotoImage = new Image
            {
                Source = ImageSource.FromUri(new Uri(String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            FotoImage.SetBinding(Image.SourceProperty, new Binding("Fotografia"));*/
            var FotoImage = new CachedImage()
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
            FotoImage.SetBinding(CachedImage.SourceProperty, new Binding("Fotografia"));
            //MedallaImage.Source= "logo.png";

            var View2 = new StackLayout
            {
                Children = { PosicionLabel, NombreLabel, CodigoLabel, PuntajeLabel},
                Orientation = StackOrientation.Vertical
            };

            View = new StackLayout
            {
                Children = { FotoImage, View2 },
                Orientation = StackOrientation.Horizontal
            };

        }
    }
}
