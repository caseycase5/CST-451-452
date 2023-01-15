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

namespace Inventory_Management {
    public partial class Form2 : Form {
        // Creates a local list of Item objects
        public List<Item> items;

        // Initializes the form and associates the passed item list with the local one.
        public Form2(List<Item> items) {
            InitializeComponent();
            this.items = items;
            Debug.WriteLine(items.Count);
        }

        // When the Admin Login button is clicked. This verification can be moved to a database query with user credentials stored separately. 
        // If this is done, a separate call in the DataServer class will need to be made. For now, this will be kept local.
        private void button1_Click(object sender, EventArgs e) {
            // Assigns inputted values to variables.
            string username = textBox1.Text;
            string password = textBox2.Text;
            Debug.WriteLine(username + " - " + password);

            // Check to see if valid credentials were supplied
            if(username == "admin" && password == "password") {
                Debug.WriteLine("Successful login. Item Count: ");
                Form1 form1 = new Form1(true);
                this.Hide();
                form1.ShowDialog();
            }
            // Shows a message box alerting the user that their login was unsuccessful
            else {
                Debug.WriteLine("Unsuccessful login.");
                MessageBox.Show("Incorrect Username or Password!!");
            }
        }
    }
}
