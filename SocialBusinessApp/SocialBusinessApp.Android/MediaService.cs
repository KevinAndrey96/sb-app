using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.Content;
using Android.Widget;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SocialBusinessApp.Droid;
//using SocialBusinessApp.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MediaService))]
namespace SocialBusinessApp.Droid
{
    public class MediaService : Java.Lang.Object, IMediaService
    {
        public async Task OpenGallery()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                    {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                        Toast.MakeText(context: Forms.Context, text: "Necesitamos permiso para acceder al almacenamiento interno.", duration: ToastLength.Long).Show();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                    status = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (status == PermissionStatus.Granted)
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    Toast.MakeText(context: Forms.Context, text: "Seleccione máximo 15 fotos", duration: ToastLength.Long).Show();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                    var imageIntent = new Intent(
                        Intent.ActionPick);
                    imageIntent.SetType("image/*");
                    imageIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                    imageIntent.SetAction(Intent.ActionGetContent);
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    ((Activity)Forms.Context).StartActivityForResult(
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                        Intent.CreateChooser(imageIntent, "Seleccione la fotografía"), MainActivity.OPENGALLERYCODE);

                }
                else if (status != PermissionStatus.Unknown)
                {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                    Toast.MakeText(context: Forms.Context, text: "Permission Denied. Can not continue, try again.", duration: ToastLength.Long).Show();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                Toast.MakeText(context: Forms.Context, text: "Error. Can not continue, try again.", duration: ToastLength.Long).Show();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos
            }
        }


    }
}