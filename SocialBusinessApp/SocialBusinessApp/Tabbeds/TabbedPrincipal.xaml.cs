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
            this.Children.Add(new TabbedMLS());
            //this.Children.Add(new Ranking());
            this.Children.Add(new TabbedPage2());
            this.Children.Add(new MisListados("http://app.socialbusiness.com.co/chat"));
            this.Children.Add(new TabbedEventos());
            //this.Children.Add(new Profile());
            
            //this.Children.Add(new Perfil());
            

        }
    }
}