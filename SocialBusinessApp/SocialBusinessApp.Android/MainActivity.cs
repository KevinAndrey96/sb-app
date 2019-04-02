using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;
using Xamd.ImageCarousel.Forms.Plugin.Droid;
using Android.Content;
using System.Collections.Generic;

using Android.Provider;
using Android.Database;
using Xamarin.Forms;


using DLToolkit.Forms.Controls;
using Android.Graphics;
using Android.Media;
using System.IO;
using SocialBusinessApp.Droid.Helpers;
using SocialBusinessApp.Services;
using FFImageLoading.Forms.Platform;
using Plugin.Permissions;
using System.Threading.Tasks;
using Android;
//using TK.CustomMap.Droid;


//using FFImageLoading.Forms.Platform;

namespace SocialBusinessApp.Droid
{
    [Activity(Label = "Social Business PRO", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static int OPENGALLERYCODE = 100;
        protected async override void OnCreate(Bundle bundle)
        {
            await TryToGetPermissions();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);
            //TKGoogleMaps.Init(this, bundle);
            //TKCustomMapRenderer.InitMapRenderer();
            
            Xamarin.Essentials.Platform.Init(this, bundle);
            ImageCarouselRenderer.Init();

            Xamarin.FormsGoogleMaps.Init(this, bundle);
            Xamarin.FormsGoogleMapsBindings.Init(); // Add this line

            FlowListView.Init();
            
            //CachedImageRenderer.Init(false);
            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);
            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);
            CachedImageRenderer.Init(true);
            //FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: [true] /[false]);

            
            LoadApplication(new App());
        }



/*        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
{
    PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
}*/


        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == OPENGALLERYCODE && resultCode == Result.Ok)
            {
                List<string> images = new List<string>();

                if (data != null)
                {
                    ClipData clipData = data.ClipData;
                    if (clipData != null)
                    {
                        for (int i = 0; i < clipData.ItemCount; i++)
                        {
                            ClipData.Item item = clipData.GetItemAt(i);
                            Android.Net.Uri uri = item.Uri;
                            var path = GetRealPathFromURI(uri);

                            if (path != null)
                            {
                                //Rotate Image
                                var imageRotated = ImageHelpers.RotateImage(path);
                                var newPath = ImageHelpers.SaveFile("TmpPictures", imageRotated, System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                                images.Add(newPath);
                            }
                        }
                    }
                    else
                    {
                        Android.Net.Uri uri = data.Data;
                        var path = GetRealPathFromURI(uri);

                        if (path != null)
                        {
                            //Rotate Image
                            var imageRotated = ImageHelpers.RotateImage(path);
                            var newPath = ImageHelpers.SaveFile("TmpPictures", imageRotated, System.DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                            images.Add(newPath);
                        }
                    }

                    MessagingCenter.Send<App, List<string>>((App)Xamarin.Forms.Application.Current, "ImagesSelected", images);
                }
            }
        }



        public String GetRealPathFromURI(Android.Net.Uri contentURI)
        {
            try
            {
                ICursor imageCursor = null;
                string fullPathToImage = "";

                imageCursor = ContentResolver.Query(contentURI, null, null, null, null);
                imageCursor.MoveToFirst();
                int idx = imageCursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data);

                if (idx != -1)
                {
                    fullPathToImage = imageCursor.GetString(idx);
                }
                else
                {
                    ICursor cursor = null;
                    var docID = DocumentsContract.GetDocumentId(contentURI);
                    var id = docID.Split(':')[1];
                    var whereSelect = MediaStore.Images.ImageColumns.Id + "=?";
                    var projections = new string[] { MediaStore.Images.ImageColumns.Data };

                    cursor = ContentResolver.Query(MediaStore.Images.Media.InternalContentUri, projections, whereSelect, new string[] { id }, null);
                    if (cursor.Count == 0)
                    {
                        cursor = ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, projections, whereSelect, new string[] { id }, null);
                    }
                    var colData = cursor.GetColumnIndexOrThrow(MediaStore.Images.ImageColumns.Data);
                    cursor.MoveToFirst();
                    fullPathToImage = cursor.GetString(colData);
                }
                return fullPathToImage;
            }
            catch (Exception)
            {
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
                Toast.MakeText(context: Forms.Context, text: "Unable to get path", duration: ToastLength.Long).Show();
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

            }

            return null;

        }






        #region RuntimePermissions

        async Task TryToGetPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                GetPermissions();
                return;
            }
        }

        const int RequestLocationId = 0;
        readonly string[] PermissionsGroupLocation =
            {
                    //TODO add more permissions
                    Manifest.Permission.AccessCoarseLocation,
                    Manifest.Permission.AccessFineLocation,
                    Manifest.Permission.AccessLocationExtraCommands,
                    Manifest.Permission.AccessMockLocation,
                    Manifest.Permission.AccessNetworkState,
                    Manifest.Permission.AccessWifiState,
                    Manifest.Permission.Internet,
                    Manifest.Permission.ReadExternalStorage,
                    Manifest.Permission.WriteExternalStorage,
                    //Manifest.Permission_group.Storage
             };

        void GetPermissions()
        {
            const string permission = Manifest.Permission.AccessFineLocation;
            if (CheckSelfPermission(permission) == (int)Android.Content.PM.Permission.Granted)
            {
                //TODO change the message to show the permissions name
                //Toast.MakeText(this, "Permisos otorgados", ToastLength.Short).Show();
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                //set alert for executing the task
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Permisos Necesarios");
                alert.SetMessage("Social Business requiere tu permiso para acceder a la galeria de tu teléfono para que puedas publicar ofertas con fotos y permiso de ubicación para poder interactuar con la ubicación y mapa de las ofertas");
                alert.SetPositiveButton("Otorgar Permisos", (senderAlert, args) =>
                {
                    RequestPermissions(PermissionsGroupLocation, RequestLocationId);
                });
                alert.SetNegativeButton("Cancelar", (senderAlert, args) =>
                {
                    Toast.MakeText(this, "Cancelado!", ToastLength.Short).Show();
                });
                Dialog dialog = alert.Create();
                dialog.Show();
                return;
            }
            RequestPermissions(PermissionsGroupLocation, RequestLocationId);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            switch (requestCode)

            {
                case RequestLocationId:
                    {
                        if (grantResults[0] == (int)Android.Content.PM.Permission.Granted)
                        {
                            Toast.MakeText(this, "Permisos otorgados", ToastLength.Short).Show();
                        }
                        else
                        {
                            //Permission Denied :(
                            Toast.MakeText(this, "Permisos denegados", ToastLength.Short).Show();
                        }
                    }
                    break;
            }
            //base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }



        #endregion


    }
}

