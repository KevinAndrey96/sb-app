using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisListados : ContentPage
    {       
        public MisListados(string url)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Chat";
            this.Icon = "iconochat";
            Browser.Source = url;
        }
    }
}