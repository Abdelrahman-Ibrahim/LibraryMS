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
    public partial class New_Admin : Form
    {
        SqlConnection con;
        SqlDataAdapter adp, adp1, adp2, adp3;
        DataSet dset, dset1, dset2, dset3;
        SqlCommandBuilder combl;
        DataTable table;
        SqlCommand cmd;
        public New_Admin()
        {
            InitializeComponent();
        }

        private void New_Admin_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection();
                con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
                con.Open();
                adp = new SqlDataAdapter("select * from Librarian", con);
                dset = new System.Data.DataSet();
                adp.Fill(dset, "Admin_details");
                dataGridView1.DataSource = dset.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                combl = new SqlCommandBuilder(adp);
                adp.Update(dset, "Admin_details");
                MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Librarian where  Username='" + textBox7.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record deleted successfully");
            textBox7.Clear();
        }

    }
}
