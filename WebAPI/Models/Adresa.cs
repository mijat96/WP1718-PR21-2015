using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Adresa
    {
        public int IdAdr { get; set; }
        public string UlicaIBroj { get; set; }
        public string NaseljenoMesto { get; set; }
        public string PozivniBroj { get; set; }

        public Adresa() { }

        public Adresa(int idAdr,string ulicabroj,string naseljenomesto,string pozivnibroj)
        {
            this.IdAdr = idAdr;
            this.UlicaIBroj = ulicabroj;
            this.NaseljenoMesto = naseljenomesto;
            this.PozivniBroj = pozivnibroj;
        }
    }
}