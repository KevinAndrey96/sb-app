using FFImageLoading.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    public class EventoCell : ViewCell
    {
        public EventoCell()
        {
            var NombreLabel = new Label
            {
                FontSize = 17/*,
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center*/
            };
            NombreLabel.SetBinding(Label.TextProperty, new Binding("Nombre"));

            var FechaLabel = new Label
            {
                FontSize = 13
            };
            FechaLabel.SetBinding(Label.TextProperty, new Binding("Fecha"));

            var DepartamentoLabel = new Label
            {
                FontSize = 13
            };
            DepartamentoLabel.SetBinding(Label.TextProperty, new Binding("Departamento"));

            var CiudadLabel = new Label
            {
                FontSize = 13
            };
            CiudadLabel.SetBinding(Label.TextProperty, new Binding("Ciudad"));

            /*

            var ImagenEvento= new Image
            {
                Source = ImageSource.FromUri(new Uri(String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            ImagenEvento.SetBinding(Image.SourceProperty, new Binding("Fotografia"));
            */
            var ImagenEvento = new CachedImage()
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
            ImagenEvento.SetBinding(CachedImage.SourceProperty, new Binding("Fotografia"));
            var View2 = new StackLayout
            {
                Children = { NombreLabel, FechaLabel, DepartamentoLabel, CiudadLabel },
                Orientation = StackOrientation.Vertical
            };

            View = new StackLayout
            {
                Children = { ImagenEvento, View2 },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}

