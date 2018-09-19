using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using MiniprojektiKysely;
using System.Linq;

namespace Miniprojekti
{
    class Program
    {
        public int Pistelaskuri { get; set; }
        
        public Program() {
            this.Pistelaskuri = 0;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Mikä kysely aloitetaan? (1 / 2)");
            int kysNro = int.Parse(Console.ReadLine());
            switch (kysNro)
            {
                case 1:
                do
                {
                    Program ohjelma = new Program();
                    List<string[]> kokoLista = new List<string[]>();
                    try
                    {
                        using (var lukija = new StreamReader("../../kysymykset.txt"))
                        {
                            String rivi;
                            while ((rivi = lukija.ReadLine()) != null)
                            {
                                kokoLista.Add(rivi.Split(';'));
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Tiedostoa ei löytynyt");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Joku muu virhe sattui.");
                    }

                    Random randIndex = new Random();
                    List<Kysymys> Oliot = new List<Kysymys>();

                    Console.WriteLine("Tervetuloa! Aloita peli painamalla jotakin nappia.");
                    Console.ReadLine();
                    Console.Write("Montako kysymystä haluat? (1-10) ");

                    int kysymystenMaara = int.Parse(Console.ReadLine());
                    while (kysymystenMaara > 10 || kysymystenMaara < 1)
                    {
                        Console.WriteLine("Epäkelpo arvo. Anna uusi.");
                        kysymystenMaara = int.Parse(Console.ReadLine());
                    }

                    ArrayList kysyttyjenIndeksit = new ArrayList();
                    for (int i = 0; i < kysymystenMaara; i++)
                    {
                        int arvottuRiviNr = randIndex.Next(0, kokoLista.Count - 1);
                        // Estetään saman kysymyksen tuleminen uudestaan
                        if (kysyttyjenIndeksit.Contains(arvottuRiviNr))
                        {
                            arvottuRiviNr = randIndex.Next(0, kokoLista.Count - 1);
                        }
                        kysyttyjenIndeksit.Add(arvottuRiviNr);
                        //tehdään olio listan alkiosta jonka indeksi on arvottuRivi
                        Kysymys kysymysOlio = new Kysymys(arvottuRiviNr, kokoLista);
                        kysyttyjenIndeksit.Add(arvottuRiviNr);
                        Oliot.Add(kysymysOlio);
                    }
                    kysyttyjenIndeksit.Clear();

                    string viesti = "";

                    TulostaKysymyksetJaTarkista(Oliot, ohjelma);
                    if (ohjelma.Pistelaskuri <= (kysymystenMaara / 2))
                    {
                        viesti = "Ei mennyt ihan putkeen!";
                    }
                    else
                    {
                        viesti = "Tosi hyva!!!";
                    }
                    Console.WriteLine("Peli on nyt ohi. Vastasit oikein {0}/{1} kysymykseen. {2}", ohjelma.Pistelaskuri, kysymystenMaara, viesti);

                    kokoLista.Clear();
                    Console.WriteLine("Haluatko pelata uudestaan? k/e?");
                } while (Console.ReadLine() == "k");
                    break;

                case 2:
                    {
                        KyselyMoottori km = new KyselyMoottori();
                        if (km.HaeKysymykset())
                        {
                            // Kysymysten haku onnistui, aloitetaan peli
                            int kysMaara = 10;
                            char[] vastausEtuliitteet = { 'A', 'B', 'C', 'D' };
                            for (int i = 0; i < kysMaara; i++)
                            {
                                Kysymys2 kysymys2 = km.AnnaKysymys();
                                Console.WriteLine($"Kysymys {i + 1}: {kysymys2.KysymysTeksti}");
                                //int counter = 0;
                                //foreach (string vaihtoehto in kysymys.Vaihtoehdot)
                                //{
                                //    Console.WriteLine($"{counter}vastausEtuliitteet[]}\t{vaihtoehto}");
                                //    counter++;
                                //}
                                for (int x = 0; x < kysymys2.Vaihtoehdot.Count(); x++)
                                {
                                    Console.WriteLine($"\t{vastausEtuliitteet[x]}: {kysymys2.Vaihtoehdot[x]}");
                                }
                                string vastaus;
                                do
                                {
                                    Console.Write("Anna vastaus: ");
                                    vastaus = Console.ReadLine();
                                } while (!kysymys2.ValidoiVastaus(vastaus));

                                if (kysymys2.Tarkasta(vastaus))
                                {
                                    Console.WriteLine("> Oikein!");
                                    km.Pisteet++;
                                }
                                else
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
                        break;
                    }

                default:
                    Console.Write("Epäkelpo arvo");
                    Console.ReadLine();
                    break;
            }
        }

        static void TulostaKysymyksetJaTarkista(List<Kysymys> kysymysLista, Program ohjelma)
        {
            int kysymysNro = 1;
            foreach (Kysymys kysymys in kysymysLista)
            {
                Console.WriteLine("Kysymys {0}: ", kysymysNro);
                kysymys.TulostaKysymys();
                string kayttajanVastaus = Console.ReadLine();
                int n;
                var isNumeric = Int32.TryParse(kayttajanVastaus, out n);
                while (kayttajanVastaus == null || kayttajanVastaus == "" || !isNumeric) {
                    Console.WriteLine("Syötteessäsi on jokin pielessä. Yritä uudestaan.");
                    kayttajanVastaus = Console.ReadLine();
                    isNumeric = int.TryParse(kayttajanVastaus, out n);
                }
                if (kysymys.TarkistaVastaus(kayttajanVastaus))
                {
                    ohjelma.Pistelaskuri++;
                }
                kysymysNro++;
            }
        }

    }
}
