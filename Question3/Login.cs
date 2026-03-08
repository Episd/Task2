namespace Question3;


public partial class Login : Form {

    private readonly string UserName = "admin";
    private readonly string Password = "123456";
    private int LoginAttempts = 0;
    private DateTime? lockoutEnd = null;
    private System.Windows.Forms.Timer lockoutTimer;
    private const int LockoutSeconds = 30;

    public Login() {
        InitializeComponent();
        loginInputPage.LoginClicked += Login_Load;
        varifyPage.VarifySuccess += BackToMainPage;
        varifyPage.BackClicked += BackToMainPage;
        // 初始化锁定计时器
        lockoutTimer = new System.Windows.Forms.Timer();
        lockoutTimer.Interval = 1000; // 1s 更新一次
        lockoutTimer.Tick += LockoutTimer_Tick;
    }

    private void Validate(object sender, LoginEventArgs e) {
        if (e.UserName == null) {
            MessageBox.Show("用户名不能为空！");
            return;
        }
        if (e.Password == null) {
            MessageBox.Show("密码不能为空！");
            return;
        }

        if (lockoutEnd.HasValue && lockoutEnd.Value > DateTime.Now) {
            // 如果仍在锁定期间，直接提示剩余时间
            var remaining = (int)Math.Ceiling((lockoutEnd.Value - DateTime.Now).TotalSeconds);
            MessageBox.Show($"当前已被锁定，请等待 {remaining} 秒后重试。");
            return;
        }

        if(e.UserName != UserName) {
            MessageBox.Show("用户名错误！");
            LoginAttempts++;
            if (LoginAttempts >= 3) StartLockout();
            return;
        }

        if(e.Password != Password) {
            MessageBox.Show("密码错误！");
            LoginAttempts++;
            if (LoginAttempts >= 3) StartLockout();
            return;
        }

        // 登录成功，重置尝试次数并继续
        LoginAttempts = 0;
        SwitchPage(sender, e);
    }

    private void StartLockout() {
        lockoutEnd = DateTime.Now.AddSeconds(LockoutSeconds);
        // 禁用输入控件，防止输入
        try { loginInputPage.Enabled = false; } catch { }
        lockoutTimer.Start();
        MessageBox.Show($"登录失败次数过多，已锁定 {LockoutSeconds} 秒。");
    }

    private void LockoutTimer_Tick(object? sender, EventArgs e) {
        if (!lockoutEnd.HasValue) return;
        var remaining = (lockoutEnd.Value - DateTime.Now).TotalSeconds;
        if (remaining <= 0) {
            // 解除锁定
            lockoutTimer.Stop();
            lockoutEnd = null;
            LoginAttempts = 0;
            try { loginInputPage.Enabled = true; } catch { }
            MessageBox.Show("输入已解锁，可以重新尝试登录。");
        }
        // 否则继续等待；点击登录时会提示剩余时间
    }

    private void SwitchPage(object sender, LoginEventArgs e) {
        MessageBox.Show("请进行验证！");
        panel1.Controls.Clear();
        panel1.Controls.Add(varifyPage);
    }

    private void BackToMainPage(object sender, EventArgs e) {
        panel1.Controls.Clear();
        panel1.Controls.Add(loginInputPage);
    }

    private void Login_Load(object sender, LoginEventArgs e) {
        if (lockoutEnd.HasValue && lockoutEnd.Value > DateTime.Now) {
            var remaining = (int)Math.Ceiling((lockoutEnd.Value - DateTime.Now).TotalSeconds);
            MessageBox.Show($"当前已被锁定，请等待 {remaining} 秒后重试。");
            return;
        }

        Validate(sender, e);
    }
}
