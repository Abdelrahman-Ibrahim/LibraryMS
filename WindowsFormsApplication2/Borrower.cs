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
    public partial class Borrower : Form
    {
        SqlConnection con;
        SqlDataAdapter adp;
        SqlDataReader reader;
        SqlCommand cmd;
        public Borrower()
        {
            InitializeComponent();
        }

        private void Borrower_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            
            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
            con.Open();
            cmd.CommandText = "select * from Book";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
           // listView.Items.Clear();

            while (reader.Read())
            {
                ListViewItem lv = new ListViewItem(reader[0].ToString());
                lv.SubItems.Add(reader[1].ToString());
                lv.SubItems.Add(reader[2].ToString());
                lv.SubItems.Add(reader[3].ToString());
                lv.SubItems.Add(reader[4].ToString());
                lv.SubItems.Add(reader[5].ToString());
                listView.Items.Add(lv);
            }
            reader.Close();
            cmd.Dispose();
                con.Close();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            User_info obj = new User_info() ;
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True");
            string query = "insert into Borrow (Bor_ID ,ISBN , Bor_date, End_date) values ('" + this.textBox1.Text + "' , '" + this.textBox2.Text + "' , '" + this.textBox3.Text + "' , '" + this.textBox4.Text + "') ";
            cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                MessageBox.Show("Saved");
                while (reader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            con.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            panel1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }

     

      
    }
}
