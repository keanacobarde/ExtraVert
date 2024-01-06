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
        // READ
        public static void ViewPlants()
        {
            for (int i = 0; i < Globals.Plants.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Globals.Plants[i].Species}");
            }

        }
    }
}
