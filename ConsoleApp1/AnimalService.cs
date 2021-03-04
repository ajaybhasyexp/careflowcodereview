using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Models;

namespace ConsoleApp1
{
    public class AnimalService
    {
        private const string CsvLocation = "./TestData/animals.csv";

        public List<Animal> GetAnimals()
        {
            var contents = File.ReadAllLines(CsvLocation);
            var animals = new List<Animal>();

            foreach (var line in contents.Skip(1))
            {
                var csvLine = line.Split(',');

                var animal = new Animal
                {
                    Name = csvLine[0],
                    Colour = csvLine[1],
                    Type = Enum.Parse<AnimalType>(csvLine[2])
                };

                animals.Add(animal);
            }

            return animals;
        }
    }
}
