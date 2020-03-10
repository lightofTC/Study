using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTest
{
    public partial class AddDataForm : Form
    {
        public Form1 form1;
        public AddDataForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    MySqlData udata = new MySqlData();
                    udata.Area = textBox1.Text;
                    udata.Name = textBox2.Text;
                    udata.Price = int.Parse(textBox3.Text);

                    new MySqlDA().addData(udata);
                }
                catch
                {
                    MessageBox.Show("Price必须为数字！请重新输入！");
                }
            }
            else
            {
                MessageBox.Show("输入不能为空！");
            }                 
        }
        private bool IsNumber(string text)
        {
            return Regex.IsMatch(text, @"^[+-]?/d*[.]?/d*$");
        }

        private void AddDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.refreshListView();
        }
    }
}
