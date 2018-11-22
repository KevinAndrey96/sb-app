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
    public partial class TabbedEventos : TabbedPage
    {
        public TabbedEventos()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Eventos";
            this.Icon = "iconoeventos";
            this.Children.Add(new Eventos());
            this.Children.Add(new MisEventos());
            this.Children.Add(new HistoricoEventos());
        }
    }
}