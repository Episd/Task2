using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Question3;

public partial class LoginInput : UserControl {

    public event EventHandler<LoginEventArgs> LoginClicked;
    public LoginInput() {
        InitializeComponent();
    }

    private void button_login_Click(object sender, EventArgs e) {
        var args = new LoginEventArgs(
            textBox_name.Text,
            textBox_password.Text
        );
        LoginClicked?.Invoke(this, args);
    }
}
