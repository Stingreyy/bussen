using System;

namespace Bussen
{
    // Skapa en klass för att lagra information om passagerare
    class Buss
    {
        public class Passenger
        {
            public int Age { get; set; }     // Ålder
            public string Gender { get; set; }  // Kön
        }

        public Passenger[] passagerare;   // En array för att lagra passagerarobjekt
        public int antal_passagerare;    // Antal passagerare

        // Konstruktor för Buss-klassen
        public Buss()
        {
            passagerare = new Passenger[25]; // Skapa en array med plats för 25 passagerarobjekt
            antal_passagerare = 0;          // Initialt finns det inga passagerare
        }

        // Huvudmetod för att köra bussimulatorn
        public void Run()
        {
            Console.WriteLine("Välkommen till den fantastiska Buss-simulatorn");

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Meny:");
                Console.WriteLine("1. Lägg till passagerare");
                Console.WriteLine("2. Skriv ut bussen");
                Console.WriteLine("3. Beräkna total ålder");
                Console.WriteLine("4. Avsluta");
                Console.Write("Ange ditt val: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        LäggTillPassagerare();  // Anropa metoden för att lägga till en passagerare
                        break;
                    case "2":
                        SkrivUtBuss();  // Anropa metoden för att skriva ut bussinformation
                        break;
                    case "3":
                        BeräknaTotalÅlder();  // Anropa metoden för att beräkna total ålder
                        break;
                    case "4":
                        running = false;  // Avsluta programmet
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        // Metod för att lägga till en passagerare i bussen
        public void LäggTillPassagerare()
        {
            Console.Write("Ange passagerarens ålder: ");
            string ageInput = Console.ReadLine();
            int ålder;

            if (int.TryParse(ageInput, out ålder))
            {
                string kön;

                do
                {
                    Console.Write("Ange passagerarens kön (man/kvinna): ");
                    kön = Console.ReadLine().ToLower(); // Konvertera inmatningen till gemener för att göra jämförelsen icke-skiftlägeskänslig
                } while (kön != "man" && kön != "kvinna");

                passagerare[antal_passagerare] = new Passenger { Age = ålder, Gender = kön };
                antal_passagerare++;
                Console.WriteLine("Passagerare tillagd med framgång.");
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning. Åldern måste vara ett giltigt heltal.");
            }
        }

        // Metod för att skriva ut bussinformation, inklusive information om passagerare
        public void SkrivUtBuss()
        {
            Console.WriteLine("Passagerare på bussen:");

            for (int i = 0; i < antal_passagerare; i++)
            {
                Console.WriteLine("Passagerare {0}: Kön {1}, Ålder {2}", i + 1, passagerare[i].Gender, passagerare[i].Age);
            }
        }

        // Metod för att beräkna total ålder, total ålder för män och total ålder för kvinnor
        public void BeräknaTotalÅlder()
        {
            int totalÅlder = 0;
            int totalÅlderMan = 0;
            int totalÅlderKvinna = 0;
            int antalMan = 0;
            int antalKvinna = 0;

            for (int i = 0; i < antal_passagerare; i++)
            {
                totalÅlder += passagerare[i].Age;
                if (passagerare[i].Gender == "man")
                {
                    totalÅlderMan += passagerare[i].Age;
                    antalMan++;
                }
                else if (passagerare[i].Gender == "kvinna")
                {
                    totalÅlderKvinna += passagerare[i].Age;
                    antalKvinna++;
                }
            }

            Console.WriteLine("Total ålder av alla passagerare: " + totalÅlder);
            Console.WriteLine("Total ålder av män: " + totalÅlderMan + " (Antal män: " + antalMan + ")");
            Console.WriteLine("Total ålder av kvinnor: " + totalÅlderKvinna + " (Antal kvinnor: " + antalKvinna + ")");
        }
    }

    class Program
    {
        // Huvudmetod, programmet börjar här
        public static void Main(string[] args)
        {
            var minbuss = new Buss(); // Skapa en instans av Buss-klassen
            minbuss.Run(); // Kör bussimulatorn

            Console.Write("Tryck på valfri tangent för att fortsätta . . . ");
            Console.ReadKey(true);
        }
    }
}