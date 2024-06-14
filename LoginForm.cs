using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using SSD_Menu;

namespace SDD_Menu
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3J1ITD\\SQLEXPRESS2022;Initial Catalog=student;Integrated Security=True");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3J1ITD\\SQLEXPRESS2022;Initial Catalog=student;Integrated Security=True");

            string username, password;
            username = textBox1.Text;
            password = textBox2.Text;

            try
            {
                string query = "select * from dbo.Login where Username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    MessageBox.Show("Data Fetched Successfully");

                    this.Hide();
                    Form1 form = new Form1();
                    form.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Login Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }

            //string username, password;
            username = textBox1.Text;
            password = textBox2.Text;
            try
            {
                conn.Open();
                string query = "insert into dbo.Login (username,password) values (@username,@password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("inserted successfully");
                }
                else
                {
                    MessageBox.Show("Invalid username");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
