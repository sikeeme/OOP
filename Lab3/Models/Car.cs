namespace Lab3.Models
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public string FuelType { get; set; } = "Petrol";

        public Car() { }

        public Car(string name, int maxSpeed, double weight, int doors, string fuel)
            : base(name, maxSpeed, weight)
        {
            NumberOfDoors = doors;
            FuelType = fuel;
        }

        public override string ToString()
        {
            return base.ToString() + $", Doors: {NumberOfDoors}, Fuel: {FuelType}";
        }
    }
}