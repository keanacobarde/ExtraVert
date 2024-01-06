using System;
using System.Collections.Generic;
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
    }
}
