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
    public partial class Roominf : Form
    {
        
        public Roominf()
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
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                comboBox6.SelectedIndex = 0;
                comboBox7.SelectedIndex = 0;
                string sqltext1 = "select * from roominf ";
                roomdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
                roomdataGridView.Columns["num"].HeaderText = "房屋编号";
                roomdataGridView.Columns["weizhi"].HeaderText = "房屋区域";
                roomdataGridView.Columns["mingzi"].HeaderText = "房屋名称";
                roomdataGridView.Columns["zhonglei"].HeaderText = "房屋类型";
                roomdataGridView.Columns["mianji"].HeaderText = "房屋面积";
                roomdataGridView.Columns["zhuangxiu"].HeaderText = "装修状况";
                roomdataGridView.Columns["sheshi"].HeaderText = "屋内设施";
                roomdataGridView.Columns["yongtu"].HeaderText = "房屋用途";
                roomdataGridView.Columns["jiage"].HeaderText = "价格";
                roomdataGridView.Columns["zhuangtai"].HeaderText = "租赁状态";
                roomdataGridView.Columns["beizhu"].HeaderText = "备注";
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string chaxunfangshi = "num", sqltext1; ;
                if (comboBox1.SelectedItem.ToString().Equals("房屋编号"))
                    chaxunfangshi = "num";
                else if (comboBox1.SelectedItem.ToString().Equals("房屋区域"))
                    chaxunfangshi = "weizhi";
                else if (comboBox1.SelectedItem.ToString().Equals("房屋名称"))
                    chaxunfangshi = "mingzi";
                else if (comboBox1.SelectedItem.ToString().Equals("房屋状态"))
                    chaxunfangshi = "zhuangtai";
                sqltext1 = "select * from roominf where " + chaxunfangshi + " like '%" + textBox1.Text + "%'";
                roomdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
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
                string num, mianji, mingzi, weizhi, leixing, zhuangxiu, sheshi, yongtu, jiage, zhuangtai, beizhu;
                string sqltext;
                num = textBox2.Text;
                weizhi = textBox3.Text;
                mingzi = textBox4.Text;
                leixing = textBox5.Text;
                mianji = textBox6.Text;
                zhuangxiu = comboBox2.SelectedItem.ToString();
                sheshi = textBox7.Text;
                yongtu = comboBox3.SelectedItem.ToString();
                jiage = textBox8.Text;
                zhuangtai = comboBox4.SelectedItem.ToString();
                beizhu = textBox9.Text;
                if ((!IsNum(mianji)) || (!IsNum(jiage)))
                {
                    MessageBox.Show("面积或价格不是数字");
                }
                else
                {
                    sqltext = "insert into roominf(num,weizhi,mingzi,zhonglei,mianji,zhuangxiu,sheshi,yongtu,jiage,zhuangtai,beizhu)values('" + num + "','" + weizhi + "','" + mingzi + "','" + leixing + "','" + mianji + "','" + zhuangxiu + "','" + sheshi + "','" + yongtu + "','" + jiage + "','" + zhuangtai + "','" + beizhu + "')";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    roomdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roominf ", null).Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string num;
                string sqltext;
                num = textBox17.Text;
                sqltext = "select * from roominf where num='" + num + "'";
                DataSet ds = new DataSet();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                textBox16.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox15.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox14.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox13.Text = ds.Tables[0].Rows[0][4].ToString();
                comboBox7.Text = ds.Tables[0].Rows[0][5].ToString();
                textBox12.Text = ds.Tables[0].Rows[0][6].ToString();
                comboBox6.Text = ds.Tables[0].Rows[0][7].ToString();
                textBox11.Text = ds.Tables[0].Rows[0][8].ToString();
                comboBox5.Text = ds.Tables[0].Rows[0][9].ToString();
                textBox10.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string num, mianji, mingzi, weizhi, leixing, zhuangxiu, sheshi, yongtu, jiage, zhuangtai, beizhu;
                string sqltext;
                num = textBox17.Text;
                weizhi = textBox16.Text;
                mingzi = textBox15.Text;
                leixing = textBox14.Text;
                mianji = textBox13.Text;
                zhuangxiu = comboBox7.SelectedItem.ToString();
                sheshi = textBox12.Text;
                yongtu = comboBox6.SelectedItem.ToString();
                jiage = textBox11.Text;
                zhuangtai = comboBox5.SelectedItem.ToString();
                beizhu = textBox10.Text;
                if ((!IsNum(mianji)) || (!IsNum(jiage)))
                {
                    MessageBox.Show("面积或价格不是数字");
                }
                else
                {
                    sqltext = "update roominf set weizhi='" + weizhi + "',mingzi='" + mingzi + "',zhonglei='" + leixing + "',mianji='" + mianji + "',zhuangxiu='" + zhuangxiu + "',sheshi='" + sheshi + "',yongtu='" + yongtu + "',jiage='" + jiage + "',zhuangtai='" + zhuangtai + "',beizhu='" + beizhu + "' where num='" + num + "'";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    roomdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roominf ", null).Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string num, sqltext;
                num = textBox18.Text;
                sqltext = "delete from roominf where num='" + num + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                roomdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from roominf ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
