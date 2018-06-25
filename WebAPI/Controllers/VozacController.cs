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
    public class VozacController : ApiController
    {
        public bool Post([FromBody]Vozac korisnik)
        {
            if (Vozaci.vozaci == null)
            {
                Vozaci.vozaci = new Dictionary<string, Vozac>();
            }


            foreach (Vozac kor in Vozaci.vozaci.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }
            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            foreach (Dispecer kor in Dispeceri.dispeceri.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            korisnik.Uloga = EnumUloga.VOZAC;
            korisnik.automobil.VozacKorIme = korisnik.KorisnickoIme;
            korisnik.slobodan = false;
            Vozaci.vozaci.Add(korisnik.KorisnickoIme, korisnik);
            UpisTxt(korisnik);
            return true;

        }

        private void UpisTxt(Vozac k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.lokacija.IdLokacije.ToString() + '|' + k.lokacija.X.ToString() + '|' + k.lokacija.Y.ToString() + '|' + k.lokacija.adresa.IdAdrese.ToString() + '|' + k.lokacija.adresa.UlicaBroj + '|' + k.lokacija.adresa.NaseljenoMestoPBroj + '|' + k.automobil.VozacKorIme + '|' + k.automobil.Godiste + '|' + k.automobil.Registracija + '|' + k.automobil.BrojVozila.ToString() + '|' + k.automobil.TipAutomobila + '|' + k.slobodan.ToString();
                tw.WriteLine(upis);
            }
            stream.Close();
        }

        public class SomeType
        {
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public static int GetHashCode2()
        {
            return Int32.MaxValue.GetHashCode();
        }

        // PUT api/vozac/5
        public bool Put(int id, [FromBody]Vozac korisnik)
        {
            foreach (Vozac kor in Vozaci.vozaci.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    Vozaci.vozaci.Remove(kor.KorisnickoIme);
                    Vozaci.vozaci.Add(korisnik.KorisnickoIme, korisnik);
                    UpisIzmjenaTxt(korisnik);
                    return true;
                }
            }
            return false;
        }

        private void UpisIzmjenaTxt(Vozac k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.KorisnickoIme))
                {
                    allString += '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.lokacija.IdLokacije.ToString() + '|' + k.lokacija.X.ToString() + '|' + k.lokacija.Y.ToString() + '|' + k.lokacija.adresa.IdAdrese.ToString() + '|' + k.lokacija.adresa.UlicaBroj + '|' + k.lokacija.adresa.NaseljenoMestoPBroj + '|' + k.automobil.VozacKorIme + '|' + k.automobil.Godiste + '|' + k.automobil.Registracija + '|' + k.automobil.BrojVozila.ToString() + '|' + k.automobil.TipAutomobila + '|' + k.slobodan.ToString();
                    lines[i] = allString;

                }
            }
            System.IO.File.WriteAllLines(path, lines);

        }

        // GET api/vozac
        public Dictionary<string, Vozac> Get()
        {
            return Vozaci.vozaci;
        }


        // GET api/vozac/5
        public Vozac Get(string korIme)
        {
            return Vozaci.vozaci[korIme];
        }
    }
}
