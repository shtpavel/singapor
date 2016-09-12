using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Singapor.Api.Controllers
{
    [RoutePrefix("api/test")]
    public class ValuesController : ApiController
    {
        [HttpGet, Route("")]
        public string Get()
        {
            return "value";
        }
    }
}
