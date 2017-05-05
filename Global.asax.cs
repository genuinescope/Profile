using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SongCatelogApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
           // routes.MapPageRoute("profile1",
           // "", "~/profile5.aspx", true);

            routes.MapPageRoute("profiles",
            "profile/{id}/{pageType}/{albumId}", "~/profile5.aspx", true, new RouteValueDictionary { { "id", "0" }, { "pageType", "featured" }, { "albumId", "0" } });
            routes.MapPageRoute("profilePreview",
           "preview/{version}/{id}/{pageType}/{albumId}", "~/profile5.aspx", true, new RouteValueDictionary {{"version","beta"}, { "id", "0" }, { "pageType", "featured" }, { "albumId", "0" } });

            routes.MapPageRoute("profile_beta",
        "artists_beta/{id}/{pageType}/{albumId}", "~/profile_test.aspx", true, new RouteValueDictionary { { "id", "0" }, { "pageType", "featured" }, { "albumId", "0" } });
            routes.MapPageRoute("profilePreview_beta",
           "preview_beta/{version}/{id}/{pageType}/{albumId}", "~/profile_test.aspx", true, new RouteValueDictionary { { "version", "beta" }, { "id", "0" }, { "pageType", "featured" }, { "albumId", "0" } });
           

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}