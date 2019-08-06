using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using SocialBusinessApp.iOS;
using UIKit;
using System.Drawing;
using AssetsLibrary;
using SocialBusinessApp;
using SocialBusinessApp.Services;
using CoreGraphics;
using ObjCRuntime;
using Xamarin.Forms;
//using ELCImagePicker;
using System.IO;
using GMImagePicker;
using Photos;

[assembly: Xamarin.Forms.Dependency(typeof(MediaService))]
namespace SocialBusinessApp.iOS
{
    public class MediaService : IMediaService, IMessanger
    {
        public async Task OpenGallery()
        {
            var picker = new GMImagePickerController();
            picker.FinishedPickingAssets += (sender, args) => {
                foreach (var item in args.Assets)
                {
                    PHImageManager.DefaultManager.RequestImageData(item, null, (NSData data, NSString dataUti, UIImageOrientation orientation, NSDictionary info) => {
                        NSUrl url = info.ObjectForKey(new NSString("PHImageFileURLKey")) as NSUrl;
                        string urlString = url.AbsoluteString;

                        string[] strs = urlString.Split("/");

                        string s = Save(UIImage.LoadFromData(data), strs[strs.Length - 1]);

                        MessagingCenter.Send<App, string>((App)Xamarin.Forms.Application.Current, "ImagesSelected", s);
                    });

                }
            };
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(picker, true, null);
        }

        string Save(UIImage image, string name)
        {
            var documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string jpgFilename = System.IO.Path.Combine(documentsDirectory, name); // hardcoded filename, overwritten each time
            NSData imgData = image.AsJPEG();
            NSError err = null;
            if (imgData.Save(jpgFilename, false, out err))
            {
                return jpgFilename;
            }
            else
            {
                Console.WriteLine("NOT saved as " + jpgFilename + " because" + err.LocalizedDescription);
                return null;
            }
        }


    }
}