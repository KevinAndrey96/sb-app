using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp
{
    class FotosCell : ViewCell
    {
        public FotosCell()
        {
            var ImagenOferta = new Image
            {
                Source = ImageSource.FromUri(new Uri(String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110,
                HorizontalOptions = LayoutOptions.Center
            };
            ImagenOferta.SetBinding(Image.SourceProperty, new Binding("Foto"));
            View = new StackLayout
            {
                Children = { ImagenOferta
            },
                Orientation = StackOrientation.Horizontal
            };
        }
        
    }
}
