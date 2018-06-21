using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznje
    {
        public static Dictionary<int, Voznja> voznje { get; set; } = new Dictionary<int, Voznja>();

        public Voznje() { }

        public Voznje(string path)
        {

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);

            EnumStatus status;
            EnumAutomobil tip;
            Lokacija pomLokDolazak;
            Lokacija pomLokOdrediste;
            Komentar pomKomentar;
            Adresa pomAdresa;
            Adresa pomAdresa1;



            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');

                if (tokens[9].Equals("Kombi"))
                {
                    tip = EnumAutomobil.KOMBI;
                }
                else
                {
                    tip = EnumAutomobil.PUTNICKI;
                }

                if (tokens[26].Equals("Formirana"))
                {
                    status = EnumStatus.FORMIRANA;
                }
                else if (tokens[26].Equals("Kreirana"))
                {
                    status = EnumStatus.KREIRANA;
                }
                else if (tokens[26].Equals("Neuspesna"))
                {
                    status = EnumStatus.NEUSPESNA;
                }
                else if (tokens[26].Equals("Obradjena"))
                {
                    status = EnumStatus.OBRADJENA;
                }
                else if (tokens[26].Equals("Otkazana"))
                {
                    status = EnumStatus.OTKAZANA;
                }
                else if (tokens[26].Equals("Prihvacena"))
                {
                    status = EnumStatus.PRIHVACENA;
                }
                else if (tokens[26].Equals("Uspesna"))
                {
                    status = EnumStatus.USPESNA;
                }
                else
                {
                    status = EnumStatus.TRAJE;
                }

                pomAdresa = new Adresa(tokens[7], tokens[8]);
                pomLokDolazak = new Lokacija(Double.Parse(tokens[3]), Double.Parse(tokens[4]));
                pomAdresa1 = new Adresa(tokens[15], tokens[16]);
                pomLokOdrediste = new Lokacija(Double.Parse(tokens[12]), Double.Parse(tokens[13]));
                pomKomentar = new Komentar(tokens[21], DateTime.Parse(tokens[22]), tokens[23], Int32.Parse(tokens[24]), Int32.Parse(tokens[25]));
                Voznja v = new Voznja(Int32.Parse(tokens[0]), DateTime.Parse(tokens[1]), pomLokDolazak, tip, tokens[10], pomLokOdrediste, tokens[18], Double.Parse(tokens[19]), tokens[20], pomKomentar, status);
                voznje.Add(v.IdVoznje, v);
            }
            sr.Close();
            stream.Close();
        }
    }
}