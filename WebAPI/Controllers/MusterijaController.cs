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
                string upis = '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                tw.WriteLine(upis);
            }
            stream.Close();
        }

        public bool Put(int id, [FromBody]Musterija korisnik)
        {
            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    if (korisnik.KorisnickoIme == null)
                    {
                        korisnik.KorisnickoIme = kor.KorisnickoIme;
                    }

                    if (korisnik.Lozinka == null)
                    {
                        korisnik.Lozinka = kor.Lozinka;
                    }

                    if (korisnik.Ime == null)
                    {
                        korisnik.Ime = kor.Ime;
                    }

                    if (korisnik.Prezime == null)
                    {
                        korisnik.Prezime = kor.Prezime;
                    }

                    korisnik.Pol = kor.Pol;

                    if (korisnik.JMBG == null)
                    {
                        korisnik.JMBG = kor.JMBG;
                    }

                    if (korisnik.Email == null)
                    {
                        korisnik.Email = kor.Email;
                    }

                    if (korisnik.KontaktTelefon == null)
                    {
                        korisnik.KontaktTelefon = kor.KontaktTelefon;
                    }

                    korisnik.Uloga = kor.Uloga;

                    Musterije.musterije.Remove(kor.KorisnickoIme);
                    Musterije.musterije.Add(korisnik.KorisnickoIme, korisnik);
                    UpisTxt(korisnik);
                    return true;
                }
            }
            return false;
        }

        public Dictionary<string, Musterija> Get()
        {
            return Musterije.musterije;
        }

        // GET api/musterija/5
        public Musterija Get(string korIme)
        {
            return Musterije.musterije[korIme];
        }
    }
}
