namespace Models
{
    public class Animal
    {
        public string Name { get; set; }
        public string Colour { get; set; }
        public AnimalType Type { get; set; }
    }

    public enum AnimalType
    {
        Dog,
        Cat,
        Snake,
        Elephant
    }
}
