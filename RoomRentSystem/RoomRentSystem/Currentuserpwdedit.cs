using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoomRentSystem
{
    public partial class Currentuserpwdedit : Form
    {
        static string currentusernamestr;
        public Currentuserpwdedit(string currentusername)
        {
            currentusernamestr = currentusername;
            InitializeComponent();
        }

        private void Currentuserpwdedit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string oldpwd, newpwd, sqltext, sqltext1;
                DataSet ds = new DataSet();
                oldpwd = textBox1.Text;
                newpwd = textBox2.Text;
                int flag;//判断update命令是否执行成功
                sqltext = "select password from manageruser where user='" + currentusernamestr + "'";
                sqltext1 = "update manageruser set password='" + newpwd + "' where user='" + currentusernamestr + "'";
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                if (ds.Tables[0].Rows[0]["password"].ToString().Equals(oldpwd))
                {
                    flag = MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                    if (flag == 1)
                        MessageBox.Show("修改成功！");
                    else
                        MessageBox.Show("修改失败！");
                }
                else
                    MessageBox.Show("原密码输入不正确！");
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
