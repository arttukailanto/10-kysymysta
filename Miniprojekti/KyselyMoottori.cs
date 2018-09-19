using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniprojektiKysely
{
    class KyselyMoottori
    {
        private List<Kysymys2> Kysymykset { get; set; } = new List<Kysymys2> { };
        public float Pisteet { get; set; }
        public int KysymystenMaara { get=> Kysymykset.Count;  }

        public KyselyMoottori()
        {

        }

        public bool HaeKysymykset()
        {
            string tiedosto = @"../../kysymykset2.txt";
            if (!File.Exists(tiedosto))
                return false;
            string[] rivit = File.ReadAllLines(tiedosto);
            Kysymys2 tempKysymys = null;
            foreach (string rivi in rivit)
            {
                if (rivi[0] == '.')
                {
                    // on kysymys
                    tempKysymys = new Kysymys2(rivi.Substring(1).Trim());
                }
                else if (rivi[0] == '\t')
                {
                    // on vastausvaihtoehto
                    tempKysymys.Vaihtoehdot.Add(rivi.Substring(1).Trim());
                }
                else if (rivi[0] == '*' && rivi[1] == '*')
                {
                    // on vastaus
                    tempKysymys.Vastaus = rivi.Substring(2).Trim();
                    Kysymykset.Add(tempKysymys);
                }
                else
                {
                    return false;
                }
            }
            return true;

            //string[] rivit = File.ReadAllLines("kysymykset.txt");
            //Console.WriteLine(rivit.ToString());
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys0", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys1", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys2", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys3", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys4", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys5", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys6", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys7", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys8", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys9", new string[] { "On", "Ei" }, "A"));
            ////Kysymykset.Add(new Kysymys("Onko tämä kysymys10", new string[] { "On", "Ei" }, "A"));
            //return true; // onistuiko haku
        }

        public Kysymys2 AnnaKysymys()
        {
            //Kysymys tempKysymys = Kysymykset[0];
            //Kysymykset.RemoveAt(0);
            Kysymys2 tempKysymys;
            int kysIndeksi = new Random().Next(0, Kysymykset.Count - 1);
            tempKysymys = Kysymykset[kysIndeksi];
            Kysymykset.RemoveAt(kysIndeksi);
            return tempKysymys;
        }

    }


}
