using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Adresa
    {
        public string UlicaBroj { get; set; }

        public string NaseljenoMestoPBroj { get; set; }

        public Adresa() { }
        public Adresa(string ulicaBroj, string naseljenoMestoPBroj)
        {
            this.UlicaBroj = ulicaBroj;
            this.NaseljenoMestoPBroj = naseljenoMestoPBroj;
        }

}
}