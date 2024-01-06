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

            // Taking user input and appending it to new instance of proj
            Plant PlantToAdd = new Plant();
            PlantToAdd.Species = plantSpecies;
            PlantToAdd.LightNeeds = plantLightNeeds;
            PlantToAdd.AskingPrice = plantAskingPrice;
            PlantToAdd.City = plantCityName;
            PlantToAdd.Zip = plantZipCode;
            PlantToAdd.Sold = false;

            // Adding user created plant
            Globals.Plants.Add(PlantToAdd);
        }

        // READ
        public static void ViewPlants()
        {
            for (int i = 0; i < Globals.Plants.Count; i++)
            {
                string soldStatusString = Globals.Plants[i].Sold ? "was sold" : "is available";
                Console.WriteLine($"{i + 1}. {Globals.Plants[i].Species} in {Globals.Plants[i].City} {soldStatusString} for {Globals.Plants[i].AskingPrice} dollars");
            }

        }

        //ADOPT
        public static void AdoptPlant()
        {
            int choice;

            Console.WriteLine("Choose the plant you wish to adopt");
            List<Plant> plantsAvailable = Globals.Plants.Where(plant => !plant.Sold).ToList();
            for (int i = 0; i < plantsAvailable.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {plantsAvailable[i].Species}");
            }
            choice = Int32.Parse(Console.ReadLine());
            object chosenPlant = plantsAvailable[choice - 1];

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
