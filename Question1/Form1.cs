using System;
using System.Diagnostics;

namespace Question1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName("chrome");
            if (process.Length == 0)
            {
                MessageBox.Show("没有找到名为'chrome'的进程.");
                return;
            }

            foreach (Process instance in process)
            {
                instance.WaitForExit(3000);
                //instance.CloseMainWindow();
                instance.Kill();
            }
            MessageBox.Show("退出chrome成功！");
        }
    }
}
