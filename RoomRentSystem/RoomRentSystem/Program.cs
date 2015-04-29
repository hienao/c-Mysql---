using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
//Mysql 连接查询http://www.cnblogs.com/youuuu/archive/2011/06/16/2082730.html
namespace RoomRentSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new MainForm());
        }
    }
}
