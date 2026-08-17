using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace System01
{
    class DbUtil
    {
        public OleDbConnection Connection;
        public OleDbDataAdapter da;
        public OleDbCommand cmd;

        public DbUtil(string str)
        {

            Connection = new OleDbConnection(str);
            try { Connection.Open(); }
            catch { MessageBox.Show("خطأ بالربط بقاعدة البيانات "); }
        }


        internal void fillGridView(string p, DataGridView dataGridView1)
        {

            da = new OleDbDataAdapter(p, Connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }



        internal bool InsertRow(string tablename, string arributesnames_Comma_separated, string vals_commasepareted)
        {
            cmd = new OleDbCommand("insert into " + tablename + " (" + arributesnames_Comma_separated + ") values (" + vals_commasepareted + ")", Connection);
            try { cmd.ExecuteNonQuery(); }
            catch { MessageBox.Show(" غير قادر على التنفيذ برجاء الاتصال بمركز تطوير نظم المعلومات الادارية  "); return false; }
            return true;



        }

        internal void fillList(string p, ListBox listBox1)
        {
            ///  listBox1.Items.Clear();
            da = new OleDbDataAdapter(p, Connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            listBox1.DataSource = ds.Tables[0];
            listBox1.DisplayMember = ds.Tables[0].Columns[1].ColumnName;
            listBox1.ValueMember = ds.Tables[0].Columns[0].ColumnName;
            listBox1.Enabled = true;
        }

        internal double getScalarValue(string p)
        {
            cmd = new OleDbCommand(p, Connection);

            double ret = double.Parse(cmd.ExecuteScalar().ToString());
            return ret;
        }

        internal void exQuery(string p)
        {
            cmd = new OleDbCommand(p, Connection);
            cmd.ExecuteNonQuery();

        }

        internal bool ValidateTextBox(Control ctrl, string p)
        {
            if (ctrl.GetType() == typeof(ListBox))
                if ((ctrl as ListBox).SelectedIndex < 0)
                {
                    MessageBox.Show(p);
                    ctrl.Focus();
                    return false;
                }
            if (ctrl.GetType() == typeof(TextBox))
                if ((ctrl as TextBox).Text.Trim().Equals(""))
                {
                    MessageBox.Show(p);
                    ctrl.Focus();
                    return false;
                }
            return true;
        }
    }
}
