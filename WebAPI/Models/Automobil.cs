using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobil
    {
        public string VozacKorIme { get; set; }
        public string Godiste { get; set; }
        public string Registracija { get; set; }
        public int BrojVozila { get; set; }
        public EnumAutomobil TipAutomobila { get; set; }

        public Automobil() { }
        public Automobil(string vozac, string godiste, string registracija, int broj, EnumAutomobil tip)
        {
            this.VozacKorIme = vozac;
            this.Godiste = godiste;
            this.Registracija = registracija;
            this.BrojVozila = broj;
            if (tip.ToString().Equals("PUTNICKI"))
                this.TipAutomobila = EnumAutomobil.PUTNICKI;
            else
                this.TipAutomobila = EnumAutomobil.KOMBI;
        }
    }
}