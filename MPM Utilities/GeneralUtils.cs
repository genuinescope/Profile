using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using SongCatalog.MPM.Data;
using System.Data;

namespace SongCatalog.MPM.Utils
{
	/// <summary>
	/// General MPM Utility functions
	/// </summary>
	public class GeneralUtils
	{

        public static string GetRootUrl()
        {

           return  HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + HttpContext.Current.Request.ApplicationPath;
        }
        public static string Get_commonFilePath()
        {
            return  System.Web.Configuration.WebConfigurationManager.AppSettings["CommonFilePath"].ToString();        
        }

        public static string Get_SongFilePath()
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings["SongsFilePath"].ToString();
        }

  

	}

 
   
}
