using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;

namespace xfgoogleLogin.Droid
{
    [Activity(Label = "CustomegAuthInceptor", LaunchMode = LaunchMode.SingleTask)]

    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[]
            {
                    Intent.CategoryDefault,
                    Intent.CategoryBrowsable
            },
            DataSchemes = new[]
            {
                // First part of the redirect url (Package name)
                "com.companyname.xfgooglelogin"
            },
            DataPaths = new[]
            {
                // Second part of the redirect url (Path)
                "/oauth2redirect"
            }
        )
    ]
    public class CustomegAuthInceptor : Activity
    {
        protected  override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            Android.Net.Uri uri_android = Intent.Data;

            Intent.Dispose();


            // Convert iOS NSUrl to C#/netxf/BCL System.Uri - common API
            System.Uri uri_netfx = new System.Uri(uri_android.ToString());

            // Send the URI to the Authenticator for continuation
            MainPage.authenticator.OnPageLoading(uri_netfx);
            // Xamarin.Forms.DependencyService.Register<INativePages>();
            //DependencyService.Get<INativePages>().StartDashboardInAndroid();

            

            var intent = new Intent(MainActivity.mainactivity, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);
            Finish();
            
        }
    }
}