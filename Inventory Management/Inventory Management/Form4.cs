using Microsoft.Data.SqlClient;
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

namespace Inventory_Management {
    public partial class Form4 : Form {
        DataService ds = new DataService();

        public Form4() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {

            // Creates a new item based on the text box values
            Item item = new Item { Id = 0, Name = textBox2.Text, Category = textBox3.Text, Quantity = Int32.Parse(textBox4.Text), Price = decimal.Parse(textBox5.Text), Description = textBox6.Text };

            // Executes data service "Add Item" method
            bool success = ds.addItem(item);
            Debug.WriteLine("Success: " + success);

            // Create new Form 1 instance
            Form1 form1 = new Form1(true);

            // Close Form 4 and open Form 1
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e) {
            // Create new Form 1 instance
            Form1 form1 = new Form1(true);

            // Close Form 4 and open Form 1
            form1.Show();
            this.Hide();
        }
    }
}
