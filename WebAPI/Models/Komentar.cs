using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Komentar
    {
        public string Opis { get; set }
        public DateTime DatumObjave { get; set }
        public Korisnik Korisnik { get; set }
        public Voznja Voznja { get; set }
        public int Ocena { get; set } //vrednost od 1 do 5, 0 vrednost se tumači tako kao da mušterija nije ocenila vožnju

        public Komentar() { }

        public Komentar(string opis, DateTime datum, Korisnik korisnik, Voznja voznja, int ocena)
        {
            this.Opis = opis;
            this.DatumObjave = datum;
            this.Korisnik = korisnik;
            this.Voznja = voznja;
            this.Ocena = ocena;
        }
    }
}