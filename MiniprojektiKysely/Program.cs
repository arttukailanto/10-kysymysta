using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniprojektiKysely
{
    class Program
    {
        static void Main(string[] args)
        {
            KyselyMoottori km = new KyselyMoottori();
            if (km.HaeKysymykset())
            {
                // Kysymysten haku onnistui, aloitetaan peli
                int kysMaara = 10;
                char[] vastausEtuliitteet = { 'A', 'B', 'C', 'D' };
                for (int i = 0; i < kysMaara; i++)
                {
                    Kysymys kysymys = km.AnnaKysymys();
                    Console.WriteLine($"Kysymys {i+1}: {kysymys.KysymysTeksti}");
                    //int counter = 0;
                    //foreach (string vaihtoehto in kysymys.Vaihtoehdot)
                    //{
                    //    Console.WriteLine($"{counter}vastausEtuliitteet[]}\t{vaihtoehto}");
                    //    counter++;
                    //}
                    for (int x = 0; x < kysymys.Vaihtoehdot.Count(); x++)
                    {
                        Console.WriteLine($"\t{vastausEtuliitteet[x]}: {kysymys.Vaihtoehdot[x]}");
                    }
                    string vastaus;
                    do
                    {
                        Console.Write("Anna vastaus: ");
                        vastaus = Console.ReadLine();
                    } while (!kysymys.ValidoiVastaus(vastaus));

                    if (kysymys.Tarkasta(vastaus))
                    {
                        Console.WriteLine("> Oikein!");
                        km.Pisteet++;
                    } else
                    {
                        Console.WriteLine("> Väärin!");
                    }

                    Console.WriteLine("-");
                }
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Kysely loppui, pisteesi: {km.Pisteet}/{kysMaara}");
                
                // Pelin koodi loppuu
            } 
            else
            {
                // KYsymysten haku epäonnistui, lopetetaan suorittaminen
                Console.WriteLine("Kysymysten haku epäonnistui!");
            }

            Console.ReadKey();



        }
    }
}
