using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI.Controllers
{
    public class DefaultController : ApiController
    {
        //svaki put kad se pokrene vratice se index stranica, pokretanje pocetne stranice
        [HttpGet, Route("")] //
        public RedirectResult Index()
        {
            var requestUri = Request.RequestUri;    //
            return Redirect(requestUri.AbsoluteUri + "index.html");
        }
    }
}
