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
    public partial class Billsinf : Form
    {
        static double shuiprice, dianprice;
        public Billsinf()
        {
            InitializeComponent();
        }

        private void Billsinf_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //获取水电费用单价
            try
            {
                string sqltext;
                sqltext = "select * from othersetting where bianhao='1'";
                DataSet ds = new DataSet();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                shuiprice = double.Parse(ds.Tables[0].Rows[0][1].ToString());
                dianprice = double.Parse(ds.Tables[0].Rows[0][2].ToString());
            }
            catch (Exception)
            {

                throw;
            }
            //初始化datagridview
            try
            {
                string sqltext1 = "select * from billsinf ";
                billsdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
                billsdataGridView.Columns["danhao"].HeaderText = "单号";
                billsdataGridView.Columns["roomnum"].HeaderText = "房屋编号";
                billsdataGridView.Columns["predianbiao"].HeaderText = "上次电表数";
                billsdataGridView.Columns["dianbiao"].HeaderText = "本次电表数";
                billsdataGridView.Columns["preshuibiao"].HeaderText = "上次水表数";
                billsdataGridView.Columns["shuibiao"].HeaderText = "本次水表数";
                billsdataGridView.Columns["jine"].HeaderText = "交费金额";
            }
            catch (Exception)
            {

                throw;
            }
            //获取添加选项卡中的combobox数据并将索引置0
            try
            {
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                string sqltext1 = "select num from roominf ";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox2.Items.Add(dt.Rows[i][0].ToString());
                        comboBox3.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
            catch (Exception)
            {

                throw;
            }
            //修改选项卡中加载数据的加载按钮点击后单号combobox初始化
            try
            {
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                string sqltext1 = "select * from billsinf";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox4.Items.Add(dt.Rows[i][0].ToString());
                        comboBox5.Items.Add(dt.Rows[i][0].ToString());
                    }
                }
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
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
                string danhao, roomnum, predianbiao, dianbiao, preshuibiao, shuibiao, jine, sqltext;
                danhao = textBox2.Text;
                roomnum = comboBox2.SelectedItem.ToString();
                predianbiao = textBox3.Text;
                dianbiao = textBox4.Text;
                preshuibiao = textBox5.Text;
                shuibiao = textBox6.Text;
                jine = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice).ToString();
                sqltext = "insert into billsinf values('" + danhao + "','" + roomnum + "','" + predianbiao + "','" + dianbiao + "','" + preshuibiao + "','" + shuibiao + "','" + jine + "')";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                billsdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from billsinf ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("此订单已存在！");
                throw;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string danhao, sqltext;
                danhao = comboBox4.SelectedItem.ToString();
                sqltext = "select * from billsinf where danhao='" + danhao + "'";
                DataSet ds = new DataSet();
                ds = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                comboBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox10.Text = ds.Tables[0].Rows[0][2].ToString();
                textBox9.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox8.Text = ds.Tables[0].Rows[0][4].ToString();
                textBox7.Text = ds.Tables[0].Rows[0][5].ToString();
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
                string danhao, roomnum, predianbiao, dianbiao, preshuibiao, shuibiao, jine, sqltext;
                danhao = comboBox4.SelectedItem.ToString();
                roomnum = comboBox3.SelectedItem.ToString();
                predianbiao = textBox10.Text;
                dianbiao = textBox9.Text;
                preshuibiao = textBox8.Text;
                shuibiao = textBox7.Text;
                jine = ((double.Parse(dianbiao) - double.Parse(predianbiao)) * dianprice + (double.Parse(shuibiao) - double.Parse(preshuibiao)) * shuiprice).ToString();
                sqltext = "update billsinf set roomnum='" + roomnum + "',predianbiao='" + predianbiao + "',dianbiao='" + dianbiao + "',preshuibiao='" + preshuibiao + "',shuibiao='" + shuibiao + "',jine='" + jine + "' where danhao='" + danhao + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                billsdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from billsinf ", null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string danhao, sqltext;
                danhao = comboBox5.SelectedItem.ToString();
                sqltext = "delete from billsinf where danhao='" + danhao + "'";
                MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                billsdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from billsinf ", null).Tables[0].DefaultView;
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
                string chaxunfangshi = "danhao", sqltext1;
                if (comboBox1.SelectedItem.ToString().Equals("单号"))
                    chaxunfangshi = "danhao";
                else if (comboBox1.SelectedItem.ToString().Equals("房屋编号"))
                    chaxunfangshi = "roomnum";
                sqltext1 = "select * from billsinf where " + chaxunfangshi + " like '%" + textBox1.Text + "%'";
                billsdataGridView.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, sqltext1, null).Tables[0].DefaultView;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
    }
}
