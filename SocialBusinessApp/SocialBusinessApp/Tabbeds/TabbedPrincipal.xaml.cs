using SocialBusinessApp.Tabbeds;
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
    public partial class TabbedPage1 : TabbedPage
    {
        [Obsolete]
        public TabbedPage1()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                // Don't show first navigation bar
                NavigationPage.SetHasNavigationBar(this, false);

                this.Children.Add(new NavigationPage(new TabbedMLS()));
                this.Children.Add(new NavigationPage(new TabbedPage2()));//Error
                String AppUsuario = (String)App.Current.Properties["Usuario"];
                String AppContrasena = (String)App.Current.Properties["Contrasena"];
                this.Children.Add(new NavigationPage(new MisListados("https://app.socialbusiness.com.co/PreChat.php?u="+AppUsuario+"&p="+AppContrasena)));
                this.Children.Add(new NavigationPage(new TabbedEventos()));
            }
            else
            {
                // Add a child that is a view. So no Navigation Page, because we already created that one in the ViewSplash
                this.Children.Add(new TabbedMLS());
                this.Children.Add(new TabbedPage2());
                String AppUsuario = (String)App.Current.Properties["Usuario"];
                String AppContrasena = (String)App.Current.Properties["Contrasena"];
                this.Children.Add(new MisListados("https://app.socialbusiness.com.co/PreChat.php?u=" + AppUsuario + "&p=" + AppContrasena));
                this.Children.Add(new TabbedEventos());
            }
            //this.Children.Add(new Profile());

            //this.Children.Add(new Perfil());


        }
    }
}