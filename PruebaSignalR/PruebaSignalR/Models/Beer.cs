namespace PruebaSignalR.Models
{
    public class Beer
    {
        public Beer(string name, string brand)
        {
            Name = name;
            Brand = brand;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
    }
}
