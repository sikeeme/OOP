using System;

namespace Lab3.Models
{
    /// <summary>
    /// Base abstract class for the entire vehicle hierarchy.
    /// All derived classes inherit common properties and ToString for UI display.
    /// </summary>
    public abstract class Vehicle
    {
        public string Name { get; set; } = "Unknown";
        public int MaxSpeed { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// Default constructor required for XML deserialization.
        /// </summary>
        public Vehicle() { }

        /// <summary>
        /// Parameterized constructor for easy creation.
        /// </summary>
        protected Vehicle(string name, int maxSpeed, double weight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            Weight = weight;
        }

        /// <summary>
        /// Overridden ToString() used by ListBox and PropertyGrid.
        /// </summary>
        public override string ToString()
        {
            return $"{Name} (Speed: {MaxSpeed} km/h, Weight: {Weight} kg)";
        }
    }
}