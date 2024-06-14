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
using System.Drawing.Imaging;
using System.Windows.Forms.VisualStyles;

namespace SSD_Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3J1ITD\\SQLEXPRESS2022;Initial Catalog=student;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            forcombobox();
            loadtogrid();
        }
        private void forcombobox()
        {
            SqlCommand cmd = new SqlCommand("Select  empid, empname, empdep, empage, empsalary from dbo.EmployeeDetails", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            DataRow emptyRow = datatable.NewRow();
            emptyRow["empid"] = -1;
            emptyRow["empname"] = "Select";
            datatable.Rows.InsertAt(emptyRow, 0);
            studentscomboBox.DataSource = datatable;
            studentscomboBox.DisplayMember = "empname";
        }
        private void loadtogrid()
        {
            SqlCommand cmd = new SqlCommand("Select  * from dbo.EmployeeDetails", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            da.Fill(datatable);

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select"; ;
            checkBoxColumn.Name = "selectCheckBox";
            checkBoxColumn.Width = 50;
            dataGridView1.Columns.Add(checkBoxColumn);

            dataGridView1.DataSource= datatable;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string empname;
            empname = studentscomboBox.Text;
         

            try
            {
                string query = "Select * from dbo.EmployeeDetails where empname = '" + studentscomboBox.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    empname = studentscomboBox.Text;
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Data Fetched Successfully");
                }
                else
                {
                    MessageBox.Show("Invalid empname");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            forcombobox();
            loadtogrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row = dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = Row.Cells["empid"].Value.ToString();
                    textBox2.Text = Row.Cells["empname"].Value.ToString();
                    textBox3.Text = Row.Cells["empdep"].Value.ToString();
                    textBox4.Text = Row.Cells["empage"].Value.ToString();
                    textBox5.Text = Row.Cells["empsalary"].Value.ToString();
                    textBox6.Text = Row.Cells["empemail"].Value.ToString();
                }
            }
        }
    }
}