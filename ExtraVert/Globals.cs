﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraVert
{
    internal class Globals
    {
        // Represents entire list of plants
        public static List<Plant> Plants = new List<Plant>()
        {
            new Plant()
            {
                Species = "Venus Fly Trap",
                LightNeeds = 4,
                AskingPrice = 25,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
                AvailableUntil = new DateTime(2024, 1, 10),
            },
            new Plant()
            {
                Species = "Sunflower",
                LightNeeds = 5,
                AskingPrice = 40,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
                AvailableUntil = new DateTime(2024, 1, 10),
            },
            new Plant()
            {
                Species = "Tulips",
                LightNeeds = 3,
                AskingPrice = 30,
                City = "Townsville",
                Zip = 12345,
                Sold = false,
                AvailableUntil = new DateTime(2024, 1, 10),
            },
        };

        //Lists only the available plants that aren't sold and whose dates aren't past their Available Until.
        public static List<Plant> plantsAvailable = Plants.Where(plant => !plant.Sold && DateTime.Compare(plant.AvailableUntil, DateTime.Now.ToLocalTime()) > 0).ToList();

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
                      4. Delist a Plant
                      5. Search plants based on light needs
                      6. View Plant Statistics");
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
                        PlantFunctions.DelistAPlant();
                        break;
                    case "5":
                        PlantFunctions.SearchByLightNeeds();
                        break;
                    case "6":
                        PlantFunctions.ViewPlantStats();
                        break;
                    default: Console.WriteLine("Please choose a valid option");
                        break;
                }
            }

        }
    }
}
