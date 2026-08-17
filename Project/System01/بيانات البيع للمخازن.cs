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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "INSERT INTO FW_Transaction(WarehouseID,FactoryName, WarehouseName, RF_ID, ProductName, ProductUnitPrice, ProductBuyedQuantity,ProductTotalPrice,BuyingDate) VALUES(@wid,@fname, @wname,@rfid, @prodname, @produnprice, @prodquan, @ProductTotalPrice,@BuyingDate)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@wid", warehouse_IDtxt.Text);
            cmd.Parameters.AddWithValue("@fname", factory_nametxt.Text);
            cmd.Parameters.AddWithValue("@wname", warehouse_nametxt.Text);
            cmd.Parameters.AddWithValue("@rfid", RF_IDtxt.Text);
            cmd.Parameters.AddWithValue("@prodname", product_nametxt.Text);
            cmd.Parameters.AddWithValue("@produnprice", UNpricetxt.Text);
            cmd.Parameters.AddWithValue("@prodquan", product_quantity.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice",(float.Parse( UNpricetxt.Text)* float.Parse(product_quantity.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", buying_datetxt.Text);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM FW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM FW_Transaction";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RF_IDtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            factory_nametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            warehouse_IDtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            warehouse_nametxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            product_nametxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            UNpricetxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            product_quantity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            
            buying_datetxt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "UPDATE FW_Transaction SET  WarehouseID=@wid ,FactoryName=@fname , WarehouseName=@wname, RF_ID=@rfid, ProductName=@prodname, ProductUnitPrice=@produnprice, ProductBuyedQuantity=@prodquan ,ProductTotalPrice=@ProductTotalPrice, BuyingDate=@BuyingDate WHERE RF_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+ "'AND WarehouseID = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@wid", warehouse_IDtxt.Text);
            cmd.Parameters.AddWithValue("@fname", factory_nametxt.Text);
            cmd.Parameters.AddWithValue("@wname", warehouse_nametxt.Text);
            cmd.Parameters.AddWithValue("@rfid", RF_IDtxt.Text);
            cmd.Parameters.AddWithValue("@prodname", product_nametxt.Text);
            cmd.Parameters.AddWithValue("@produnprice", UNpricetxt.Text);
            cmd.Parameters.AddWithValue("@prodquan", product_quantity.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice", (float.Parse(UNpricetxt.Text) * float.Parse(product_quantity.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", buying_datetxt.Text);

            da.UpdateCommand = cmd;
            da.UpdateCommand.ExecuteNonQuery();
            
            MessageBox.Show("تم التعديل");
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM FW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

            string sql = "DELETE FROM FW_Transaction WHERE RF_ID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'AND WarehouseID = '"+ dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
            conn.ConnectionString = connection;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM FW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            MessageBox.Show("تم المسح");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "Select * from FW_Transaction WHERE FactoryName like ('" + textBox1.Text + "%')";
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

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FactoryForm ffr = new FactoryForm();
            ffr.Show();
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
