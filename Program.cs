using System;

namespace Bussen
{
    class Buss
    {
        public int[] passagerare;
        public int antal_passagerare;

        public Buss()
        {
            passagerare = new int[25]; // Skapar en vektor med plats för 25 passagerare
            antal_passagerare = 0; // Ingen passagerare vid start
        }

        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator");

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add passenger");
                Console.WriteLine("2. Print bus");
                Console.WriteLine("3. Calculate total age");
                Console.WriteLine("4. Quit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        add_passenger();
                        break;
                    case "2":
                        print_buss();
                        break;
                    case "3":
                        int totalAge = calc_total_age();
                        Console.WriteLine("Total age of passengers: " + totalAge);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Lägger till en passagerare till bussen
  public void add_passenger()
        {
            Console.Write("Enter passenger's age: ");
            string input = Console.ReadLine();
            int age;

            if (int.TryParse(input, out age))
            {
                // Åldern konverterades till ett heltal
                // Lägg till passageraren i bussen
                // ...
                Console.WriteLine("Passenger added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input. Age must be a valid integer.");
            }
        }

        // Skriver ut alla passagerare på bussen
        public void print_buss()
        {
            Console.WriteLine("Passengers on the bus:");

            for (int i = 0; i < antal_passagerare; i++)
            {
                Console.WriteLine("Passenger {0}: Age {1}", i + 1, passagerare[i]);
            }
        }

        // Beräknar den totala åldern av alla passagerare på bussen
        public int calc_total_age()
        {
            int totalAge = 0;

            for (int i = 0; i < antal_passagerare; i++)
            {
                totalAge += passagerare[i];
            }

            return totalAge;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            var minbuss = new Buss();
            minbuss.Run();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}
