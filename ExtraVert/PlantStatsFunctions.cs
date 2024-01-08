using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraVert
{
    class PlantStatsFunctions
    {
        // Plant with lowest price.
        public static void LowestPrice()
        {
            string plantLowestPrice =
                Globals.plantsAvailable.Aggregate(Globals.plantsAvailable[0], (currLongest, next) =>
                currLongest.AskingPrice > next.AskingPrice ? next : currLongest,
                plant => plant.Species);
            Console.WriteLine($"The least expensive plant is {plantLowestPrice}");
        }

        // Number of plants available.
        public static void NumberOfAvailablePlants() 
        {
            Console.WriteLine($"There are {Globals.plantsAvailable.Count} plants available.");
        }

        // Name of plant with higest needs
        public static void HighestNeeds()
        {
            string plantHighestneeds = Globals.plantsAvailable.Aggregate(Globals.plantsAvailable[0], (currHighest, next) => 
                currHighest.LightNeeds < next.LightNeeds ? next : currHighest,
                plant => plant.Species);
            Console.WriteLine($"The plant with the highest light needs is {plantHighestneeds}");
        }

        // Average Light Needs
        public static void AverageLightNeeds()
        {
            int sumLightNeeds = Globals.plantsAvailable.Aggregate(0, (acc, curr) =>
                acc + curr.LightNeeds,
                sum => sum
            );
            Console.WriteLine($"The average light needs is {sumLightNeeds/Globals.plantsAvailable.Count}");

        }

        // Percentage of plants adopted
        public static void percentagePlantsAdopted()
        {
            List<Plant> adoptedPlants = Globals.Plants.Where(plant => plant.Sold == true).ToList();
            decimal percentPlantAdopted = (adoptedPlants.Count/Globals.Plants.Count) * 100;
            Console.WriteLine($"Percentage of Plants Adopted: {percentPlantAdopted}%");
        
        }
    }
}
