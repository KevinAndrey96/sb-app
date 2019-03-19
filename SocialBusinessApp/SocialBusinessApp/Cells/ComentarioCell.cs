using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    class ComentarioCell : ViewCell
    {
        public ComentarioCell()
        {
            var AutorLabel = new Label
            {
                FontSize = 17,
            };
            AutorLabel.SetBinding(Label.TextProperty, new Binding("Autor"));
            var TextoLabel = new Label
            {
                FontSize = 17
            };
            TextoLabel.SetBinding(Label.TextProperty, new Binding("Texto"));

            var FotoImage = new Image
            {
                Source = ImageSource.FromUri(new Uri(String.Format("https://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            FotoImage.SetBinding(Image.SourceProperty, new Binding("Fotografia"));

            var View2 = new StackLayout
            {
                Children = { AutorLabel, TextoLabel},
                Orientation = StackOrientation.Vertical
            };

            View = new StackLayout
            {
                Children = { FotoImage, View2
                },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
