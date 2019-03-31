using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace SocialBusinessApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GMap : ContentPage
	{
        public ObservableCollection<Pin> Pins { get; set; } = new ObservableCollection<Pin>();
        public GMap ()
		{
			InitializeComponent ();

        }
	}
}