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
                    Dispeceri.dispeceri.Remove(kor.Id);
                    Dispecer d = new Dispecer(korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.JMBG, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
                    Dispeceri.dispeceri.Add(d.Id, d);
                    UpisIzmenaDisp(korisnik);
                    return true;
                }
            }
            return false;
        }

        private void UpisIzmenaDisp(Dispecer k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Dispeceri.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\WebAPI\WP1718-PR21-2015\WebAPI\App_Data\Dispeceri.txt", lines);
        }
    }
}
