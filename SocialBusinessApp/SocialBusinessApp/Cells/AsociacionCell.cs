using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Cells
{
    class AsociacionCell : ViewCell
    {
        public AsociacionCell ()
            {
                var NombreLabel = new Label
                {
                    FontSize = 17
                };
                NombreLabel.SetBinding(Label.TextProperty, new Binding("Nombre"));
                var DepartamentoLabel = new Label
                {
                    FontSize = 17
                };
                DepartamentoLabel.SetBinding(Label.TextProperty, new Binding("Departamento"));
                var TelefonoLabel = new Label
                {
                    FontSize = 17
                };
                TelefonoLabel.SetBinding(Label.TextProperty, new Binding("Telefono"));
                
                var FotoImage = new Image
                {
                    Source = ImageSource.FromUri(new Uri(String.Format("http://app.socialbusiness.com.co/place_pic_thumb/2/18.02.01.16.25-1517520342.06-25656287.jpg"))),
                    WidthRequest = 110,
                    HeightRequest = 110
                };
                FotoImage.SetBinding(Image.SourceProperty, new Binding("Fotografia"));

                var View2 = new StackLayout
                {
                    Children = {  NombreLabel, DepartamentoLabel, TelefonoLabel },
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
