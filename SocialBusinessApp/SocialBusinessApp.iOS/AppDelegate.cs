using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using SuaveControls.FloatingActionButton.iOS.Renderers;
using UIKit;
using Xamd.ImageCarousel.Forms.Plugin.iOS;

namespace SocialBusinessApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            
            global::Xamarin.Forms.Forms.Init();
            ImageCarouselRenderer.Init();
            Xamarin.FormsMaps.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            //LoadApplication(new App());
            FloatingActionButtonRenderer.InitRenderer();

            //global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsGoogleMaps.Init("REDACTED_GOOGLE_API_KEY");
            Xamarin.FormsGoogleMapsBindings.Init(); // Add this line
            

            LoadApplication(new App());

            UIButton ben = new UIButton();
            ben.TouchUpInside += async (Object sender, EventArgs e) =>
            {
                await Task.Delay(888);
            };

            return base.FinishedLaunching(app, options);
        }
    }
}
