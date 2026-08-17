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
    public partial class عملية_البيع_للمتاجر : Form
    {
        public عملية_البيع_للمتاجر()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM SW_Transaction";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int quan =int.Parse( quanttxt.Text);
            string RFID = RFtxt.Text;
            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            //update
            string sql2 = "UPDATE Warehouses SET  ProductBuyedQuantity=@prodquan  WHERE WarehouseID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            OleDbCommand CMD = new OleDbCommand(sql2, conn);

            //insert
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "INSERT INTO SW_Transaction(RF_ID,WarehouseID,Warehouse_name, ShopID, Shop_name, Product_name, ProductUnitPrice, ProductBuyedQuantity,ProductTotalPrice,BuyingDate) VALUES(@RF_ID,@WarehouseID,@Warehouse_name, @ShopID,@Shop_name, @Product_name, @ProductUnitPrice, @ProductBuyedQuantity, @ProductTotalPrice,@BuyingDate)";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;

            conn.Open();
            //القيمة الكلية
            string sql3 = ("SELECT ProductBuyedQuantity FROM Warehouses WHERE WarehouseID = '" + widtxt.Text+"'");
            OleDbCommand val = new OleDbCommand(sql3, conn);
            double vq = double.Parse(val.ExecuteScalar().ToString());
            CMD.Parameters.AddWithValue("@prodquan", vq-quan);


            cmd.Parameters.AddWithValue("@RF_ID", RFtxt.Text);
            cmd.Parameters.AddWithValue("@WarehouseID", widtxt.Text);
            cmd.Parameters.AddWithValue("@Warehouse_name", wnametxt.Text);
            cmd.Parameters.AddWithValue("@ShopID", sidtxt.Text);
            cmd.Parameters.AddWithValue("@Shop_name", snametxt.Text);
            cmd.Parameters.AddWithValue("@Product_name", pnametxt.Text);
            cmd.Parameters.AddWithValue("@ProductUnitPrice", unpricetxt.Text);
            cmd.Parameters.AddWithValue("@ProductBuyedQuantity", quanttxt.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice", (float.Parse(unpricetxt.Text) * float.Parse(quanttxt.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", datebuytxt.Text);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM SW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

            string sql = "DELETE FROM SW_Transaction WHERE WarehouseID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'AND ShopID = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
            conn.ConnectionString = connection;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM SW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
            MessageBox.Show("تم المسح");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "UPDATE SW_Transaction SET  WarehouseID=@WarehouseID ,RF_ID=@RF_ID,Warehouse_name=@Warehouse_name , ShopID=@ShopID, Shop_name=@Shop_name, Product_name=@Product_name, ProductUnitPrice=@ProductUnitPrice, ProductBuyedQuantity=@ProductBuyedQuantity ,ProductTotalPrice=@ProductTotalPrice, BuyingDate=@BuyingDate WHERE WarehouseID = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'AND ShopID = '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'";
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            conn.ConnectionString = connection;
            conn.Open();
            cmd.Parameters.AddWithValue("@RF_ID", RFtxt.Text);
            cmd.Parameters.AddWithValue("@WarehouseID", widtxt.Text);
            cmd.Parameters.AddWithValue("@Warehouse_name", wnametxt.Text);
            cmd.Parameters.AddWithValue("@ShopID", sidtxt.Text);
            cmd.Parameters.AddWithValue("@Shop_name", snametxt.Text);
            cmd.Parameters.AddWithValue("@Product_name", pnametxt.Text);
            cmd.Parameters.AddWithValue("@ProductUnitPrice", unpricetxt.Text);
            cmd.Parameters.AddWithValue("@ProductBuyedQuantity", quanttxt.Text);
            cmd.Parameters.AddWithValue("@ProductTotalPrice", (float.Parse(unpricetxt.Text) * float.Parse(quanttxt.Text)));
            cmd.Parameters.AddWithValue("@BuyingDate", datebuytxt.Text);

            da.UpdateCommand = cmd;
            da.UpdateCommand.ExecuteNonQuery();

            MessageBox.Show("تم التعديل");
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM SW_Transaction", conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            conn.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            widtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            wnametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sidtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            snametxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            pnametxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            unpricetxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            quanttxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            datebuytxt.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            المخزن ffr = new المخزن();
            ffr.Show();
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter();
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "Select * from SW_Transaction WHERE Warehouse_name like ('" + textBox2.Text + "%')";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.ConnectionString = connection;
            con.Open();
            DataTable ds = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
