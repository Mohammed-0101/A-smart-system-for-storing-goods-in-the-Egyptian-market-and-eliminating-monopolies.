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
    public partial class GovernForm : Form
    {
        public GovernForm()
        {
            InitializeComponent();
        }

        private void SearchTxt_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == "بيانات المصنع")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from Factory WHERE FactoryName like ('" + Search_text.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if(comboBox1.SelectedItem == "بيانات البيع للمخازن")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from FW_Transaction WHERE FactoryName like ('" + Search_text.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if(comboBox1.SelectedItem == "بيانات المخزن")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from Warehouses WHERE WarehouseName like ('" + Search_text.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if(comboBox1.SelectedItem == "بيانات البيع للمتاجر")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from SW_Transaction WHERE Warehouse_name like ('" + Search_text.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else
            {
                MessageBox.Show("برجاء تحديد اختيار من القائمة");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StartForm sfr = new StartForm();
            sfr.Show();
            Hide();
        }

        private void Viewtxt_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "بيانات المصنع")
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
            }
            else if (comboBox1.SelectedItem == "بيانات البيع للمخازن")
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
            else if (comboBox1.SelectedItem == "بيانات المخزن")
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
            else if (comboBox1.SelectedItem == "بيانات البيع للمتاجر")
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
            else
            {
                MessageBox.Show("برجاء تحديد اختيار من القائمة");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            DateTime dnow =  DateTime.Today;
            
            
            String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
            string sql = "SELECT * FROM FW_Transaction WHERE FW_Transaction.[BuyingDate] <= #" + Convert.ToString(dnow.AddDays(-40).Date) + "#;";
            //string sql = "SELECT * FROM FW_Transaction WHERE dnow-BuyingDate>TimeSpan.FromDays(30)";
            conn.ConnectionString = connection;
            conn.Open();
            DataTable ds = new DataTable();
            BindingSource bSource = new BindingSource();
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
        }
    }
}
