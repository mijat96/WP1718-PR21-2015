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
        // POST api/vozac
        public bool Post([FromBody]Vozac korisnik)
        {
            if(Vozaci.vozaci==null)
            {
                Vozaci.vozaci = new Dictionary<int, Vozac>(); 
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

            
            SomeType s = new SomeType();
            korisnik.Id = s.GetHashCode();
            korisnik.Uloga = Enums.Uloga.Vozac;
            korisnik.Automobil.IdVozaca = korisnik.Id;
            korisnik.Zauzet = false;
            Vozaci.vozaci.Add(korisnik.Id, korisnik);
            UpisTxt(korisnik);
            return true;

        }

        private void UpisTxt(Vozac k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga +'|' + k.Lokacija.IdLok.ToString() + '|' + k.Lokacija.X.ToString() + '|' + k.Lokacija.Y.ToString() + '|' + k.Lokacija.Adresa.IdAdr.ToString() + '|' + k.Lokacija.Adresa.UlicaIBroj + '|' + k.Lokacija.Adresa.NaseljenoMesto + '|' + k.Lokacija.Adresa.PozivniBroj + '|' + k.Automobil.IdVozaca.ToString() + '|' + k.Automobil.Godiste + '|' + k.Automobil.Registracija + '|' + k.Automobil.BrojVozila.ToString() + '|' + k.Automobil.TipAuta + '|' + k.Zauzet.ToString() + '|' + k.Banovan.ToString();
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
                    if (kor.Id == id)
                    {
                        Vozaci.vozaci.Remove(kor.Id);
                        Vozaci.vozaci.Add(korisnik.Id, korisnik);
                        UpisIzmenaTxt(korisnik);
                        return true;
                    }
                }
            return false;
        }

        private void UpisIzmenaTxt(Vozac k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga  + '|' + k.Lokacija.IdLok.ToString() + '|' + k.Lokacija.X.ToString() + '|' + k.Lokacija.Y.ToString() + '|' + k.Lokacija.Adresa.IdAdr.ToString() + '|' + k.Lokacija.Adresa.UlicaIBroj + '|' + k.Lokacija.Adresa.NaseljenoMesto + '|' + k.Lokacija.Adresa.PozivniBroj + '|' + k.Automobil.IdVozaca.ToString() + '|' + k.Automobil.Godiste + '|' + k.Automobil.Registracija + '|' + k.Automobil.BrojVozila.ToString() + '|' + k.Automobil.TipAuta + '|' + k.Zauzet.ToString() + '|' + k.Zauzet.ToString();
                    lines[i] = allString;

                }
            }
            System.IO.File.WriteAllLines(path, lines);

        }

        // GET api/vozac
        public Dictionary<int, Vozac> Get()
        {
            return Vozaci.vozaci;
        }


        // GET api/vozac/5
        public Vozac Get(int id)
        {
            return Vozaci.vozaci[id];
        }
    }
}
