using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozaci
    {
        public static Dictionary<string, Vozac> vozaci { get; set; } = new Dictionary<string, Vozac>();

        public Vozaci() { }

        public Vozaci(string path)
        {

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            EnumPol pol;
            EnumUloga uloga;
            EnumAutomobil tip;

            Lokacija pomLok;
            Automobil pomAuto;
            Adresa pomAdresa;

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');

                if (tokens[4].Equals("M"))
                {
                    pol = EnumPol.MUSKO;
                }
                else
                {
                    pol = EnumPol.ZENSKO;
                }
                
                uloga = EnumUloga.VOZAC;

                if (tokens[21].Equals("Kombi"))
                {
                    tip = EnumAutomobil.KOMBI;
                }
                else
                {
                    tip = EnumAutomobil.PUTNICKI;
                }

                pomAdresa = new Adresa(tokens[14], tokens[15]);
                pomLok = new Lokacija(Double.Parse(tokens[11]), Double.Parse(tokens[12]));
                pomAuto = new Automobil(tokens[13], tokens[18], tokens[19], Int32.Parse(tokens[20]), tip);
                Vozac v = new Vozac( tokens[1], tokens[2], tokens[3], tokens[4], pol, tokens[6], tokens[7], tokens[8], uloga, pomLok, pomAuto, bool.Parse(tokens[22]));
                vozaci.Add(v.KorisnickoIme, v);
            }
            sr.Close();
            stream.Close();
        }
    }
}