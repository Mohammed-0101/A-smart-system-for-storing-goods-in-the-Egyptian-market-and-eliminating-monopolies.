using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace System01
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        //internal DbUtil db1 = new DbUtil(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=System01.mdb;Persist Security Info=False");



        /*public DataTable LoadDb()
        {
            conn.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM Factory";
            OleDbCommand com = new OleDbCommand(query, conn);
            OleDbDataAdapter oad = new OleDbDataAdapter(com);
            oad.Fill(dt);
            conn.Close();
            return dt;
        }*/

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM Factory";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            //db1.fillGridView("SELECT * FROM Factory", dataGridView1);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "INSERT INTO Factory(RF_ID, FactoryName, ProductName, ProductUnitPrice, ProductQuantity, ProductionDate) VALUES(@rf, @facname, @prodname, @produnprice, @prodquan, @proddate)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@rf", RF_txt.Text);
            cmd.Parameters.AddWithValue("@facname", FactoryNametxt.Text);
            cmd.Parameters.AddWithValue("@prodname", ProdNametxt.Text);
            cmd.Parameters.AddWithValue("@produnprice", ProdPricetxt.Text);
            cmd.Parameters.AddWithValue("@prodquan", Quantitytxt.Text);
            cmd.Parameters.AddWithValue("@proddate", ProdDatetxt.Text);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Factory", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RF_txt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FactoryNametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ProdNametxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ProdPricetxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Quantitytxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ProdDatetxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection();
            //OleDbDataAdapter da = new OleDbDataAdapter();
            //String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            //string sql = "UPDATE Factory SET  FactoryName = @facname WHERE RF_ID = '"+ dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'";
            //OleDbCommand cmd = new OleDbCommand(sql, conn);
            //conn.ConnectionString = connection;
            //conn.Open();
            //cmd.Parameters.AddWithValue("@facname", FactoryNametxt.Text);
            //cmd.Parameters.AddWithValue("@prodname", ProdNametxt.Text);
            //cmd.Parameters.AddWithValue("@produnprice", ProdPricetxt.Text);
            //cmd.Parameters.AddWithValue("@prodquan", Quantitytxt.Text);
            //cmd.Parameters.AddWithValue("@proddate", ProdDatetxt.Text);
            //cmd.Parameters.AddWithValue("@rf", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            //da.UpdateCommand = cmd;
            //da.UpdateCommand.ExecuteNonQuery();
            //conn.Close();
            //MessageBox.Show("تم التعديل");

            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "UPDATE Factory SET  FactoryName = @facname, ProductName = @prodName, ProductUnitPrice = @produnprice, ProductQuantity = @prodquan, ProductionDate = @proddate WHERE RF_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@facname", FactoryNametxt.Text);
            cmd.Parameters.AddWithValue("@prodname", ProdNametxt.Text);
            cmd.Parameters.AddWithValue("@produnprice", ProdPricetxt.Text);
            cmd.Parameters.AddWithValue("@prodquan", Quantitytxt.Text);
            cmd.Parameters.AddWithValue("@proddate", ProdDatetxt.Text);
            cmd.Parameters.AddWithValue("@rf", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            da.UpdateCommand = cmd;
            da.UpdateCommand.ExecuteNonQuery();
            MessageBox.Show("تم التعديل");
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Factory", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

            string sql = "DELETE FROM Factory WHERE RF_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            conn.ConnectionString = connection;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Factory", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            MessageBox.Show("تم المسح");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM Factory WHERE FactoryName LIKE '% " + textBox1.Text + "%' ";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();*/

            OleDbConnection con = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "Select * from Factory WHERE FactoryName like ('" + textBox1.Text + "%')";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.ConnectionString = connection;
            con.Open();
            DataTable ds = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            con.Close();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FactoryForm ffr = new FactoryForm();
            ffr.Show();
            Hide();
        }
    }
}
