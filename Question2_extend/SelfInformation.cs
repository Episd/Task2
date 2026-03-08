using System;
using System.Text.RegularExpressions;

namespace Question2_extend;

public partial class SelfInformation : Form {
    // 定义四种个人信息的输入格式
    private static readonly Regex NameRegex = new(@"^[\u4e00-\u9fa5]+$");
    private static readonly Regex IdRegex = new(@"^23600\d{4}$");
    private static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    private static readonly Regex LocationRegex = new(@"^[^省]+省[^市]+市$");
    public SelfInformation() {
        InitializeComponent();
    }

    // 验证输入是否符合格式
    private void button_check_Click(object sender, EventArgs e) {
        string name = textBox_name.Text;
        string id = textBox_id.Text;
        string email = textBox_email.Text;
        string location = textBox_location.Text;

        string? error = ValidateInput(name, id, email, location);

        if (error != null) {
            MessageBox.Show(error);
            return;
        }

        MessageBox.Show("信息格式无误！");
    }

    private string? ValidateInput(string name, string id, string email, string location) {
        if (!CheckName(name))
            return "姓名必须为中文！";

        if (!CheckId(id))
            return "学号格式不正确，必须为23600开头加四位数字！";

        if (!CheckEmail(email))
            return "邮箱格式不正确！";

        if (!CheckLocation(location))
            return "地址格式不正确，必须为xx省xx市！";

        return null;
    }

    // 正则表达式判断姓名是否为中文
    private bool CheckName(string name) {
        return NameRegex.IsMatch(name);
    }

    // 使用正则表达式判断学号格式（23600+四位数字）
    private bool CheckId(string id) {
        return IdRegex.IsMatch(id);
    }

    // 使用正则表达式判断邮箱格式（xx@xx.com）
    private bool CheckEmail(string email) {
        return EmailRegex.IsMatch(email);
    }

    // 使用正则表达式判断地址格式（xx省xx市）
    private bool CheckLocation(string location) {
        return LocationRegex.IsMatch(location);
    }
}
