using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AndroidSpecific = Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace SocialBusinessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MisListados : ContentPage
    {       
        public MisListados(string url )
        {
            AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this, AndroidSpecific.WindowSoftInputModeAdjust.Resize);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            this.Title = "Chat";
            this.Icon = "iconochat";
            Browser.Source = url;
            
        }
    }
}