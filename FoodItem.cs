using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mission3_Assignment
{
    public class FoodItem
    {
        // Sets up the properties of the FoodItem class.
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Constructor to initialize the properties
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            // Assigns the input values to the properties.
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }
    }
}
