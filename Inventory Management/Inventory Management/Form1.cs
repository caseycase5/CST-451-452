using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Inventory_Management {
    public partial class Form1 : Form {
        List<Item> items;
        DataService ds = new DataService();

        

        // This constructor executes each time the form is created. It will determine admin eligibility and repopulate the list of items.
        public Form1(bool adminStatus) {

            InitializeComponent();
            Debug.WriteLine("Started.");

            // Updating Admin status. If user is admin, all admin functions become visable 
            listView1.View = View.Details;
            label3.Text = "Admin Login Valid: " + adminStatus.ToString();
            if (adminStatus == true) {
                button2.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                button4.Visible = true;
                button3.Visible = true;
            }

            // Add columns to the ListView
            listView1.Columns.Add("ID", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Category", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 250, HorizontalAlignment.Left);

            // Populates the list of items with the items currently in the database. Prints the count to the debug console.
            items = ds.getAllItems();
            Debug.WriteLine("Item Count: " + items.Count);


            for (int i = 0; i < items.Count; i++) {
                // Add a new item to the list view
                listView1.Items.Add(items[i].Id.ToString()).SubItems.AddRange(new string[] { items[i].Name, items[i].Category, items[i].Quantity.ToString(), items[i].Price.ToString(), items[i].Description });
            }
        }

        // Edit-Delete button
        private void button2_Click(object sender, EventArgs e) {
            string name = textBox1.Text;
            Debug.WriteLine(name);

            // Get the item associated with the button
            ListViewItem item = listView1.FindItemWithText(name);

            // Returns the edit item form if the item is found
            if (item != null) {
                Debug.WriteLine("Item id " + item.Text + " found.");
                Form3 form3 = new Form3(item.Text);
                this.Hide();
                form3.Show();
            }
            // Tells the user the item can't be found
            else {
                Debug.WriteLine("Item not found.");
                MessageBox.Show("Item not found!!");
            }
        }


        // Admin Login button
        private void button1_Click(object sender, EventArgs e) {
            Form2 form2 = new Form2(items);
            form2.Show();
            this.Hide();
        }


        // Add Item button
        private void button3_Click(object sender, EventArgs e) {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        // Admin logout button
        private void button4_Click(object sender, EventArgs e) {
            Form1 form1 = new Form1(false);
            form1.Show(); 
            this.Hide();
            Debug.WriteLine("Succsessful Logout!");
        }

        // Creates a list of temp items. ONLY TO BE USED FOR DEBUGGING. These DO NOT get posted to the database and will only exist locally.
        private List<Item> itemCreation() {
            List<Item> items = new List<Item>();
            items.Add(new Item { Id = 0, Name = "Item 1", Category = "Technology", Quantity = 22, Price = 14.99M, Description = "Description here." });
            items.Add(new Item { Id = 1, Name = "Item 2", Category = "Technology", Quantity = 14, Price = 4.99M, Description = "Description here." });
            items.Add(new Item { Id = 2, Name = "Item 3", Category = "Furniture", Quantity = 19, Price = 999.99M, Description = "Description here." });
            items.Add(new Item { Id = 3, Name = "Item 4", Category = "Office Supplies", Quantity = 7, Price = 21.99M, Description = "Description here." });
            items.Add(new Item { Id = 4, Name = "Item 5", Category = "Cookware", Quantity = 59, Price = 39.99M, Description = "Description here." });

            return items;
        }
    }
}

/* Not needed with SQL database. This was the old "local storage" version of the application. Will remain here for reference.
 * 
        public Form1(bool adminStatus, List<Item> items) {

            InitializeComponent();
            Debug.WriteLine("Started.");

            // Creating the database connection
            SqlConnection cnn = ds.newConnection();

            // Updating admin status
            listView1.View = View.Details;
            label3.Text = "Admin Login Valid: " + adminStatus.ToString();
            if (adminStatus == true ) {
                button2.Visible = true;
                label2.Visible = true;
                textBox1.Visible= true;
                button4.Visible = true;
                button3.Visible = true;
            }

            // Add columns to the ListView
            listView1.Columns.Add("ID", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Category", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", 75, HorizontalAlignment.Left);
            listView1.Columns.Add("Price", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Description", 250, HorizontalAlignment.Left);

            for (int i = 0; i < items.Count; i++) {
                // Add a new item to the list view
                listView1.Items.Add(items[i].Id).SubItems.AddRange(new string[] { items[i].Name, items[i].Category, items[i].Quantity, items[i].Price, items[i].Description});
            }

            // Updates the current items list for this form
            this.items = items;
        }
        */