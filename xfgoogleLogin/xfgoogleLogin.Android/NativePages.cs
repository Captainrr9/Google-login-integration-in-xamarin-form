using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using xfgoogleLogin.Droid;
using xfgoogleLogin.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(NativePages))]
namespace xfgoogleLogin.Droid
{

        public class NativePages : INativePages
        {
            public NativePages()
            {
            }

    
        public void StartActivityInAndroid(Xamarin.Auth.OAuth2Authenticator authenticator)
            {
            var intent = authenticator.GetUI(MainActivity.mainactivity);
          
                Forms.Context.StartActivity(intent);
            }

       

    }
    }
