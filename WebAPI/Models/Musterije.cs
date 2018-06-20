using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Musterije
    {
        public static Dictionary<string, Musterija> musterije { get; set; } = new Dictionary<string, Musterija>();

        public Musterije() { }

        public Musterije(string path)
        {

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            EnumPol pol;
            EnumUloga uloga;
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');
                if (tokens[4].Equals("Musko"))
                {
                    pol = EnumPol.MUSKO;
                }
                else
                {
                    pol = EnumPol.ZENSKO;
                }
                if (tokens[8].Equals("Musterija"))
                {
                    uloga = EnumUloga.MUSTERIJA;
                }
                else if (tokens[8].Equals("Dispecer"))
                {
                    uloga = EnumUloga.DISPECER;
                }
                else
                {
                    uloga = EnumUloga.VOZAC;
                }

                //public Musterija(string kIme, string lozinka, string ime, string prezime, EnumPol pol, string jmbg, string kontakt, string email, EnumUloga uloga)
                Musterija k = new Musterija(tokens[0], tokens[1], tokens[2], tokens[3], pol, tokens[6], tokens[7], tokens[8], uloga);
                musterije.Add(k.KorisnickoIme, k);
            }
            sr.Close();
            stream.Close();
        }

    }
}