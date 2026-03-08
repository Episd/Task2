using System;

namespace Question2;

public partial class JudgeChinese : Form {
    public JudgeChinese() {
        InitializeComponent();
    }

    private void button_check_Click(object sender, EventArgs e) {
        if(isChina(Input_chinese.Text)) {
            textBox_result.Text = "输入的全是汉字";
        } else {
            textBox_result.Text = "输入的字符串包含其他字符";
        }
    }

    private bool isChina(string input) {
        foreach (char ch in input) {
            if (Convert.ToInt32(ch) < 128) {
                return false;                           // 任一字符不是中文，返回false
            }
        }

        return true;
    }
}
