using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Singapor.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        [HttpGet, Route("")]
        public object Get()
        {
            return new {message = "ping"};
        }
    }
}
