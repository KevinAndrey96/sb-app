using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Filtros : ContentPage
    {
        public Filtros()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //btnFiltrar.Clicked += (sender, e) => btnFiltrarClick();
            btnBusca.Clicked += (sender, e) => btnBuscaClick();


        }
        private void btnBuscaClick()
        {
            Navigation.PushAsync(new MisListados("http://app.socialbusiness.com.co/api/Views/Listados.php?status=approved&nomof=" + txtBuscalo.Text));
        }
        private void btnFiltrarClick()
        {
            //String CodigoCategoria="";
            /*switch (txtCategoria.Items[txtCategoria.SelectedIndex])
            {
                case "Apartamento":
                    CodigoCategoria = "518";
                break;
                case "Apartaestudio":
                    CodigoCategoria = "519";
                    break;
                case "Casa":
                    CodigoCategoria = "520";
                    break;
                case "Finca":
                    CodigoCategoria = "521";
                    break;
                case "Lote":
                    CodigoCategoria = "522";
                    break;
                case "Local":
                    CodigoCategoria = "523";
                    break;
                case "Bodega":
                    CodigoCategoria = "524";
                    break;
                case "Edificio":
                    CodigoCategoria = "525";
                    break;
            }*/
            //Navigation.PushAsync(new MisListados("http://app.socialbusiness.com.co/api/Views/Filtros.php?catego="+CodigoCategoria));
            
            Navigation.PushAsync(new MisListados("http://app.socialbusiness.com.co/api/Views/Listados.php?status=approved&nomof=" + txtCategoria.Items[txtCategoria.SelectedIndex]));
        }
    }
}