using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public class PKW
    {
        public string Hersteller { get; set; }
        public string Model { get; set; }
        public double Preis { get; set; }


        public override string ToString()
        {
            return this.Hersteller + " " + this.Model;
        }
    }
}
