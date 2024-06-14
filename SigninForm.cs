using SSD_Menu;
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

namespace SDD_Menu
{
    public partial class SigninForm : Form
    {
        public SigninForm()
        {
            InitializeComponent();
        }

        private void SigninForm_Load(object sender, EventArgs e)
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
                conn.Open();
                string query = "insert into dbo.Login (username,password) values (@username,@password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("inserted successfully");

                    this.Hide();
                    LoginForm form = new LoginForm();
                    form.ShowDialog();

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
