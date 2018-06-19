using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Lokacija
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Adresa adresa;

        public Lokacija() { }
        public Lokacija(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}