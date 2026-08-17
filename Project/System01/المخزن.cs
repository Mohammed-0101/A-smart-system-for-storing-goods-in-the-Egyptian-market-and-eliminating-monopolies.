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
    public partial class المخزن : Form
    {
        public المخزن()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            بيانات_المخزن ffr = new بيانات_المخزن();
            ffr.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            عملية_البيع_للمتاجر ffr = new عملية_البيع_للمتاجر();
            ffr.Show();
            Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StartForm sfr = new StartForm();
            sfr.Show();
            Hide();
        }
    }
}
