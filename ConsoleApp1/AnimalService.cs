using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
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

        public List<Animal> GetAnimals_CSVHelper()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => Regex.Replace(args.Header, @"\s", string.Empty)
            };
            using (var reader = new StreamReader(CsvLocation))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Animal>();
               // records.Take(100).ToList();
                return records.ToList();
            }
        }
    }
}
