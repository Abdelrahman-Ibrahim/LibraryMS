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
    public partial class login : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True");
        int count = 0;
        public login()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            DataTable table = new DataTable();
            SqlDataAdapter data = new SqlDataAdapter("select * from Librarian where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ", con);

            data.Fill(table);
            count = Convert.ToInt32(table.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Username and Password doesn't match");
            }
            else
            {
                this.Hide();
                Library obj = new Library();
                obj.Show();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start obj = new Start();
            obj.Show();
        }
  

    }
}
