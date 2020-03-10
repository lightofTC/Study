using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTest
{
    public partial class ModificationForm : Form
    {
        private int selected;
        public Form1 form1;
        public ModificationForm()
        {
            InitializeComponent();
        }

        public ModificationForm(MySqlData data)
        {
            InitializeComponent();
            textBox4.Text = data.Area;
            textBox5.Text = data.Name;
            textBox6.Text = data.Price.ToString();
            this.selected = data.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlData data = new MySqlData();
                data.Area = textBox1.Text;
                data.Name = textBox2.Text;
                data.Price = int.Parse(textBox3.Text);
                data.Id = this.selected;
                new MySqlDA().updateData(data);
            }
            catch
            {
                MessageBox.Show("Price必须为数字！请重新输入！");
            }

            
        }

        private void ModificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.refreshListView();
        }
    }
}
