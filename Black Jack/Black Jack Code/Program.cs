using System;

namespace Praktikumsaufgabe_Black_Jack
{
    class Program
    {
        static int KarteZiehen()
        {
            Random zufall = new Random();
            int eineKarte = zufall.Next(2, 12);
            return eineKarte;
        }                                                                                           //Funktion für eine zufällige Karte Ziehen

        static void ComputerGewinnt(int chipsguthaben)
        {

            Console.WriteLine("Ich habe gewonnen.");
            Console.WriteLine();
            Console.WriteLine($"Dein Guthaben: {chipsguthaben} Chips");
        }                                                                                           //Funktion  wenn der Computer gewinnt

        static int ComputerVerliert(int chipsguthaben, int chipseinsatz)
        {

            Console.WriteLine("Du hast gewonnen.!");
            Console.WriteLine();
            chipsguthaben = chipsguthaben + chipseinsatz * 2;
            Console.WriteLine($"Dein Guthaben: {chipsguthaben} Chips");
            return chipsguthaben;
        }                                                                                           //Funktion wenn der Computer verliert


        static void Main(string[] args)
        {

            int chipseinsatz, chipsguthaben, spielergesamt, computergesamt, Karte;
            chipsguthaben = 10;
            bool Laufend = true;                                                                    // Variable für Spiel Läuft weiter

            while (Laufend)                                                                             

            {
                spielergesamt = 0;
                computergesamt = 0;

                Console.WriteLine("Willkommen bei Black Jack!");
                Console.WriteLine($"Dein Guthaben beträgt {chipsguthaben} Chips");
                Console.WriteLine("Wie viele Chips willst du einsetzen?:");
                chipseinsatz = Convert.ToInt32(Console.ReadLine());

                while (chipseinsatz > chipsguthaben)                                                        //Fehler falls Spieler mehr wetten will als er überhaupt besitzt
                {
                    Console.WriteLine($"Dein Einsatz: {chipseinsatz}");
                    Console.WriteLine($"Du musst mindestens 1 und kannst max. {chipsguthaben} Chips setzen.");
                    chipseinsatz = Convert.ToInt32(Console.ReadLine());
                }

                chipsguthaben = chipsguthaben - chipseinsatz;

                for (int i = 0; i < 2; i += 1)                                                          //Spieler zieht 2 Karten und werden aufsummiert.
                {
                    Karte = KarteZiehen();
                    spielergesamt += Karte;
                    Console.WriteLine($"Karte: {Karte,2} Gesamt: {spielergesamt,2}");

                }

                if (spielergesamt <21 )
                Console.WriteLine("Noch eine Karte (j/n)?");                                           //Abfrage für noch eine Karte
                string Eingabe = Console.ReadLine();

                while (spielergesamt < 21 && (Eingabe == "J" || Eingabe == "j"))                        //Bricht ab wenn 21 überschritten oder n/N getippt wird
                {
                    Karte = KarteZiehen();
                    spielergesamt += Karte;
                    Console.WriteLine($"Karte: {Karte,2} Gesamt: {spielergesamt,2}");

                    if (spielergesamt < 21)
                    {
                        Console.WriteLine("Noch eine Karte (j/n)?");
                        Eingabe = Console.ReadLine();
                    }

                }

                if (spielergesamt <= 21)                                                            
                {
                    Console.WriteLine("Ich bin dran.");                                             //Computer fängt an zu ziehen bis mehr als 16, wenn spieler kleiner oder gleich 21 hat

                    while (computergesamt < 17)
                    {
                        Karte = KarteZiehen();
                        computergesamt += Karte;
                        Console.WriteLine($"Karte: {Karte} Gesamt: {computergesamt,2}");
                    }

                    if (computergesamt > 21)                                                        //Computer verliert wenn er mehr als 21 hat
                    {
                        chipsguthaben = ComputerVerliert(chipsguthaben, chipseinsatz);      

                    }
                    else if (spielergesamt <= computergesamt)
                    {
                        ComputerGewinnt(chipsguthaben);                                             //Computer gewinnt wenn er gleich oder mehr hat also der Spieler
                    }
                    else
                    {
                        chipsguthaben = ComputerVerliert(chipsguthaben, chipseinsatz);               //Computer verliert bei weniger als der Speielr
                    }

                }
                else
                {
                    ComputerGewinnt(chipsguthaben);                                                 //Computer gewinnt wenn Spieler mehr als 21 hat
                }


                Console.WriteLine($"Dein Guthaben beträgt: {chipsguthaben}");

                if (chipsguthaben == 0)
                {
                    Console.WriteLine("Tut mit leid du hast keine Chips mehr.");                    //Spiel wird beendet wenn Spieler keine Chips mehr hat
                    Laufend = false;
                }
                else
                {

                    Console.WriteLine("Willst du noch weiter spielen(j/n)?");                       //Abfrage für eine weitere Runde
                    string Eingabe2 = Console.ReadLine();

                    if (Eingabe2 == "N" || Eingabe2 == "n")
                    {
                        Laufend = false;
                        Console.WriteLine("Ok, auf Wiedersehen.");                                  
                    }
                }

            }













        }
    }
}
