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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
//        المصانع
//المخازن
//المحلات
//الجهه الرقابية
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "المصانع")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "SELECT * FROM RegisterFactory";
                conn.ConnectionString = connection;
                conn.Open();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            else if (comboBox1.SelectedItem == "المخازن")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "SELECT * FROM RegisterWarehouse";
                conn.ConnectionString = connection;
                conn.Open();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            else if (comboBox1.SelectedItem == "المحلات")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "SELECT * FROM RegisterShop";
                conn.ConnectionString = connection;
                conn.Open();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            else if (comboBox1.SelectedItem == "الجهه الرقابية")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "SELECT * FROM RegisterGovern";
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
                MessageBox.Show("برجاء تحديد الجهه");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "المصانع")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "INSERT INTO RegisterFactory(UserName, [Password]) VALUES(@UserName, @Password)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(System.Data.OleDb.OleDbException)
                {
                    MessageBox.Show("ادخل اسم مستخدم مختلف");
                }
                

                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterFactory", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
                
            }
            else if (comboBox1.SelectedItem == "المخازن")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "INSERT INTO RegisterWarehouse(UserName, [Password]) VALUES(@UserName, @Password)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.OleDb.OleDbException)
                {
                    MessageBox.Show("ادخل اسم مستخدم مختلف");
                }


                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterWarehouse", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "المحلات")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "INSERT INTO RegisterShop(UserName, [Password]) VALUES(@UserName, @Password)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.OleDb.OleDbException)
                {
                    MessageBox.Show("ادخل اسم مستخدم مختلف");
                }


                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterShop", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "الجهه الرقابية")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "INSERT INTO RegisterGovern(UserName, [Password]) VALUES(@UserName, @Password)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (System.Data.OleDb.OleDbException)
                {
                    MessageBox.Show("ادخل اسم مستخدم مختلف");
                }


                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterGovern", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else
            {
                MessageBox.Show("برجاء تحديد الجهه");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "المصانع")
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "UPDATE RegisterFactory SET  UserName=@UserName ,[Password]=@Password WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);
                

                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();

                MessageBox.Show("تم التعديل");
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterFactory", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "المخازن")
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "UPDATE RegisterWarehouse SET  UserName=@UserName ,[Password]=@Password WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);


                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();

                MessageBox.Show("تم التعديل");
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterWarehouse", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "المحلات")
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "UPDATE RegisterShop SET  UserName=@UserName ,[Password]=@Password WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);


                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();

                MessageBox.Show("تم التعديل");
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterShop", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else if (comboBox1.SelectedItem == "الجهه الرقابية")
            {
                OleDbConnection conn = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "UPDATE RegisterGovern SET  UserName=@UserName ,[Password]=@Password WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.ConnectionString = connection;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserName", userNametxt.Text);
                cmd.Parameters.AddWithValue("@Password", Passwardtxt.Text);


                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();

                MessageBox.Show("تم التعديل");
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterGovern", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
            }
            else
            {
                MessageBox.Show("برجاء تحديد الجهه");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "المصانع")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "DELETE FROM RegisterFactory WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.ConnectionString = connection;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterFactory", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
                MessageBox.Show("تم المسح");
            }
            else if (comboBox1.SelectedItem == "المخازن")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "DELETE FROM RegisterWarehouse WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.ConnectionString = connection;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterWarehouse", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
                MessageBox.Show("تم المسح");
            }
            else if (comboBox1.SelectedItem == "المحلات")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "DELETE FROM RegisterShop WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.ConnectionString = connection;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterShop", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
                MessageBox.Show("تم المسح");
            }
            else if (comboBox1.SelectedItem == "الجهه الرقابية")
            {
                OleDbConnection conn = new OleDbConnection();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";

                string sql = "DELETE FROM RegisterGovern WHERE UserName = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.ConnectionString = connection;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                DataTable ds = new DataTable();
                BindingSource bSource = new BindingSource();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM RegisterGovern", conn);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                conn.Close();
                MessageBox.Show("تم المسح");
            }
            else
            {
                MessageBox.Show("برجاء تحديد الجهه");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "المصانع")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from RegisterFactory WHERE UserName like ('" + searchtxt.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if (comboBox1.SelectedItem == "المخازن")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from RegisterWarehouse WHERE UserName like ('" + searchtxt.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if (comboBox1.SelectedItem == "المحلات")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from RegisterShop WHERE UserName like ('" + searchtxt.Text + "%')";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.ConnectionString = connection;
                con.Open();
                DataTable ds = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, con);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds;
                con.Close();
            }
            else if (comboBox1.SelectedItem == "الجهه الرقابية")
            {
                OleDbConnection con = new OleDbConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                String connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=System01.accdb;Persist Security Info=True";
                string sql = "Select * from RegisterGovern WHERE UserName like ('" + searchtxt.Text + "%')";
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
                MessageBox.Show("برجاء تحديد الجهه");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GovernForm v = new GovernForm();
            v.Show();
            Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            userNametxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Passwardtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }
    }
}
