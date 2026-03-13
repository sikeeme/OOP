namespace Lab3.Models
{
    /// <summary>
    /// Derived class representing a truck.
    /// </summary>
    public class Truck : Vehicle
    {
        public double MaxLoad { get; set; }

        public Truck() { }

        public Truck(string name, int maxSpeed, double weight, double maxLoad)
            : base(name, maxSpeed, weight)
        {
            MaxLoad = maxLoad;
        }

        public override string ToString()
        {
            return base.ToString() + $", MaxLoad: {MaxLoad} t";
        }
    }
}