using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viikko1_mini_10kysymysta
{
    class Program
    {
        static void Main(string[] args)
        {
            Kysymys kysymys = new Kysymys();
            string vastaus = "";
            int pisteet = 0;
            


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(kysymys.KysyKysymys());
                Console.Write("Vastaus: ");

                vastaus = Console.ReadLine();

                if ( vastaus == "k" || vastaus == "K")
                {
                    pisteet++;
                    Console.WriteLine("Oikea vastaus!");
                        
                }
                
                else
                {
                    Console.WriteLine("Vastaus väärin :( ");
                }
               
            }
            Console.WriteLine("Pistemääräsi on: " + pisteet);

            Console.ReadLine();

        }

    }
}
