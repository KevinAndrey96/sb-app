using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialBusinessApp.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        ObservableCollection<string> _images = new ObservableCollection<string>();

        public Page1(string lat, string lon)
        {
            InitializeComponent();

            listItems.FlowItemsSource = _images;

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<App, string>((App)Xamarin.Forms.Application.Current, "ImagesSelected", (s, image) =>
            {
                _images.Add(image);
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IPickImage>().getImage();
        }
    }
}