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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            bindData(new MySqlDA().queryData());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddDataForm insert = new AddDataForm();
            insert.form1 = this;
            insert.Owner = this;
            insert.Show();
        }
     

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string area = comboBox1.Text;
            bindData(new MySqlDA().queryData(area));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlData data = new MySqlData();
            if (listView1.SelectedItems.Count > 0)
            {
                //获得选中的数据
                data.Id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                data.Area = listView1.SelectedItems[0].SubItems[1].Text;
                data.Name = listView1.SelectedItems[0].SubItems[2].Text;
                data.Price = float.Parse(listView1.SelectedItems[0].SubItems[3].Text);

                ModificationForm modification = new ModificationForm(data);
                modification.form1 = this;
                modification.Owner = this;
                modification.Show();
            }
            else
            {
                MessageBox.Show("请先在表格中选择需要更改的数据！");
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlData data = new MySqlData();

            if (listView1.SelectedItems.Count > 0)
            {

                if (MessageBox.Show(
                    "请再次确定您是否要删除该数据！", "提示", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    data.Id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    new MySqlDA().deleteData(data.Id);
                    refreshListView();
                }
            }
            else
            {
                MessageBox.Show("请在表格中选择要删除的数据！");
            }


        }

        private void bindData(List<MySqlData> list)
        {
            //构建一个listviewitem对象,通过它把数据放入listview中
            foreach (MySqlData data in list)
            {
                ListViewItem it = new ListViewItem();
                it.Text = data.Id.ToString();
                it.SubItems.Add(data.Area);
                it.SubItems.Add(data.Name);
                it.SubItems.Add(data.Price.ToString());
                listView1.Items.Add(it);
            }

        }
        public void refreshListView()
        {
            listView1.Items.Clear();
            bindData(new MySqlDA().queryData());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
