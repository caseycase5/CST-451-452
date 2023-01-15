using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace Inventory_Management {
    public partial class Form3 : Form {
        public List<Item> items;
        public string itemId;
        DataService ds = new DataService();

        public Form3(string itemId) {
            InitializeComponent();
            // Instancing the passed item list
            this.itemId = itemId;

            // Debug lines showing which item ID and name were chosen
            Debug.WriteLine(itemId);

            // Calling the data service to retrieve the item from the database
            Item item = ds.getOneItem(Int32.Parse(itemId));

            // Inputs current data into text box lines
            textBox1.Text = item.Id.ToString();
            textBox2.Text = item.Name;
            textBox3.Text = item.Category;
            textBox4.Text = item.Quantity.ToString();
            textBox5.Text = item.Price.ToString();
            textBox6.Text = item.Description;
        }

        // Editing an existing item
        private void button1_Click(object sender, EventArgs e) {
            // Creating the database connection
            SqlConnection cnn = ds.newConnection();

            // Creates a new item based on the text box values
            Item item = new Item { Id = Int32.Parse(textBox1.Text), Name = textBox2.Text, Category = textBox3.Text, Quantity = Int32.Parse(textBox4.Text), Price = decimal.Parse(textBox5.Text), Description = textBox6.Text };

            // Calls the "UpdateItem" data service method
            bool valid = ds.updateItem(item);
            if(valid) {
                Debug.WriteLine("Update successful.");
            }
            else {
                Debug.WriteLine("Update not successful.");
            }

            // Create new Form 1 instance
            Form1 form1 = new Form1(true);

            // Close Form 3 and open Form 1
            form1.Show();
            this.Hide();

        }

        // Deleting an item
        private void button2_Click(object sender, EventArgs e) {
            // Calling data service
            bool success = ds.removeItem(Int32.Parse(textBox1.Text));
            Debug.WriteLine("Deletion Success: " + success);

            // Create new Form 1 instance
            Form1 form1 = new Form1(true);

            // Close Form 3 and open Form 1
            form1.Show();
            this.Hide();
        }
    }
}
