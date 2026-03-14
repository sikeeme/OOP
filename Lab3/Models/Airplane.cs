namespace Lab3.Models
{
    public class Airplane : Vehicle
    {
        public int Wingspan { get; set; }

        public Airplane() { }

        public Airplane(string name, int maxSpeed, double weight, int wingspan)
            : base(name, maxSpeed, weight)
        {
            Wingspan = wingspan;
        }

        public override string ToString()
        {
            return base.ToString() + $", Wingspan: {Wingspan} m";
        }
    }
}