using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        public bool Post([FromBody]Korisnik korisnik)
        {
            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme || kor.Lozinka == korisnik.Lozinka)
                {
                    return true;
                }

            }

            return false;
        }
        
    }
}
