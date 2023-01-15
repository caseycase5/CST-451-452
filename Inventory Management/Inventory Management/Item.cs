using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    public class Item
    {
        // Item properties. These should be the same as what is stored in the database.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public bool findByID(int id) {
            if (id == Id) {

                return true;
            }
            return false;
        }
    }

    
}
