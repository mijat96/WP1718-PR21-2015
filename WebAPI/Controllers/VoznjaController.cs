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
    public class VoznjaController : ApiController
    {
        // POST api/voznja
        public bool Post([FromBody]Voznja voznja)
        {

            if (Voznje.voznje != null)
            {
                //foreach (Voznja kor in Voznje.voznje.Values)
                //{
                //    if (kor.Dolazak.Adresa.UlicaIBroj == voznja.Dolazak.Adresa.UlicaIBroj)
                //    {
                //        return false;
                //    }
                //}
                SomeType s = new SomeType();
                SomeType s1 = new SomeType();
                SomeType s2 = new SomeType();
                voznja.IdVoznje = s.GetHashCode();
                voznja.DatumVremePorudzbine = DateTime.Now;
                voznja.LokacijaDolaska.adresa.IdAdrese = s1.GetHashCode();
                voznja.LokacijaDolaska.IdLokacije = s2.GetHashCode();

                if (voznja.Musterija != null)
                {
                    voznja.StatusVoznje = EnumStatus.KREIRANA;
                }
                else if (voznja.Dispecer != null)
                {
                    voznja.StatusVoznje = EnumStatus.FORMIRANA;
                    foreach (Vozac v in Vozaci.vozaci.Values)
                    {
                        if (v.KorisnickoIme == voznja.Vozac)
                        {
                            v.slobodan = true;
                            UpisIzmjenaTxtVozac(v);
                        }
                    }
                }
                
                voznja.Komentar = new Komentar();
                voznja.LokacijaZavrseneVoznje = new Lokacija();
                Voznje.voznje.Add(voznja.IdVoznje, voznja);
                UpisTxt(voznja);
                return true;
            }

            if (Voznje.voznje == null)
            {
                Voznje.voznje = new Dictionary<int, Voznja>();
                SomeType s = new SomeType();
                voznja.IdVoznje = s.GetHashCode();
                voznja.DatumVremePorudzbine = DateTime.Now;
                if (voznja.Musterija != null && voznja.StatusVoznje != EnumStatus.OTKAZANA)
                {
                    voznja.StatusVoznje = EnumStatus.KREIRANA;
                }
                else if (voznja.Dispecer != null)
                {
                    voznja.StatusVoznje = EnumStatus.FORMIRANA;
                }
                else
                {
                    voznja.StatusVoznje = EnumStatus.PRIHVACENA;
                }
                voznja.Komentar = new Komentar();
                voznja.LokacijaZavrseneVoznje = new Lokacija();
                Voznje.voznje.Add(voznja.IdVoznje, voznja);
                UpisTxt(voznja);
                return true;
            }
            return false;

        }

        private void UpisTxt(Voznja k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Voznje.txt");
            FileStream stream = new FileStream(path, FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.IdVoznje.ToString() + '|' + k.DatumVremePorudzbine.ToString() + '|' + k.LokacijaDolaska.IdLokacije.ToString() + '|' + k.LokacijaDolaska.X.ToString() + '|' + k.LokacijaDolaska.Y.ToString() + '|' + k.LokacijaDolaska.adresa.IdAdrese.ToString() + '|' + k.LokacijaDolaska.adresa.UlicaBroj + '|' + k.LokacijaDolaska.adresa.NaseljenoMestoPBroj  + '|' + k.TipAutomobila + '|' + k.Musterija + '|' + k.LokacijaZavrseneVoznje.IdLokacije.ToString() + '|' + k.LokacijaZavrseneVoznje.X.ToString() + '|' + k.LokacijaZavrseneVoznje.Y.ToString() + '|' + k.LokacijaZavrseneVoznje.adresa.IdAdrese.ToString() + '|' + k.LokacijaZavrseneVoznje.adresa.UlicaBroj + '|' + k.LokacijaZavrseneVoznje.adresa.NaseljenoMestoPBroj + '|' + k.Vozac + '|' + k.Iznos.ToString() + '|' + k.Dispecer + '|' + k.Komentar.Opis + '|' + k.Komentar.DatumObjave.ToString() + '|' + k.Komentar.Korisnik + '|' + k.Komentar.Voznja.ToString() + '|' + k.Komentar.Ocena.ToString() + '|' + k.StatusVoznje;
                tw.WriteLine(upis);
                //tw.Flush();
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


        // GET api/voznja
        public Dictionary<int, Voznja> Get()
        {
            return Voznje.voznje;
        }




        // PUT api/voznja/5
        public bool Put(int id, [FromBody]Voznja korisnik)
        {
            foreach (Voznja kor in Voznje.voznje.Values)
            {
                if (kor.IdVoznje == id)
                {
                    korisnik.TipAutomobila = kor.TipAutomobila;
                    korisnik.IdVoznje = kor.IdVoznje;
                    korisnik.DatumVremePorudzbine = kor.DatumVremePorudzbine;
                    if (korisnik.StatusVoznje == EnumStatus.OTKAZANA)     //*******************
                    {
                        korisnik.LokacijaDolaska = new Lokacija();
                        korisnik.LokacijaDolaska.IdLokacije = kor.LokacijaDolaska.IdLokacije;
                        korisnik.LokacijaDolaska.X = kor.LokacijaDolaska.X;
                        korisnik.LokacijaDolaska.Y = kor.LokacijaDolaska.Y;
                        korisnik.LokacijaDolaska.adresa.IdAdrese = kor.LokacijaDolaska.adresa.IdAdrese;
                        korisnik.LokacijaDolaska.adresa.UlicaBroj = kor.LokacijaDolaska.adresa.UlicaBroj;
                        korisnik.LokacijaDolaska.adresa.NaseljenoMestoPBroj = kor.LokacijaDolaska.adresa.NaseljenoMestoPBroj;
                        //korisnik.LokacijaDolaska.adresa.PozivniBroj = kor.LokacijaDolaska.adresa.PozivniBroj;
                        korisnik.LokacijaDolaska = new Lokacija();


                    }
                    else if (korisnik.StatusVoznje == EnumStatus.KREIRANA)  //*******************
                    {
                        if (korisnik.Vozac == null && korisnik.Dispecer == null)
                        {
                            if (kor.Komentar != null)
                            {
                                korisnik.Komentar = new Komentar();
                                korisnik.Komentar = kor.Komentar;
                            }
                            else
                            {
                                korisnik.Komentar = new Komentar();
                            }
                            korisnik.LokacijaZavrseneVoznje = new Lokacija();
                        }
                        else if (korisnik.Vozac != null && korisnik.Dispecer != null)
                        {
                            korisnik.StatusVoznje = EnumStatus.OBRADJENA;
                            korisnik.Musterija = kor.Musterija;
                            foreach (Vozac v in Vozaci.vozaci.Values)
                            {
                                if (v.KorisnickoIme == korisnik.Vozac)
                                {
                                    v.slobodan = true;
                                    UpisIzmjenaTxtVozac(v);
                                }
                            }

                            if (kor.Komentar != null)
                            {
                                korisnik.Komentar = new Komentar();
                                korisnik.Komentar = kor.Komentar;
                            }
                            else
                            {
                                korisnik.Komentar = new Komentar();
                            }
                            korisnik.LokacijaDolaska = new Lokacija();
                            korisnik.LokacijaDolaska.IdLokacije = kor.LokacijaDolaska.IdLokacije;
                            korisnik.LokacijaDolaska.X = kor.LokacijaDolaska.X;
                            korisnik.LokacijaDolaska.Y = kor.LokacijaDolaska.Y;
                            korisnik.LokacijaDolaska.adresa.IdAdrese = kor.LokacijaDolaska.adresa.IdAdrese;
                            korisnik.LokacijaDolaska.adresa.UlicaBroj = kor.LokacijaDolaska.adresa.UlicaBroj;
                            korisnik.LokacijaDolaska.adresa.NaseljenoMestoPBroj = kor.LokacijaDolaska.adresa.NaseljenoMestoPBroj;
                            //korisnik.LokacijaDolaska.Adresa.PozivniBroj = kor.LokacijaDolaska.Adresa.PozivniBroj;
                            korisnik.LokacijaDolaska = new Lokacija();
                        }
                    }
                    else if (korisnik.StatusVoznje == EnumStatus.NEUSPESNA)     //*******************
                    {
                        foreach (Vozac v in Vozaci.vozaci.Values)
                        {
                            if (v.KorisnickoIme == korisnik.Vozac)
                            {
                                v.slobodan = false;
                                UpisIzmjenaTxtVozac(v);
                            }
                        }
                        korisnik.Musterija = kor.Musterija;
                        korisnik.Dispecer = kor.Dispecer;
                        korisnik.LokacijaDolaska = new Lokacija();
                        korisnik.LokacijaDolaska.IdLokacije = kor.LokacijaDolaska.IdLokacije;
                        korisnik.LokacijaDolaska.X = kor.LokacijaDolaska.X;
                        korisnik.LokacijaDolaska.Y = kor.LokacijaDolaska.Y;
                        korisnik.LokacijaDolaska.adresa.IdAdrese = kor.LokacijaDolaska.adresa.IdAdrese;
                        korisnik.LokacijaDolaska.adresa.UlicaBroj = kor.LokacijaDolaska.adresa.UlicaBroj;
                        korisnik.LokacijaDolaska.adresa.NaseljenoMestoPBroj = kor.LokacijaDolaska.adresa.NaseljenoMestoPBroj;
                        //korisnik.LokacijaDolaska.adresa.PozivniBroj = kor.LokacijaDolaska.Adresa.PozivniBroj;
                        korisnik.LokacijaZavrseneVoznje = new Lokacija();


                    }
                    else if (korisnik.StatusVoznje == EnumStatus.USPESNA)
                    {
                        foreach (Vozac v in Vozaci.vozaci.Values)
                        {
                            if (v.KorisnickoIme == korisnik.Vozac)
                            {
                                v.slobodan = false;
                                UpisIzmjenaTxtVozac(v);
                            }
                        }
                        if (korisnik.Komentar == null)
                        {
                            if (kor.Komentar != null)
                            {
                                korisnik.Komentar = new Komentar();
                                korisnik.Komentar = kor.Komentar;
                            }
                            else
                            {
                                korisnik.Komentar = new Komentar();
                            }
                        }

                        if (korisnik.Iznos == 0)
                        {
                            if (kor.Iznos != 0)
                            {

                                korisnik.Iznos = kor.Iznos;
                            }
                        }
                        if (korisnik.Vozac == null)
                        {
                            if (kor.Vozac != null)
                            {

                                korisnik.Vozac = kor.Vozac;
                            }
                        }
                        korisnik.Musterija = kor.Musterija;
                        korisnik.Dispecer = kor.Dispecer;
                        korisnik.LokacijaDolaska = new Lokacija();
                        korisnik.LokacijaDolaska.IdLokacije = kor.LokacijaDolaska.IdLokacije;
                        korisnik.LokacijaDolaska.X = kor.LokacijaDolaska.X;
                        korisnik.LokacijaDolaska.Y = kor.LokacijaDolaska.Y;
                        korisnik.LokacijaDolaska.adresa.IdAdrese = kor.LokacijaDolaska.adresa.IdAdrese;
                        korisnik.LokacijaDolaska.adresa.UlicaBroj = kor.LokacijaDolaska.adresa.UlicaBroj;
                        korisnik.LokacijaDolaska.adresa.NaseljenoMestoPBroj = kor.LokacijaDolaska.adresa.NaseljenoMestoPBroj;
                        //korisnik.LokacijaDolaska.Adresa.PozivniBroj = kor.LokacijaDolaska.adresa.PozivniBroj;
                        if (korisnik.LokacijaZavrseneVoznje == null)
                        {
                            if (kor.LokacijaZavrseneVoznje != null)
                            {
                                korisnik.LokacijaZavrseneVoznje = new Lokacija();
                                korisnik.LokacijaZavrseneVoznje = kor.LokacijaZavrseneVoznje;
                            }
                            else
                            {
                                korisnik.LokacijaZavrseneVoznje = new Lokacija();
                            }
                        }

                    }
                    else if (korisnik.StatusVoznje == EnumStatus.PRIHVACENA)
                    {
                        foreach (Vozac v in Vozaci.vozaci.Values)
                        {
                            if (v.KorisnickoIme == korisnik.Vozac)
                            {
                                v.slobodan = true;
                                UpisIzmjenaTxtVozac(v);
                            }
                        }
                        if (korisnik.Komentar == null)
                        {
                            if (kor.Komentar != null)
                            {
                                korisnik.Komentar = new Komentar();
                                korisnik.Komentar = kor.Komentar;
                            }
                            else
                            {
                                korisnik.Komentar = new Komentar();
                            }
                        }
                        if (korisnik.Dispecer == null)
                        {
                            if (kor.Dispecer != null)
                            {

                                korisnik.Dispecer = kor.Dispecer;
                            }
                        }
                        korisnik.Musterija = kor.Musterija;
                        korisnik.LokacijaDolaska = new Lokacija();
                        korisnik.LokacijaDolaska.IdLokacije = kor.LokacijaDolaska.IdLokacije;
                        korisnik.LokacijaDolaska.X = kor.LokacijaDolaska.X;
                        korisnik.LokacijaDolaska.Y = kor.LokacijaDolaska.Y;
                        korisnik.LokacijaDolaska.adresa.IdAdrese = kor.LokacijaDolaska.adresa.IdAdrese;
                        korisnik.LokacijaDolaska.adresa.UlicaBroj = kor.LokacijaDolaska.adresa.UlicaBroj;
                        korisnik.LokacijaDolaska.adresa.NaseljenoMestoPBroj = kor.LokacijaDolaska.adresa.NaseljenoMestoPBroj;
                        //korisnik.LokacijaDolaska.Adresa.PozivniBroj = kor.LokacijaDolaska.Adresa.PozivniBroj;
                        korisnik.LokacijaZavrseneVoznje = new Lokacija();
                    }
                    Voznje.voznje.Remove(kor.IdVoznje);
                    Voznje.voznje.Add(korisnik.IdVoznje, korisnik);
                    UpisIzmjenaTxt(korisnik);
                    return true;
                }
            }
            return false;
        }

        private void UpisIzmjenaTxt(Voznja k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Voznje.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.IdVoznje.ToString()))
                {
                    allString += k.IdVoznje.ToString() + '|' + k.DatumVremePorudzbine.ToString() + '|' + k.LokacijaDolaska.IdLokacije.ToString() + '|' + k.LokacijaDolaska.X.ToString() + '|' + k.LokacijaDolaska.Y.ToString() + '|' + k.LokacijaDolaska.adresa.IdAdrese.ToString() + '|' + k.LokacijaDolaska.adresa.UlicaBroj + '|' + k.LokacijaDolaska.adresa.NaseljenoMestoPBroj /*+ '|' + k.LokacijaDolaska.adresa.PozivniBroj*/ + '|' + k.TipAutomobila + '|' + k.Musterija + '|' + k.LokacijaZavrseneVoznje.IdLokacije.ToString() + '|' + k.LokacijaZavrseneVoznje.X.ToString() + '|' + k.LokacijaZavrseneVoznje.Y.ToString() + '|' + k.LokacijaZavrseneVoznje.adresa.IdAdrese.ToString() + '|' + k.LokacijaZavrseneVoznje.adresa.UlicaBroj + '|' + k.LokacijaZavrseneVoznje.adresa.NaseljenoMestoPBroj + /*'|' + k.LokacijaZavrseneVoznje.Adresa.PozivniBroj +*/ '|' + k.Vozac + '|' + k.Iznos.ToString() + '|' + k.Dispecer + '|' + k.Komentar.Opis + '|' + k.Komentar.DatumObjave.ToString() + '|' + k.Komentar.Korisnik + '|' + k.Komentar.Voznja.ToString() + '|' + k.Komentar.Ocena.ToString() + '|' + k.StatusVoznje;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(path, lines);

        }

        private void UpisIzmjenaTxtVozac(Vozac k)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Vozaci.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.KorisnickoIme))
                {
                    allString += k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.lokacija.IdLokacije.ToString() + '|' + k.lokacija.X.ToString() + '|' + k.lokacija.Y.ToString() + '|' + k.lokacija.adresa.IdAdrese.ToString() + '|' + k.lokacija.adresa.UlicaBroj + '|' + k.lokacija.adresa.NaseljenoMestoPBroj +  '|' + k.automobil.VozacKorIme + '|' + k.automobil.Godiste + '|' + k.automobil.Registracija + '|' + k.automobil.BrojVozila.ToString() + '|' + k.automobil.TipAutomobila + '|' + k.slobodan.ToString();
                    lines[i] = allString;
                }
            }
            
            System.IO.File.WriteAllLines(path, lines);

        }
    }
}
