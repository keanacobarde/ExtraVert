using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExtraVert
{
    internal class PlantFunctions
    {
        // PLANT OF THE DAY
        public static string ChooseRandPlant()
        { 
            Random random = new Random();
            int randIndx = random.Next(0, Globals.plantsAvailable.Count);
            return (Globals.plantsAvailable[randIndx].Species);
        }

        // SEARCH BY LIGHT NEEDS
        public static void SearchByLightNeeds()
        {
            int choice;
            Console.WriteLine("What light need can you support? Please input a number 1-5.");
            choice = Int16.Parse(Console.ReadLine());
            List<Plant> searchedPlant = Globals.plantsAvailable.Where(plant => plant.LightNeeds == choice).ToList();
            foreach (Plant plant in searchedPlant)
            {
                Console.WriteLine(plant.Species);
            }
        }

        // VIEW PLANT STATS
        public static void ViewPlantStats()
        {
            string choice = null;
            while (choice != "0")
            {
                Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View plant with lowest price.
                      2. View number of plants available 
                      3. View plant with highest light needs.
                      4. View average light needs
                      5. View percentage of plants adopted");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Goodbye");
                        break;
                    case "1":
                        PlantStatsFunctions.LowestPrice();
                        break;
                    case "2":
                        PlantStatsFunctions.NumberOfAvailablePlants();
                        break;
                    case "3":
                        Console.WriteLine("Name plant with highest light needs");
                        break;
                    case "4":
                        Console.WriteLine("Average light needs");
                        break;
                    case "5":
                        Console.WriteLine("Percentage of plants adopted");
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;
                }

            }
        }


        /// <summary>
        /// ALL CRUD FUNCTIONAITY FOUND BELOW
        /// </summary>

        // CREATE
        public static void AddPlant()
        {
            // OBTAINING USER INPUT
            Console.WriteLine("Please supply the plant species");
            string plantSpecies = Console.ReadLine();
            Console.WriteLine("Please supply the light needs of the plant on a scale from 1-5");
            int plantLightNeeds = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please supply the asking price of the plant");
            decimal plantAskingPrice = Decimal.Parse(Console.ReadLine());
            Console.WriteLine("Please supply the city name of the plant");
            string plantCityName = Console.ReadLine();
            Console.WriteLine("Please supply the zip code");
            int plantZipCode = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please supply the date this plant is available until.");
            Console.WriteLine("Year: ex. 2024");
            int plantYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Month: ex. 01 - January.");
            int plantMonth = int.Parse(Console.ReadLine());
            Console.WriteLine("Day: ex. 1-31");
            int plantDay = int.Parse(Console.ReadLine());

            // Taking user input and appending it to new instance of proj
            Plant PlantToAdd = new Plant();
            PlantToAdd.Species = plantSpecies;
            PlantToAdd.LightNeeds = plantLightNeeds;
            PlantToAdd.AskingPrice = plantAskingPrice;
            PlantToAdd.City = plantCityName;
            PlantToAdd.Zip = plantZipCode;
            PlantToAdd.Sold = false;
            PlantToAdd.AvailableUntil = new DateTime(plantYear, plantMonth, plantDay);

            // Adding user created plant
            Globals.Plants.Add(PlantToAdd);
        }

        // READ
        public static void ViewPlants()
        {
            for (int i = 0; i < Globals.Plants.Count; i++)
            {
                string soldStatusString = Globals.Plants[i].Sold ? "was sold" : "is available";
                Console.WriteLine($"{i + 1}. {Globals.Plants[i].Species} in {Globals.Plants[i].City} {soldStatusString} for {Globals.Plants[i].AskingPrice} dollars. It is available until {Globals.Plants[i].AvailableUntil.ToString()}");
            }

        }

        //ADOPT
        public static void AdoptPlant()
        {
            int choice;

            Console.WriteLine("Choose the plant you wish to adopt");
            for (int i = 0; i < Globals.plantsAvailable.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Globals.plantsAvailable[i].Species}");
            }
            choice = Int32.Parse(Console.ReadLine());
            object chosenPlant = Globals.plantsAvailable[choice - 1];

            foreach (PropertyDescriptor desc in TypeDescriptor.GetProperties(chosenPlant))
            {
                  if (desc.Name == "Sold") {
                    desc.SetValue(chosenPlant, true);
                  }
            }


        }

        // DELETE
        public static void DelistAPlant()
        {
            string choice = null;

            while (choice != "0")
            {
                try
                {
                    // loop through products but create a ReadLine
                    Console.WriteLine("0. Goodbye");
                    for (int i = 0; i < Globals.Plants.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Globals.Plants[i].Species}");

                    }
                    choice = Console.ReadLine();
                    Globals.Plants.RemoveAt(Int32.Parse(choice) - 1);
                }
                catch
                {
                    break;
                }

            }

        }
    }
}
