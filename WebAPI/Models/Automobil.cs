using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Automobil
    {
        public Vozac Vozac { get; set }
        public string Godiste { get; set }
        public string Registracija { get; set }
        public int BrojVozila { get; set }
        public EnumAutomobil TipAutomobila { get; set }

        public Automobil() { }
        public Automobil(Vozac vozac, string godiste, string registracija, int broj, EnumAutomobil tip)
        {
            this.Vozac = vozac;
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