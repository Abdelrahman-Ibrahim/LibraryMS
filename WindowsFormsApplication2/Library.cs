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
using System.Data.OleDb;
namespace WindowsFormsApplication2
{
    public partial class Library : Form
    {
        
        SqlConnection con;
        SqlDataAdapter adp ,adp1 ,adp2 , adp3;
        DataSet dset , dset1 ,dset2 , dset3;
        SqlCommandBuilder combl;
        DataTable table;
        SqlCommand cmd;
        
      
        public Library()
        {
            InitializeComponent();
        }

        private void Library_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = false;


             try
            {
                con = new SqlConnection();
                con.ConnectionString ="Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
                con.Open();
                adp = new SqlDataAdapter("select * from Book",con);
                dset = new System.Data.DataSet();
                adp.Fill(dset, "Books_details");
                dataGridView1.DataSource = dset.Tables[0];
                con.Close(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error\n" + ex.Message , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }

             try
             {
                 con = new SqlConnection();
                 con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
                 con.Open();
                 adp1 = new SqlDataAdapter("select * from Author", con);
                 dset1 = new System.Data.DataSet();
                 adp1.Fill(dset1, "Authors_details");
                 dataGridView2.DataSource = dset1.Tables[0];
                 con.Close(); 
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             try
             {
                 con = new SqlConnection();
                 con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
                 con.Open();
                 adp2 = new SqlDataAdapter("select * from Borrower", con);
                 dset2 = new System.Data.DataSet();
                 adp2.Fill(dset2, "Borrowers_details");
                 dataGridView3.DataSource = dset2.Tables[0];
                 con.Close(); 
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }


             try
             {
                 con = new SqlConnection();
                 con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
                 con.Open();
                 adp3 = new SqlDataAdapter("select * from Borrow", con);
                 dset3 = new System.Data.DataSet();
                 adp3.Fill(dset3, "Borrow_details");
                 dataGridView4.DataSource = dset3.Tables[0];
                 con.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }


            //searchdata("");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox4.Visible = false;
            groupBox3.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = true;
            groupBox3.Visible = false;
        }
        private void button12_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = true;

        }




      

     

     


     
 

       private void button15_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from Borrow where  Bor_ID='" + textBox8.Text + "'";
           cmd.ExecuteNonQuery();
           table = new DataTable();
           adp3 = new SqlDataAdapter(cmd);
           adp3.Fill(table);
           dataGridView4.DataSource = table;
           con.Close();

           textBox8.Clear();
       }

       private void button14_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "delete from Borrow where  Bor_ID='" + textBox7.Text + "'";
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("Record deleted successfully");
           textBox7.Clear();
       }

       private void button16_Click_1(object sender, EventArgs e)
       {
           try
           {
               combl = new SqlCommandBuilder(adp3);
               adp3.Update(dset3, "Borrow_details");
               MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void button9_Click_1(object sender, EventArgs e)
       {

           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from Borrower where  Bor_ID='" + textBox2.Text + "'";
           cmd.ExecuteNonQuery();
           table = new DataTable();
           adp2 = new SqlDataAdapter(cmd);
           adp2.Fill(table);
           dataGridView3.DataSource = table;
           con.Close();

           textBox2.Clear();

       }

       private void button13_Click(object sender, EventArgs e)
       {

           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "delete from Borrower where  Bor_ID='" + textBox6.Text + "'";
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("Record deleted successfully");
           textBox6.Clear();
       }

       private void button7_Click_1(object sender, EventArgs e)
       {
           try
           {
               combl = new SqlCommandBuilder(adp2);
               adp2.Update(dset2, "Borrowers_details");
               MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void button4_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from Book where  ISBN='" + textBox4.Text + "'";
           cmd.ExecuteNonQuery();
           table = new DataTable();
           adp = new SqlDataAdapter(cmd);
           adp.Fill(table);
           dataGridView1.DataSource = table;
           con.Close();

           textBox4.Clear();

       }

       private void button11_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "delete from Book where  ISBN='" + textBox5.Text + "'";
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("Record deleted successfully");
           textBox5.Clear();
       }

       private void button5_Click_1(object sender, EventArgs e)
       {
           try
           {
               combl = new SqlCommandBuilder(adp);
               adp.Update(dset, "Books_details");
               MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }

       private void button8_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from Author where  AuthorID='" + textBox1.Text + "'";
           cmd.ExecuteNonQuery();
           table = new DataTable();
           adp1 = new SqlDataAdapter(cmd);
           adp1.Fill(table);
           dataGridView2.DataSource = table;
           con.Close();

           textBox1.Clear();
       }

       private void button10_Click_1(object sender, EventArgs e)
       {
           con = new SqlConnection();
           con.ConnectionString = "Data Source=DESKTOP-4BFKE5S;Initial Catalog=Library_MS;Integrated Security=True";
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandType = CommandType.Text;
           cmd.CommandText = "delete from Author where  AuthorID='" + textBox3.Text + "'";
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("Record deleted successfully");
           textBox3.Clear();
       }

       private void button6_Click_1(object sender, EventArgs e)
       {
           try
           {
               combl = new SqlCommandBuilder(adp1);
               adp1.Update(dset1, "Authors_details");
               MessageBox.Show("Information updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }


       private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
       }

       private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           textBox7.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
       }

       private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           textBox6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
       }

       private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
       {
           textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
       }

       private void button17_Click(object sender, EventArgs e)
       {
           New_Admin obj = new New_Admin();
           obj.Show();
       }

       private void pictureBox2_Click(object sender, EventArgs e)
       {
           this.Hide();
           login obj = new login();
           obj.Show();
       }

    


     

    
    }
}
