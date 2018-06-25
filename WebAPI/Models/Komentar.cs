﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Komentar
    {
        public string Opis { get; set; }
        public DateTime DTObjave { get; set; }
        public string KorImeKorisnikKomentar { get; set; }
        public int IdVoznjaKomentar { get; set; }
        public int Ocena { get; set; }

        public Komentar() { }
        public Komentar(string opis, DateTime datum, string korimekorisnika, int idvoznje, int Ocena)
        {
            this.Opis = opis;
            this.DTObjave = datum;
            this.KorImeKorisnikKomentar = korimekorisnika;
            this.IdVoznjaKomentar = idvoznje;
            this.Ocena = Ocena;
        }
             

    }
}