using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Singapor.Api
{
    public class Settings
    {
        public static string ClientUrl = WebConfigurationManager.AppSettings["clientUrl"];
    }
}