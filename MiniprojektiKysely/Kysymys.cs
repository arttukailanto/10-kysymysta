using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniprojektiKysely
{
    class Kysymys
    {
        public string KysymysTeksti { get; }
        public List<string> Vaihtoehdot { get; }
        public string Vastaus { get; set; }

        public Kysymys(string kysymysTeksti, string[] vaihtoehdot, string vastaus)
        {
            KysymysTeksti = kysymysTeksti;
            Vaihtoehdot = vaihtoehdot.ToList<string>();
            Vastaus = vastaus;
        }
        public Kysymys(string kysymysTeksti)
        {
            KysymysTeksti = kysymysTeksti;
            Vaihtoehdot = new List<string> { };
        }

        public bool Tarkasta(string vastaus)
        {
            // palauttaa true tai false, riippuen siitä onko vastaus oikein


            return (Vastaus.ToUpper() == vastaus.Trim().ToUpper());
        }

        public bool ValidoiVastaus(string vastaus)
        {
            if (vastaus.Length > 4 || vastaus.Length < 1)
                return false;
            return true;
        }

    }
}
