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

namespace WindowsFormsApplication2
{
    public partial class User_info : Form
    {
        SqlConnection con;
        SqlDataReader reader;
        SqlCommand cmd;
        public User_info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True");
             string query = "insert into Borrower (Bor_name ,Bor_ID , Phone ,  Faculty) values ('" + this.textBox1.Text + "' , '" + this.textBox2.Text + "' , '" + this.textBox3.Text + "' , '" + this.textBox4.Text + "') ";
            cmd = new SqlCommand(query , con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader.Read())
                {

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            con.Close();

        }       

   }
}
