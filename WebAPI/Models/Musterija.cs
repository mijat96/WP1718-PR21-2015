using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Musterija : Korisnik
    {
        public bool stigao;

        public Musterija() { }

        public Musterija(string kIme, string lozinka, string ime, string prezime, EnumPol pol, string jmbg, string kontakt, string email, EnumUloga uloga)
                    : base(kIme, lozinka, ime, prezime, pol, jmbg, kontakt, email, uloga) { }
    }
}