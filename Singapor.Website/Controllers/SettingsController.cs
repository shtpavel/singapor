using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace Singapor.Website.Controllers
{
    [RoutePrefix("api/settings")]
    public class SettingsController : ApiController
    {
        [HttpGet, Route("")]
        public object ApiUrl()
        {
            var api_url = WebConfigurationManager.AppSettings["apiurl"];
            return new {api_url = api_url};
        }
    }
}