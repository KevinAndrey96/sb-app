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
        public TabbedPage1()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            
            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                // Don't show first navigation bar
                NavigationPage.SetHasNavigationBar(this, false);

                // Add a child that is a NavigationPage with a View inside. An extra NavigationPage is possible on iOS. So every tab has its own navigation stack
                //this.Children.Add(new NavigationPage(new MLS()));
                this.Children.Add(new NavigationPage(new TabbedMLS()));
                this.Children.Add(new NavigationPage(new TabbedPage2()));
                this.Children.Add(new NavigationPage(new MisListados("https://app.socialbusiness.com.co/chat")));
                this.Children.Add(new NavigationPage(new TabbedEventos()));
            }
            else
            {
                // Add a child that is a view. So no Navigation Page, because we already created that one in the ViewSplash
                this.Children.Add(new TabbedMLS());
                this.Children.Add(new TabbedPage2());
                this.Children.Add(new MisListados("https://app.socialbusiness.com.co/chat"));
                this.Children.Add(new TabbedEventos());
            }
            //this.Children.Add(new Profile());

            //this.Children.Add(new Perfil());


        }
    }
}