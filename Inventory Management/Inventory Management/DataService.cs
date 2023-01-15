// Created by Casey Huz for CST-451/452
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Security.Policy;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;

namespace Inventory_Management {
    public class DataService {

        // Creates a new database connection.
        public SqlConnection newConnection() {
            string connectionString;
            SqlConnection cnn;

            // Replace this with the connection string of any external database that is being utilized.
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Casey\source\repos\Inventory Management\Inventory Management\Database1.mdf"";Integrated Security=True";

            cnn = new SqlConnection(connectionString);
            return cnn;
        }

        // Gets all items from the current database and returns them as a list of Item objects
        public List<Item> getAllItems() {
            // Creating a new database connection
            SqlConnection cnn = newConnection();
            // Creating the list of item objects to pass back
            List<Item> items = new List<Item>();

            // Connection open and execution of SQL query
            cnn.Open();
            string query = "SELECT * FROM dbo.Items";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataReader reader = cmd.ExecuteReader();
            Debug.WriteLine("Item Creation started.");
            while (reader.Read()) {
                // Reading the output of the server and creating a new item with the data
                items.Add(new Item { Id = reader.GetInt32(0), Name = reader.GetString(1), Category = reader.GetString(2), Quantity = reader.GetInt32(3), Price = reader.GetDecimal(4), Description = reader.GetString(5)});
                Debug.WriteLine("Item Created.");
            }

            // Closing the connection
            cnn.Close();

            // Return the list of items
            return items;
            
        }

        // Retrieves one item from the database based on a passed ID
        public Item getOneItem(int id) {
            SqlConnection cnn = newConnection();
            Item item = new Item();

            // Connection open and execution of SQL query
            cnn.Open();
            string query = "SELECT * FROM dbo.Items WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            Debug.WriteLine("Item Creation started.");
            if (reader.Read()) {
                // Reading the output of the server and creating a new item with the data
                Item temp = new Item { Id = reader.GetInt32(0), Name = reader.GetString(1), Category = reader.GetString(2), Quantity = reader.GetInt32(3), Price = reader.GetDecimal(4), Description = reader.GetString(5)};
                item = temp;
                Debug.WriteLine("Item Created.");
            }

            // Closing the connection
            cnn.Close();

            // Return the found item
            return item;
        }

        // Updates the details of an existing object based on the data input in the form fields
        public bool updateItem(Item item) {
            // Creating the database connection
            SqlConnection cnn = newConnection();

            // Connection open and execution of SQL query
            cnn.Open();
            string query = "UPDATE dbo.Items SET Name=@name, Category=@category, Quantity=@quantity, Price=@price, Description=@description WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, cnn);

            // Adding parameters
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@description", item.Description);

            // Executes the query and prints the number of rows affected.
            int rowsaffected = cmd.ExecuteNonQuery();
            Debug.WriteLine("Rows affected: " + rowsaffected); 

            // Closing the connection
            cnn.Close();

            // Determines if the update was successful
            if(rowsaffected == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        // Removes the item with the associated ID from the database
        public bool removeItem(int itemId) {
            SqlConnection cnn = newConnection();

            // Connection open and execution of SQL query
            cnn.Open();
            string query = "DELETE from dbo.Items WHERE id=@id";
            SqlCommand cmd = new SqlCommand(query, cnn);

            // Adding parameters
            cmd.Parameters.AddWithValue("@id", itemId);
            // Executes the query and prints the number of rows affected.
            int rowsaffected = cmd.ExecuteNonQuery();
            Debug.WriteLine("Rows affected: " + rowsaffected);

            // Closing the connection
            cnn.Close();

            // Returns if the deletion was successful
            if (rowsaffected == 1) {
                return true;
            }
            else {
                return false;
            }
        }

        // Adds an item to the database based on data from the form fields. This data is passed through an Item object which is created in the form
        public bool addItem(Item item) {
            // Creating a new connection
            SqlConnection cnn = newConnection();
            cnn.Open();

            // Building the query
            string query = "INSERT INTO dbo.Items (Name, Category, Quantity, Price, Description) VALUES (@name, @category, @quantity, @price, @description)";
            SqlCommand cmd = new SqlCommand(query, cnn);

            // Adding parameters
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@description", item.Description);

            // Executes the query and prints the number of rows affected.
            int rowsaffected = cmd.ExecuteNonQuery();
            Debug.WriteLine("Rows affected: " + rowsaffected);

            // Closing the connection
            cnn.Close();

            // Returns if the addition to the server was successful
            if (rowsaffected == 1) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
