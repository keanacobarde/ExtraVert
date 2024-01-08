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
                currLongest.AskingPrice < next.AskingPrice ? next : currLongest,
                plant => plant.Species);
            Console.WriteLine($"The least expensive plant is {plantLowestPrice}");
        }

        // Number of plants available.

        // Name of plant with higest needs

        // Average Light Needs

        // Percentage of plants adopted
    }
}
