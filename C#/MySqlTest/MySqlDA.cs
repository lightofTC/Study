using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTest
{
    class MySqlDA
    {
        MySqlConnection con;
        MySqlCommand cmd;

        //增
        public void addData(MySqlData data)
        {
            string text = "insert into nanning_city" +
                "(area_name,name,price) values('" +
                data.Area + "','" + data.Name+"','"+data.Price+"');";

            string text1 = "select count(*) from nanning_city where area_name = '"
                    + data.Area + "' and name='" + data.Name + "' and price="
                    + data.Price + ";";

            if (this.OpenConection() == true)
            {
                //查询插入数据是否已经存在
                this.cmd= new MySqlCommand(text1, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("数据已存在！");
                }
                else
                {
                    this.cmd = new MySqlCommand(text, con);
                    this.cmd.ExecuteNonQuery();
                    this.CloseConnection();
                    MessageBox.Show("数据添加成功！");
                }
            }
        }

        //查
        public List<MySqlData> queryData()
        {
            List<MySqlData> list = new List<MySqlData>();
            string text = "select * from nanning_city;";        
            
            if (this.OpenConection() == true)
            {
                this.cmd = new MySqlCommand(text, con);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                //将数据转换为自己的类型存入list集合中
                while (mySqlDataReader.Read())
                {
                    MySqlData data = new MySqlData();
                    data.Id = int.Parse(mySqlDataReader["id"].ToString());
                    data.Area = mySqlDataReader["area_name"].ToString();
                    data.Name = mySqlDataReader["name"].ToString();
                    data.Price = float.Parse(mySqlDataReader["price"].ToString());
                    list.Add(data);                 
                }              
            }
            this.CloseConnection();
            return list;
        }
        
        //查
        public List<MySqlData> queryData(string area)
        {
            List<MySqlData> list = new List<MySqlData>();
            string text = "select * from nanning_city where area_name like '%"+area+"%';";
            if (this.OpenConection() == true)
            {
                this.cmd = new MySqlCommand(text, con);
                MySqlDataReader mySqlDataReader = cmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    MySqlData data = new MySqlData();
                    data.Id= int.Parse(mySqlDataReader["id"].ToString());
                    data.Area = mySqlDataReader["area_name"].ToString();
                    data.Name = mySqlDataReader["name"].ToString();
                    data.Price = float.Parse(mySqlDataReader["price"].ToString());
                    list.Add(data);
                }
            }
            this.CloseConnection();
            return list;
        }
        
        //改
        public void updateData(MySqlData data)
        {
            if (this.OpenConection() == true)
            {

                string text = "update nanning_city set area_name='"
                    + data.Area + "',name='" + data.Name + "',price="
                    + data.Price +" where id="+data.Id+";";

                string text1 = "select count(*) from nanning_city where area_name = '"
                   + data.Area + "' and name='" + data.Name + "' and price="
                   + data.Price + ";";

                if (this.OpenConection())
                {
                    this.cmd = new MySqlCommand(text1, con);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("数据已存在！");
                    }
                    else
                    {
                        cmd = new MySqlCommand(text, con);
                        cmd.ExecuteNonQuery();
                        this.CloseConnection();
                        MessageBox.Show("修改成功！");
                    }
                }        
            }
            this.CloseConnection();
        }

        //删
       public void deleteData(int id)
        {
            string text = "delete from nanning_city where id=" 
                    + id + ";";
            if (this.OpenConection())
            {
                cmd = new MySqlCommand(text, con);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        private bool OpenConection()
        {
            try
            {
                string address = "server=localhost;database=test;user=root;pwd=123456";
                this.con = new MySqlConnection(address);
                this.con.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("无法连接服务器！");
                        break;
                    case 1045:
                        MessageBox.Show("无效的用户名或密码！");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

    }
}
