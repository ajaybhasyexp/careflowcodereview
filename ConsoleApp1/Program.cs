using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalService = new AnimalService();
            var animals = animalService.GetAnimals();

            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} {animal.Colour} {animal.Type}");
            }
        }
    }
}
