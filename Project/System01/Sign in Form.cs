using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System01
{
    public partial class StartForm : Form
    {
        DbUtil db1 = new DbUtil(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=System01.mdb;Persist Security Info=False");


        public static List<string> Userfactory = new List<string>() {"Ahmed" , "Mohamed"};
        public static List<string> Passwordfactory = new List<string>() {"Ahmed" , "Mohamed"};

        public static List<string> UserWarehouse = new List<string>() { "Ahmed", "Mohamed" };
        public static List<string> PasswordWarehouse = new List<string>() { "Ahmed", "Mohamed" };

        public static List<string> UserGovern = new List<string>() { "Ahmed", "Mohamed" };
        public static List<string> PasswordGovern = new List<string>() { "Ahmed", "Mohamed" };
        public StartForm()
        {
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SigningButton_Click(object sender, EventArgs e)
        {
            
            if(Passwordtxt.Text == "" || Usertxt.Text == "")
            {
                MessageBox.Show("املأ البيانات رجاءاً");
            }
            else
            {
                bool flag = false;
                if (comboBox1.SelectedItem == "مصنع")
                {
                    for (int i = 0; i < Userfactory.Count(); i++)
                    {
                        if (Usertxt.Text == Userfactory[i] && Passwordtxt.Text == Passwordfactory[i])
                        {
                            FactoryForm ffr = new FactoryForm();
                            ffr.Show();
                            Hide();
                            flag = true;
                        }

                    }
                    if (flag == false)
                    {
                        MessageBox.Show("بيانات غير صحيحة");
                    }
                }
                else if (comboBox1.SelectedItem == "مخزن")
                {
                    for (int i = 0; i < UserWarehouse.Count(); i++)
                    {
                        if (Usertxt.Text == UserWarehouse[i] && Passwordtxt.Text == PasswordWarehouse[i])
                        {
                            المخزن ffr = new المخزن();
                            ffr.Show();
                            Hide();
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("بيانات غير صحيحة");
                    }
                }
                else if (comboBox1.SelectedItem == "جهة رقابيه")
                {
                    for (int i = 0; i < UserGovern.Count(); i++)
                    {
                        if (Usertxt.Text == UserGovern[i] && Passwordtxt.Text == PasswordGovern[i])
                        {
                            GovernForm gfr = new GovernForm();
                            gfr.Show();
                            Hide();
                            flag = true;
                        }
                    }
                    if (flag == false)
                    {
                        MessageBox.Show("بيانات غير صحيحة");
                    }
                }
                else
                {
                    MessageBox.Show("برجاء تحديد الجهة");
                }
                
            }
            
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void Passwordtxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Usertxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                e.Handled = true; // Mark the event as handled
            }
        }

        private void Passwordtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.ActiveControl != null)
                {
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                }
                e.Handled = true; // Mark the event as handled
            }
        }
    }
}
