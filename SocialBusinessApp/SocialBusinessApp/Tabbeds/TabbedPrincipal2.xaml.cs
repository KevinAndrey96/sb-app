using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Tabbeds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPrincipal2 : TabbedPage
    {
        public TabbedPrincipal2()
        {
            InitializeComponent();

            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                // Don't show first navigation bar
                NavigationPage.SetHasNavigationBar(this, false);

                this.Children.Add(new NavigationPage(new TabbedMLS()));
                this.Children.Add(new NavigationPage(new TabbedPage2()));
                String AppUsuario = (String)App.Current.Properties["Usuario"];
                String AppContrasena = (String)App.Current.Properties["Contrasena"];
                this.Children.Add(new NavigationPage(new MisListados("https://app.socialbusiness.com.co/PreChat.php?u=" + AppUsuario + "&p=" + AppContrasena)));
                this.Children.Add(new NavigationPage(new TabbedEventos()));
            }
            else
            {
                NavigationPage.SetHasNavigationBar(this, false);
                this.Children.Add(new TabbedMLS());
                this.Children.Add(new TabbedPage2());
                String AppUsuario = (String)App.Current.Properties["Usuario"];
                String AppContrasena = (String)App.Current.Properties["Contrasena"];
                this.Children.Add(new MisListados("https://app.socialbusiness.com.co/PreChat.php?u=" + AppUsuario + "&p=" + AppContrasena));
                this.Children.Add(new TabbedEventos());
            }
        }
    }
}