using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DispecerController : ApiController
    {
        public bool Put(int id, [FromBody]Dispecer korisnik)
        {
            foreach (Dispecer kor in Dispeceri.dispeceri.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    Dispeceri.dispeceri.Remove(kor.KorisnickoIme);
                    Dispecer d = new Dispecer(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.JMBG, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
                    Dispeceri.dispeceri.Add(d.KorisnickoIme, d);
                    UpisIzmenaDisp(korisnik);
                    return true;
                }
            }
            return false;
        }

        private void UpisIzmenaDisp(Dispecer k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Dispeceri.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.KorisnickoIme))
                {
                    allString += '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}
