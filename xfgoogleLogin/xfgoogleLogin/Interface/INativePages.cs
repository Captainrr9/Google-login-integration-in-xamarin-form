using System;
using System.Collections.Generic;
using System.Text;

namespace xfgoogleLogin.Interface
{
    public interface INativePages
    {
        void StartActivityInAndroid(Xamarin.Auth.OAuth2Authenticator authenticator);
       
    }
}
