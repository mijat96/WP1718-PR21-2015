using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {
        public DateTime DatumVremePorudzbine { get; set; } 
        public Lokacija LokacijaDolaska { get; set; }
        public EnumAutomobil TipAutomobila { get; set; } //bez naznake - podrazumevano
        public string Musterija { get; set; } //samo ako musterija inicira kreiranje voznje
        public Lokacija LokacijaZavrseneVoznje { get; set; } //vozac azurira u trenutku kada se voznja zavrsi
        public string Dispecer { get; set; } //ako je formirao ili obradio voznju, ako je vozac prihvatio onda je prazno
        public string Vozac { get; set; } //koji je prihvatio voznju ili kome je voznja dodeljena od dispecera
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; } //za otkazane voznje obavezan za uspesne nije
        public EnumStatus StatusVoznje { get; set; } //Kreirana - Na čekanju, Formirana, Obrađena, Prihvaćena, Otkazana, Neuspešna, Uspešna
        public int IdVoznje { get; set; }
        public Voznja() { }

        public Voznja(int idvoznje, DateTime dtporudzbine, Lokacija dolazak, EnumAutomobil tipAutomobila, string musterija, Lokacija odrediste, string vozac, double iznos, string dispecer, Komentar komentar, EnumStatus statusVoznje)
        {
            this.IdVoznje = idvoznje;
            this.DatumVremePorudzbine = dtporudzbine;
            this.LokacijaDolaska = dolazak;
            if (tipAutomobila.Equals("Kombi"))
            {
                this.TipAutomobila = EnumAutomobil.KOMBI;
            }
            else
            {
                this.TipAutomobila = EnumAutomobil.PUTNICKI;
            }

            this.Musterija = musterija;
            this.LokacijaZavrseneVoznje = odrediste;
            this.Dispecer = dispecer;
            this.Vozac = vozac;
            this.Iznos = iznos;
            this.Komentar = komentar;

            if (statusVoznje.ToString().Equals("Formirana"))
            {
                this.StatusVoznje = EnumStatus.FORMIRANA;
            }
            else if (statusVoznje.ToString().Equals("Kreirana"))
            {
                this.StatusVoznje = EnumStatus.KREIRANA;
            }
            else if (statusVoznje.ToString().Equals("Neuspesna"))
            {
                this.StatusVoznje = EnumStatus.NEUSPESNA;
            }
            else if (statusVoznje.ToString().Equals("Obradjena"))
            {
                this.StatusVoznje = EnumStatus.OBRADJENA;
            }
            else if (statusVoznje.ToString().Equals("Otkazana"))
            {
                this.StatusVoznje = EnumStatus.OTKAZANA;
            }
            else if (statusVoznje.ToString().Equals("Prihvacena"))
            {
                this.StatusVoznje = EnumStatus.PRIHVACENA;
            }
            else if (statusVoznje.ToString().Equals("Uspesna"))
            {
                this.StatusVoznje = EnumStatus.USPESNA;
            }
            else
            {
                this.StatusVoznje = EnumStatus.TRAJE;
            }

        }

    }
}