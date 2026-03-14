namespace Lab3.Models
{
    public class Motorcycle : Vehicle
    {
        public bool HasSidecar { get; set; }

        public Motorcycle() { }

        public Motorcycle(string name, int maxSpeed, double weight, bool hasSidecar)
            : base(name, maxSpeed, weight)
        {
            HasSidecar = hasSidecar;
        }

        public override string ToString()
        {
            return base.ToString() + $", HasSidecar: {HasSidecar}";
        }
    }
}