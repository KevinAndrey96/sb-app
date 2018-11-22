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
            this.Icon = "iconomls";
            this.Children.Add(new MLS());
            this.Children.Add(new MisOfertas());
        }
    }
}