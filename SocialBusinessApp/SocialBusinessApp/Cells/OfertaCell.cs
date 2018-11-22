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
            
            var ImagenOferta = new Image
            {
                Source = ImageSource.FromUri(new Uri (String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                WidthRequest = 110,
                HeightRequest = 110
            };
            ImagenOferta.SetBinding(Image.SourceProperty, new Binding("Fotografia"));

            var View2 = new StackLayout
            {
                Children = { NombreLabel, PrecioLabel, ABHPLabel, CiudadLabel},
                Orientation = StackOrientation.Vertical
            };

            View = new StackLayout
            {
                Children = { ImagenOferta, View2},
                Orientation = StackOrientation.Horizontal
            };
        }
    }
}

