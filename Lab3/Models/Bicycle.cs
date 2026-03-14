namespace Lab3.Models
{
    public class Bicycle : Vehicle
    {
        public int NumberOfGears { get; set; }

        public Bicycle() { }

        public Bicycle(string name, int maxSpeed, double weight, int gears)
            : base(name, maxSpeed, weight)
        {
            NumberOfGears = gears;
        }

        public override string ToString()
        {
            return base.ToString() + $", Gears: {NumberOfGears}";
        }
    }
}