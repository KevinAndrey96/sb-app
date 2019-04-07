using SocialBusinessApp.Views;
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
    public partial class TabbedMLS : TabbedPage
    {
        public TabbedMLS()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Ofertas";
            //this.Icon = "iconomls";
            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                // Don't show first navigation bar
                NavigationPage.SetHasNavigationBar(this, false);

                // Add a child that is a NavigationPage with a View inside. An extra NavigationPage is possible on iOS. So every tab has its own navigation stack
                this.Children.Add(new NavigationPage(new MLS()));
                this.Children.Add(new NavigationPage(new MisOfertas()));
                this.Children.Add(new NavigationPage(new Constructoras()));
            }
            else
            {
                // Add a child that is a view. So no Navigation Page, because we already created that one in the ViewSplash
                this.Children.Add(new MLS());
                this.Children.Add(new MisOfertas());
                this.Children.Add(new Constructoras());
            }
            
        }
    }
}