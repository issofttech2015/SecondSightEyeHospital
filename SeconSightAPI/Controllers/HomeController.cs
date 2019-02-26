using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SeconSightAPI.Controllers
{
    [RoutePrefix("API")]
    public class HomeController : ApiController
    {
        [Route("Hello")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
