using System;

namespace PraktikumsaufgabeFelder
{
    class Program
    {

        static int[] PascalDreieck(int[] f)                                                   //Rechnung
        {

            if (f == null)
                return new int[] { 1 };
            int[] a = new int [f.Length+1];                                 //Array a erstellen nach Länge von f

            a[0] = 1;                                                       //erste Stelle 1
            a[f.Length] = 1;                                                //letzte Stelle 1
            
            for (int i = 1; i < f.Length; i++)                              
            {
                a[i] = f[i-1] + f[i];                                       //Zusammenrechnung der obigen Zahlen im Dreieck
            }

            return a;
        }

        static void Ausgabe(int[] f)                                                          //Ausgabe
        {
            for (int i = 0; i < f.Length; i++)
            {
                Console.Write(f[i] + " ");
            }
            Console.WriteLine();
        }

        static int Primzahlen(int n, bool ausgabe = false)                                    //Primzahlen nach Sieb des Eratosthenes, n muss größer als 0 sein
        {
            int anzahlprimzahl = 0;
            bool[] p = new bool[n];                                                           //festlegung eines Arrays p mit bool

            p[0] = true;                                                                      //1 ist keine Primzahl

            for(int i = 0; i < n; i++)
            {
                if (p[i] == false)                                                            //Alle Primzahlen komm mit false an                        
                {
                    anzahlprimzahl++;
                    int vielfache = i+1;

                    if (ausgabe == true)
                    Console.Write(vielfache+" ");

                    while ( vielfache+i+1 <= n)                                               //Markiere alle vielfachen der Primzahl
                    {
                        vielfache += i+1;
                        p[vielfache-1] = true;

                    }
                }
                   
            }
            Console.WriteLine();
            return anzahlprimzahl;

        }

        static void Main(string[] args)                                                       //Vorgegebene Mainfunktion
        {
            Console.WriteLine("Pascalsches Dreieck:");
            int[] f = null;
            for (int i = 0; i < 8; i++)
            {
                f = PascalDreieck(f);
                Ausgabe(f);
            }
            Console.WriteLine();
            Console.WriteLine("Primzahlen bis 20");
            Primzahlen(20, true);
            const int Primzahlgrenze = 750000;
            Console.WriteLine($"Anzahl der Primzahlen bis {Primzahlgrenze}: {Primzahlen(Primzahlgrenze)}");
        }
    }
}

