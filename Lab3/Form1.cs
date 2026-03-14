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

        /// <summary>
        /// Main form constructor.
        /// Initializes components, factories, combo box and subscribes to necessary events.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Set up factories and UI controls
            InitializeFactories();
            InitializeComboBox();

            // Subscribe to PropertyGrid changes ? refresh ListBox when properties are modified
            propertyGrid1.PropertyValueChanged += (s, e) => RefreshListBox();

            RefreshListBox();
        }

        /// <summary>
        /// Initializes the factory dictionary that creates concrete vehicle instances by type name.
        /// To support a new vehicle type, add only one line here (plus ComboBox and GetSerializer).
        /// No switch statements or reflection are used.
        /// </summary>
        private void InitializeFactories()
        {
            objectFactories = new Dictionary<string, Func<Vehicle>>
            {
                { "Car",       () => new Car()       },
                { "Truck",     () => new Truck()     },
                { "Motorcycle",() => new Motorcycle()},
                { "Boat",      () => new Boat()      },
                { "Airplane",  () => new Airplane()  },
                { "Bicycle",   () => new Bicycle()   }
            };
        }

        /// <summary>
        /// Fills the combo box with all supported vehicle types.
        /// The order should match the keys in the objectFactories dictionary.
        /// </summary>
        private void InitializeComboBox()
        {
            comboBoxTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypes.Items.AddRange(new string[]
            {
                "Car", "Truck", "Motorcycle", "Boat", "Airplane", "Bicycle"
            });

            if (comboBoxTypes.Items.Count > 0)
                comboBoxTypes.SelectedIndex = 0;
        }

        /// <summary>
        /// Refreshes the ListBox content while trying to preserve the previously selected index.
        /// Called after add, delete, property changes, and data loading.
        /// </summary>
        private void RefreshListBox()
        {
            int selectedIndex = listBoxObjects.SelectedIndex;

            listBoxObjects.Items.Clear();
            foreach (var v in vehicles)
                listBoxObjects.Items.Add(v);

            // Restore selection if the index is still valid
            if (selectedIndex >= 0 && selectedIndex < vehicles.Count)
                listBoxObjects.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Event handler for the "Add" button.
        /// Creates a new vehicle of the selected type using the factory method and adds it to the list.
        /// </summary>
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

                // Select the newly added item
                listBoxObjects.SelectedIndex = vehicles.Count - 1;
            }
        }

        /// <summary>
        /// Event handler for the "Delete" button.
        /// Removes the currently selected vehicle from the list and clears the PropertyGrid.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedIndex >= 0)
            {
                vehicles.RemoveAt(listBoxObjects.SelectedIndex);
                RefreshListBox();

                // Clear property grid since the object no longer exists
                propertyGrid1.SelectedObject = null;
            }
        }

        /// <summary>
        /// Event handler for ListBox selection change.
        /// Displays the properties of the selected vehicle in the PropertyGrid for viewing/editing.
        /// </summary>
        private void listBoxObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxObjects.SelectedItem is Vehicle selected)
            {
                propertyGrid1.SelectedObject = selected;
            }
        }

        /// <summary>
        /// Creates and returns an XmlSerializer configured to handle the polymorphic Vehicle hierarchy.
        /// When adding a new vehicle class, only this method needs an additional typeof() entry.
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

        /// <summary>
        /// Event handler for the "Save" button.
        /// Serializes the entire list of vehicles to vehicles.xml file.
        /// </summary>
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
                MessageBox.Show($"Error saving: {ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Event handler for the "Load" button.
        /// Deserializes the list of vehicles from vehicles.xml and refreshes the UI.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Deserialization from XML file
            try
            {
                if (!File.Exists("vehicles.xml"))
                {
                    MessageBox.Show("File vehicles.xml not found", "Warning");
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
                MessageBox.Show($"Error loading: {ex.Message}", "Error");
            }
        }
    }
}