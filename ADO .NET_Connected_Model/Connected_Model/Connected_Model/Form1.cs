using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connected_Model
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=EL-GENIO😎;Initial Catalog=EmployeeDB;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }
        // Insert new Employee
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employees (FirstName, LastName, DeptNumber, DeptName) VALUES (@fname, @lname, @deptnum, @deptname)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@lname", textBox3.Text);
                cmd.Parameters.AddWithValue("@deptnum", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@deptname", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Inserted Successfully.");
                button5_Click(sender, e);
            }
        }
        // Update existing employee
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Employees SET FirstName=@fname, LastName=@lname, DeptNumber=@deptnum, DeptName=@deptname WHERE EmployeeID=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@fname", textBox2.Text);
                cmd.Parameters.AddWithValue("@lname", textBox3.Text);
                cmd.Parameters.AddWithValue("@deptnum", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@deptname", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Updated Successfully.");
                button5_Click(sender, e);
            }
        }
        // Delete an employee
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE EmployeeID=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted Successfully.");
                button5_Click(sender, e);
            }
        }
        // Search for an existing employee
        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE EmployeeID=@id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader["FirstName"].ToString();
                    textBox3.Text = reader["LastName"].ToString();
                    textBox4.Text = reader["DeptNumber"].ToString();
                    textBox5.Text = reader["DeptName"].ToString();
                }
                else
                {
                    MessageBox.Show("Employee not found.");
                }
            }
        }
        // Display the employees
        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}