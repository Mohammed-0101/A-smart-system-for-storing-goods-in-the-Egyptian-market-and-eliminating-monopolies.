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
    public partial class بيانات_المخزن : Form
    {
        public بيانات_المخزن()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM Warehouses";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "INSERT INTO Warehouses(WarehouseID, WarehouseName, RF_ID, ProductName, ProductUnitPrice, ProductBuyedQuantity,ProductTotalPrice,BuyingDate) VALUES(@WarehouseID, @WarehouseName, @RF_ID, @ProductName, @ProductUnitPrice, @ProductBuyedQuantity,@ProductTotalPrice,@BuyingDate)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            //@WarehouseID, @WarehouseName, @RF_ID, @ProductName, @ProductUnitPrice, @ProductBuyedQuantity,@ProductTotalPrice,@BuyingDate
            cmd.Parameters.AddWithValue("@WarehouseID", warehouseidtxt.Text);
            cmd.Parameters.AddWithValue("@WarehouseName", wnametxt.Text);
            cmd.Parameters.AddWithValue("@RF_ID", rfidtxt.Text);
            cmd.Parameters.AddWithValue("@ProductName", productnametxt.Text);
            cmd.Parameters.AddWithValue("@prodProductUnitPricequan", UNpricetxt.Text);
            cmd.Parameters.AddWithValue("@ProductBuyedQuantity", quntitytxt.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice",(float.Parse(UNpricetxt.Text)*float.Parse(quntitytxt.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", datebuyingtxt.Text);

            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Warehouses", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void wnametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

            string sql = "DELETE FROM Warehouses WHERE WarehouseID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            conn.ConnectionString = connection;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Warehouses", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            MessageBox.Show("تم المسح");
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            warehouseidtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            wnametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            rfidtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            productnametxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            UNpricetxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            quntitytxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            datebuyingtxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "UPDATE Warehouses SET  WarehouseID=@WarehouseID ,WarehouseName=@WarehouseName , RF_ID=@RF_ID,  ProductName=@ProductName, ProductUnitPrice=@ProductUnitPrice, ProductBuyedQuantity=@ProductBuyedQuantity ,ProductTotalPrice=@ProductTotalPrice, BuyingDate=@BuyingDate WHERE WarehouseID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@WarehouseID", warehouseidtxt.Text);
            cmd.Parameters.AddWithValue("@WarehouseName", wnametxt.Text);
            cmd.Parameters.AddWithValue("@RF_ID", rfidtxt.Text);
            cmd.Parameters.AddWithValue("@ProductName", productnametxt.Text);
            cmd.Parameters.AddWithValue("@ProductUnitPrice", UNpricetxt.Text);
            cmd.Parameters.AddWithValue("@ProductBuyedQuantity", quntitytxt.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice", Convert.ToString(float.Parse(UNpricetxt.Text) * float.Parse(quntitytxt.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", datebuyingtxt.Text);

            da.UpdateCommand = cmd;
            da.UpdateCommand.ExecuteNonQuery();
            //try
            //{
            //    da.UpdateCommand.ExecuteNonQuery();
            //}
            //catch (System.Data.OleDb.OleDbException)
            //{

            //}
            MessageBox.Show("تم التعديل");
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Warehouses", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "Select * from Warehouses WHERE WarehouseName like ('" + textBox3.Text + "%')";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.ConnectionString = connection;
            con.Open();
            DataTable ds = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            المخزن ffr = new المخزن();
            ffr.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
