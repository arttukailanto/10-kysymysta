using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viikko1_mini_10kysymysta
{
    class Kysymys
    {
        private string kysymysTeksti;
        private List<String> vastausVaihtoehdot;
        private int oikeanVaihtoehdonIndeksi;
        public string KysymysTeksti { get => kysymysTeksti; set => kysymysTeksti = value; }
        //public List<string> VastausVaihtoehdot { get => vastausVaihtoehdot; set => vastausVaihtoehdot = value; }
        public int OikeanVaihtoehdonIndeksi { get => oikeanVaihtoehdonIndeksi; set => oikeanVaihtoehdonIndeksi = value; }

        public string KysyKysymys()
        {
            string[] kysymykset = File.ReadAllLines(@"C:\Users\Miika Chorin\source\\repos\Viikko1\Viikko1 mini_10kysymysta_sol\Viikko1 mini_10kysymysta\Kysymykset.txt");
            
            Random r = new Random();

            for (int i = kysymykset.Length; i > 1;)
            {
                int k = r.Next(i--);
                string temp = kysymykset[i];
                kysymykset[i] = kysymykset[k];
                kysymykset[k] = temp;
            }








            //foreach (var kysymys in kysymykset)
            //{
            ////Console.WriteLine(kysymys);
            //}
            return kysymykset[0].Split('*')[0];
           // Console.ReadKey();
            //Console.WriteLine(kysymykset[0].Split('*')[0]);
            //return "";
            //return "Tämä on esimerkkikysymys";
        }
    }
}
