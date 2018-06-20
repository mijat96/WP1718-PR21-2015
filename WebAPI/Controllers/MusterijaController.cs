using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class MusterijaController : ApiController
    {
        // POST api/post
        public bool Post([FromBody]Musterija korisnik)
        {

            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            Musterije.musterije = new Dictionary<string, Musterija>();
            korisnik.Uloga = EnumUloga.MUSTERIJA;
            Musterije.musterije.Add(korisnik.KorisnickoIme, korisnik);
            UpisTxt(korisnik);
            return true;

        }

        private void UpisTxt(Musterija k)
        {
            FileStream stream = new FileStream(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Musterije.txt", FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                tw.WriteLine(upis);
            }
            stream.Close();
        }
    }
}
