using System;
using System.Collections.Generic;
using System.Text;

namespace xfgoogleLogin.Constants
{
   public static class AppConstants
    {

        public static string RedirectUrl = "com.companyname.xfgooglelogin:/oauth2redirect";// com.googleusercontent.apps.359939565963-5l7dk2jtfflnbhprtclos12eit6jkdme:/oauth2redirect;
        public static string ClientId = "359939565963-cn3980tmkfbe4ojq9tpkgtd4p96qsl2b.apps.googleusercontent.com";
        public static string authorizeUrl= "https://accounts.google.com/o/oauth2/v2/auth";
        public static string accessTokenUrl= "https://www.googleapis.com/oauth2/v4/token";
        public static bool access=false;

    }
}
