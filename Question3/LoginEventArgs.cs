using System;
using System.Collections.Generic;
using System.Text;

namespace Question3;

public class LoginEventArgs : EventArgs {
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public LoginEventArgs(string? userName, string? password) {
        UserName = userName;
        Password = password;
    }
}
