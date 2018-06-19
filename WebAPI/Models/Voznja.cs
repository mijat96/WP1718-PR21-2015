using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznja
    {
        public DateTime DatumVremePorudzbine { get; set; } 
        public Lokacija lokacijaDolaska { get; set; }
        public EnumAutomobil tipAutomobila { get; set; } //bez naznake - podrazumevano
        public Musterija musterija { get; set; } //samo ako musterija inicira kreiranje voznje
        public Lokacija LokacijaZavrseneVoznje { get; set; } //vozac azurira u trenutku kada se voznja zavrsi
        public Dispecer dispecer { get; set; } //ako je formirao ili obradio voznju, ako je vozac prihvatio onda je prazno
        public Vozac vozac { get; set; } //koji je prihvatio voznju ili kome je voznja dodeljena od dispecera
        public double iznos { get; set; }
        public Komentar komentar { get; set; } //za otkazane voznje obavezan za uspesne nije
        public EnumStatus statusVoznje { get; set; } //Kreirana - Na čekanju, Formirana, Obrađena, Prihvaćena, Otkazana, Neuspešna, Uspešna

        public Voznja() { }

    }
}