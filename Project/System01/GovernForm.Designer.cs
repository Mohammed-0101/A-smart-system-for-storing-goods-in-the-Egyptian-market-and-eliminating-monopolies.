
namespace System01
{
    partial class GovernForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GovernForm));
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SearchTxt = new System.Windows.Forms.Button();
            this.Search_text = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Viewtxt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button7.BackgroundImage")));
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Location = new System.Drawing.Point(844, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(32, 27);
            this.button7.TabIndex = 26;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Location = new System.Drawing.Point(805, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(33, 27);
            this.button6.TabIndex = 25;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 11);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(706, 470);
            this.dataGridView1.TabIndex = 27;
            // 
            // SearchTxt
            // 
            this.SearchTxt.Location = new System.Drawing.Point(728, 289);
            this.SearchTxt.Margin = new System.Windows.Forms.Padding(2);
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Size = new System.Drawing.Size(150, 41);
            this.SearchTxt.TabIndex = 28;
            this.SearchTxt.Text = "بحث";
            this.SearchTxt.UseVisualStyleBackColor = true;
            this.SearchTxt.Click += new System.EventHandler(this.SearchTxt_Click);
            // 
            // Search_text
            // 
            this.Search_text.Location = new System.Drawing.Point(728, 255);
            this.Search_text.Margin = new System.Windows.Forms.Padding(2);
            this.Search_text.Multiline = true;
            this.Search_text.Name = "Search_text";
            this.Search_text.Size = new System.Drawing.Size(150, 30);
            this.Search_text.TabIndex = 29;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "بيانات المصنع",
            "بيانات البيع للمخازن",
            "بيانات المخزن",
            "بيانات البيع للمتاجر"});
            this.comboBox1.Location = new System.Drawing.Point(727, 169);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(150, 21);
            this.comboBox1.TabIndex = 30;
            // 
            // Viewtxt
            // 
            this.Viewtxt.Location = new System.Drawing.Point(726, 199);
            this.Viewtxt.Margin = new System.Windows.Forms.Padding(2);
            this.Viewtxt.Name = "Viewtxt";
            this.Viewtxt.Size = new System.Drawing.Size(150, 41);
            this.Viewtxt.TabIndex = 28;
            this.Viewtxt.Text = "عرض البيانات";
            this.Viewtxt.UseVisualStyleBackColor = true;
            this.Viewtxt.Click += new System.EventHandler(this.Viewtxt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(727, 349);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 43);
            this.button1.TabIndex = 31;
            this.button1.Text = "بيانات المستخدمين";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(755, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 46);
            this.button2.TabIndex = 32;
            this.button2.Text = "المنتجات المحتكرة";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GovernForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(886, 490);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Search_text);
            this.Controls.Add(this.Viewtxt);
            this.Controls.Add(this.SearchTxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GovernForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SearchTxt;
        private System.Windows.Forms.TextBox Search_text;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Viewtxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}