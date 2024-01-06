using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraVert
{
    internal class Globals
    {
        public static List<Plant> Plants = new List<Plant>()
        {
            new Plant()
            {
                Species = "Venus Fly Trap",
                LightNeeds = 4,
                AskingPrice = 25.45M,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
            },
            new Plant()
            {
                Species = "Sunflower",
                LightNeeds = 5,
                AskingPrice = 40,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
            },
            new Plant()
            {
                Species = "Tulips",
                LightNeeds = 3,
                AskingPrice = 30,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
            },
        };

        public static void Greeting() 
        {
            Console.WriteLine("Welcome to ExtraVert!");
        }

        public static void Menu()
        {
            string choice = null;
            while (choice != "0")
            {
                Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View All Plants
                      2. Add a Plant 
                      3. Adopt a Plant
                      4. Delist a Plant");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        break;
                    case "1":
                        PlantFunctions.ViewPlants();
                        break;
                    case "2":
                        PlantFunctions.AddPlant();
                        break;
                    case "3":
                        PlantFunctions.AdoptPlant();
                        break;
                    case "4":
                        Console.WriteLine("Delist a Plant");
                        break;
                    default: Console.WriteLine("Please choose a valid option");
                        break;
                }
            }

        }
    }
}
