namespace ExtraVert
{
    class Program
    {
        static void Main(string[] args)
        {
            Globals.Greeting();
            Console.WriteLine($"The plant of the day is {PlantFunctions.ChooseRandPlant()}");
            Globals.Menu();
        
        }
    
    }

}