namespace Lab3.Models
{
    /// <summary>
    /// Derived class representing a boat.
    /// </summary>
    public class Boat : Vehicle
    {
        public string Propulsion { get; set; } = "Motor";

        public Boat() { }

        public Boat(string name, int maxSpeed, double weight, string propulsion)
            : base(name, maxSpeed, weight)
        {
            Propulsion = propulsion;
        }

        public override string ToString()
        {
            return base.ToString() + $", Propulsion: {Propulsion}";
        }
    }
}