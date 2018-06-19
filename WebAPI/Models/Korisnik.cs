using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public EnumPol Pol { get; set; }
        public string JMBG { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public EnumUloga Uloga { get; set; }
        public List<Voznja> Voznje { get; set; }

        public Korisnik()
        {
            Voznje = new List<Voznja>();
        }

        public Korisnik(string kIme, string lozinka, string ime, string prezime, EnumPol pol, string jmbg, string kontakt, string email, EnumUloga uloga)
        {
            this.KorisnickoIme = kIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.JMBG = jmbg;
            this.KontaktTelefon = kontakt;
            this.Email = email;

            if (pol.Equals("MUSKO"))
                this.Pol = EnumPol.MUSKO;
            else
                this.Pol = EnumPol.ZENSKO;           


            if (uloga.ToString().Equals("MUSTERIJA"))
                this.Uloga = EnumUloga.MUSTERIJA;
            else if (uloga.ToString().Equals("DISPECXER"))
                this.Uloga = EnumUloga.DISPECER;
            else
                this.Uloga = EnumUloga.VOZAC;

            Voznje = new List<Voznja>();
        }
    }
}