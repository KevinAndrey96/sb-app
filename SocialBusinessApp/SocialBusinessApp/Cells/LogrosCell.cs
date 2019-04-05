using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    class LogrosCell : ViewCell
    {
        public LogrosCell()
        {
            var PuntajeLabel = new Label
            {
                FontSize = 17,
                WidthRequest = 80,
                
            };
            PuntajeLabel.SetBinding(Label.TextProperty, new Binding("Puntaje"));
            var TextoLabel = new Label
            {
                FontSize = 17,
                HorizontalTextAlignment= TextAlignment.Start
            };
            TextoLabel.SetBinding(Label.TextProperty, new Binding("Texto"));
            /*
            var FotoImage = new Image
            {
                Source = ImageSource.FromUri(new Uri(String.Format("https://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            FotoImage.SetBinding(Image.SourceProperty, new Binding("Fotografia"));
            */
            /*var View2 = new StackLayout
            {
                Children = { PuntajeLabel, TextoLabel },
                Orientation = StackOrientation.Vertical
            };*/

            View = new StackLayout
            {
                Children = { TextoLabel/*, PuntajeLabel*/
                //Children = { /*FotoImage,*/ View2
                },
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}
