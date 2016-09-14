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
        public const string ApiVersion = "v1/";
        public const string ApiPrefix = "api/";
        public const string FullApiPrefix = ApiPrefix + ApiVersion;
    }
}