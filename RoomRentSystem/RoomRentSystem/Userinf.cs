using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace RoomRentSystem
{
    public partial class Userinf : Form
    {
        public Userinf()
        {
            InitializeComponent();
        }
        public bool IsNum(String strNumber) 
        { 
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*"); 
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*"); 
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$"; 
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")"); 
            return !objNotNumberPattern.IsMatch(strNumber) && !objTwoDotPattern.IsMatch(strNumber) && !objTwoMinusPattern.IsMatch(strNumber) && objNumberPattern.IsMatch(strNumber); 
        }
        private void Roominf_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedIndex = 0;
                comboBoxsex.SelectedIndex = 0;
                string sqltext1 = "select * from userinf ";
                userdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
                userdataGridView.Columns["sfzid"].HeaderText = "身份证号";
                userdataGridView.Columns["username"].HeaderText = "姓名";
                userdataGridView.Columns["xingbie"].HeaderText = "性别";
                userdataGridView.Columns["dianhua"].HeaderText = "电话";
            }
            catch (Exception)
            {
                MessageBox.Show("数据初始化错误！");
                throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chaxunfangshi= "num",sqltext1;
            if (comboBox1.SelectedItem.ToString().Equals("身份证号"))
                chaxunfangshi = "sfzid";
            else if (comboBox1.SelectedItem.ToString().Equals("姓名"))
                chaxunfangshi = "username";
            else if (comboBox1.SelectedItem.ToString().Equals("电话"))
                chaxunfangshi = "dianhua";
            try
            {
                sqltext1 = "select * from userinf where " + chaxunfangshi + " like '%" + textBox1.Text + "%'";
                userdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                string sfzid, username, xingbie, dianhua;
                string sqltext;
                sfzid = textBoxsfzid.Text;
                username = textBoxname.Text;
                xingbie = comboBoxsex.SelectedItem.ToString();
                dianhua = textBoxdianhua.Text;
                if ((!IsNum(sfzid)) || (!IsNum(dianhua)))
                {
                    MessageBox.Show("身份证号或电话号码不是数字！");
                }
                else
                {
                    sqltext = "insert into userinf(sfzid,username,xingbie,dianhua)values('" + sfzid + "','" + username + "','" + xingbie + "','" + dianhua + "')";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    userdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from userinf ", null).Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("该用户已存在！");
                throw;
            }
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sfzid, sqltext;
                sfzid = textBox18.Text;
                sqltext = "delete from userinf where sfzid='" + sfzid + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                userdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from userinf ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("要删除的用户不存在！");
                throw;
            }
            
        }
        private void buttonupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string sfzid, username, xingbie, dianhua;
                string sqltext;
                sfzid = textBox4.Text;
                username = textBox3.Text;
                xingbie = comboBox2.SelectedItem.ToString();
                dianhua = textBox2.Text;
                if ((!IsNum(sfzid)) || (!IsNum(dianhua)))
                {
                    MessageBox.Show("面积或价格不是数字");
                }
                else
                {
                    sqltext = "update userinf set username='" + username + "',xingbie='" + xingbie + "',dianhua='" + dianhua + "' where sfzid='" + sfzid + "'";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    userdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from userinf ", null).Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("身份证号输入错误！");
                throw;
            }
            
        }

        private void buttonjiazai_Click(object sender, EventArgs e)
        {
            try
            {
                string sfzid = textBox4.Text;
                string sqltext;
                sqltext = "select * from userinf where sfzid='" + sfzid + "'";
                DataSet ds = new DataSet();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                textBox4.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                comboBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox2.Text = ds.Tables[0].Rows[0][3].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("身份证号输入错误！");
                throw;
            }
            
        }
    }
}
