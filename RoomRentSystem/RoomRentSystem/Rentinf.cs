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
    public partial class Rentinf : Form
    {
        public Rentinf()
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
        private void Rentinf_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                string sqltext2 = "select sfzid from userinf ";
                string sqltext1 = "select num from roominf ";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox1.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext2, null);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                rentdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roomrent ", null).Tables[0].DefaultView;
                rentdataGridView.Columns["roomnum"].HeaderText = "房屋编号";
                rentdataGridView.Columns["sfznum"].HeaderText = "身份证号";
                rentdataGridView.Columns["starttime"].HeaderText = "开始租赁时间";
                rentdataGridView.Columns["monthnum"].HeaderText = "月份数";
                rentdataGridView.Columns["monthlyrent"].HeaderText = "月租金";
            }
            catch (Exception)
            {
                MessageBox.Show("数据初始化错误！");
                throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string roomnum, sfznum, date, monthnum, monthlyrent, sqltext;
                roomnum = comboBox1.SelectedItem.ToString();
                sfznum = comboBox2.SelectedItem.ToString();
                date = dateTimePicker1.Text;
                monthnum = textBox1.Text;
                monthlyrent = textBox2.Text;
                if (!IsNum(monthnum) || !IsNum(monthlyrent))
                {
                    MessageBox.Show("月份数或租金值不为数字，请修正！");
                }
                else
                {
                    sqltext = "insert into roomrent values('" + roomnum + "','" + sfznum + "','" + date + "','" + monthnum + "','" + monthlyrent + "')";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    rentdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roomrent ", null).Tables[0].DefaultView;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据重复，请检查！");
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string roomnum, sfznum, sqltext;
                roomnum = comboBox1.SelectedItem.ToString();
                sfznum = comboBox2.SelectedItem.ToString();
                sqltext = "delete from roomrent where roomnum='" + roomnum + "' and sfznum='" + sfznum + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                rentdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roomrent ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("要求删除的数据不存在，请检查！");
                throw;
            }
        }
    }
}
