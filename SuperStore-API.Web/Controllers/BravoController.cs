using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperStore_API.Web.Controllers
{
    [RoutePrefix("api/bravo")]
    public class BravoController : ApiController
    {
        [Route("hello"), HttpGet]
        public HttpResponseMessage Hello()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello");
        }
    }
}
