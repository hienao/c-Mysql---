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
    public partial class Financeinf : Form
    {
        public Financeinf()
        {
            InitializeComponent();
        }

        private void Finance_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from caiwu ", null).Tables[0].DefaultView;
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string bianhao, leixing, jine, date;
                bianhao = textBox1.Text;
                leixing = comboBox1.SelectedItem.ToString();
                jine = textBox2.Text;
                date = dateTimePicker1.Text;
                if (!IsNum(jine))
                    MessageBox.Show("金额不为数字！请修改");
                else
                {
                    string sqltext = "insert into caiwu values('"+bianhao+"','"+leixing+"','"+jine+"','"+date+"')";
                    MySqlHelper.ExecuteNonQuery(MySqlHelper.Conn, CommandType.Text, sqltext, null);
                    dataGridView1.DataSource = MySqlHelper.GetDataSet(MySqlHelper.Conn, CommandType.Text, "select * from caiwu ", null).Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("该数据记录已存在");
                throw;
            }
        }

    }
}
