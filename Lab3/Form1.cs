using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Lab3.Models;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private Dictionary<string, Func<Vehicle>> objectFactories;

        public Form1()
        {
            InitializeComponent();

            // Initialize factories and UI controls
            InitializeFactories();
            InitializeComboBox();

            // Subscribe to PropertyGrid changes to refresh ListBox display
            propertyGrid1.PropertyValueChanged += (s, e) => RefreshListBox();

            RefreshListBox();
        }

        /// <summary>
        /// Creates factories for each concrete type.
        /// Adding a new class requires only adding one line here + ComboBox + GetSerializer().
        /// No switch, no reflection.
        /// </summary>
        private void InitializeFactories()
        {
            objectFactories = new Dictionary<string, Func<Vehicle>>
            {
                { "Car", () => new Car() },
                { "Truck", () => new Truck() },
                { "Motorcycle", () => new Motorcycle() },
                { "Boat", () => new Boat() },
                { "Airplane", () => new Airplane() },
                { "Bicycle", () => new Bicycle() }
            };
        }

        /// <summary>
        /// Populates ComboBox with available types.
        /// </summary>
        private void InitializeComboBox()
        {
            comboBoxTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypes.Items.AddRange(new string[] { "Car", "Truck", "Motorcycle", "Boat", "Airplane", "Bicycle" });
            if (comboBoxTypes.Items.Count > 0) comboBoxTypes.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes ListBox while preserving selection.
        /// </summary>
        private void RefreshListBox()
        {
            int selectedIndex = listBoxObjects.SelectedIndex;
            listBoxObjects.Items.Clear();
            foreach (var v in vehicles)
                listBoxObjects.Items.Add(v);

            if (selectedIndex >= 0 && selectedIndex < vehicles.Count)
                listBoxObjects.SelectedIndex = selectedIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add new object using factory (no switch, no reflection)
            string typeName = comboBoxTypes.SelectedItem?.ToString();
            if (typeName != null && objectFactories.TryGetValue(typeName, out var createFunc))
            {
                Vehicle newVehicle = createFunc();
                newVehicle.Name = $"New {typeName}";
                vehicles.Add(newVehicle);
                RefreshListBox();
                listBoxObjects.SelectedIndex = vehicles.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedIndex >= 0)
            {
                vehicles.RemoveAt(listBoxObjects.SelectedIndex);
                RefreshListBox();
                propertyGrid1.SelectedObject = null;
            }
        }

        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem is Vehicle selected)
            {
                propertyGrid1.SelectedObject = selected;
            }
        }

        /// <summary>
        /// Returns XmlSerializer configured for polymorphic hierarchy.
        /// Only this method needs updating when adding a new class.
        /// </summary>
        private XmlSerializer GetSerializer()
        {
            Type[] extraTypes = new Type[]
            {
                typeof(Car),
                typeof(Truck),
                typeof(Motorcycle),
                typeof(Boat),
                typeof(Airplane),
                typeof(Bicycle)
            };
            return new XmlSerializer(typeof(List<Vehicle>), extraTypes);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Serialization to XML file
            try
            {
                using (FileStream fs = new FileStream("vehicles.xml", FileMode.Create))
                {
                    GetSerializer().Serialize(fs, vehicles);
                }
                MessageBox.Show("Saved successfully to vehicles.xml", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving: {ex.Message}");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Deserialization from XML file
            try
            {
                if (!File.Exists("vehicles.xml"))
                {
                    MessageBox.Show("File vehicles.xml not found");
                    return;
                }

                using (FileStream fs = new FileStream("vehicles.xml", FileMode.Open))
                {
                    vehicles = (List<Vehicle>)GetSerializer().Deserialize(fs);
                }
                RefreshListBox();
                MessageBox.Show("Loaded successfully", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}