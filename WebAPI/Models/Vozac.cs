using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozac : Korisnik
    {
        public Lokacija lokacija { get; set; }
        public Automobil automobil { get; set; }

        public bool slobodan { get; set; }

        public Vozac() { }

        public Vozac(string kIme, string lozinka, string ime, string prezime, EnumPol pol, string jmbg, string kontakt, string email, EnumUloga uloga, Lokacija lok, Automobil auto, bool slobodan) 
                    : base(kIme, lozinka, ime, prezime, pol, jmbg, kontakt, email, uloga)
        {
            this.slobodan = slobodan;
            this.lokacija = lok;
            this.automobil = auto;
        }

    }
}