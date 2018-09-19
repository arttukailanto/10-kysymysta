using System;
using System.IO;
using System.Collections.Generic;
using System.Text;


    class Kysymys
    {
        public string Kysymysteksti { get; set; }
        public List<string> VastausVaihtoehdot;
        public int OikeaVaihtoehto;
        //int kysymysNro;
  
        public Kysymys(int arvottuRiviNro, List<string[]> kokoLista)
        {
            string[] yksiKysymys = kokoLista[arvottuRiviNro];
            this.Kysymysteksti = yksiKysymys[0];
            this.OikeaVaihtoehto = Int32.Parse(yksiKysymys[1]);
            string[] erotellut = yksiKysymys[2].Split('*');
            List<string> vaihtoehdot = new List<string>();
            foreach (string elem in erotellut)
            {
                vaihtoehdot.Add(elem);
            }
           this.VastausVaihtoehdot = vaihtoehdot;
        }
        public override string ToString() {
            return (Kysymysteksti + "\n\n" + VastausVaihtoehdot[0] + "\n" + VastausVaihtoehdot[1] + "\n" + VastausVaihtoehdot[2] + "\n");
        }
        public bool TarkistaVastaus(string kayttajanVastaus) {
            if (this.OikeaVaihtoehto == int.Parse(kayttajanVastaus)) {
                return true;
            } else {
                return false;
            }
        }
        public void TulostaKysymys()
        {
            Console.WriteLine(Kysymysteksti + "\n\n" + VastausVaihtoehdot[0] + "\n" + VastausVaihtoehdot[1] + "\n" + VastausVaihtoehdot[2] + "\n");
    }
    }

