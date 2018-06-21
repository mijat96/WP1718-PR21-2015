using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Dispeceri
    {
        public static Dictionary<string, Dispecer> dispeceri { get; set; } = new Dictionary<string, Dispecer>();

        public Dispeceri() { }

        public Dispeceri(string path)
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

                uloga = EnumUloga.DISPECER;
                
                Dispecer d = new Dispecer(tokens[0], tokens[1], tokens[2], tokens[3], pol, tokens[5], tokens[6], tokens[7], uloga);
                dispeceri.Add(d.KorisnickoIme, d);
            }
            sr.Close();
            stream.Close();
        }
    }
}