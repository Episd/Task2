namespace Question3
{
    partial class LoginInput
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            label_name = new Label();
            label_password = new Label();
            textBox_name = new TextBox();
            textBox_password = new TextBox();
            button_login = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_name
            // 
            label_name.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label_name.AutoSize = true;
            label_name.Location = new Point(88, 0);
            label_name.Name = "label_name";
            label_name.Size = new Size(44, 17);
            label_name.TabIndex = 0;
            label_name.Text = "用户名";
            // 
            // label_password
            // 
            label_password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label_password.AutoSize = true;
            label_password.Location = new Point(94, 46);
            label_password.Name = "label_password";
            label_password.Size = new Size(32, 17);
            label_password.TabIndex = 1;
            label_password.Text = "密码";
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(3, 20);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(215, 23);
            textBox_name.TabIndex = 2;
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(3, 66);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(215, 23);
            textBox_password.TabIndex = 3;
            // 
            // button_login
            // 
            button_login.Dock = DockStyle.Fill;
            button_login.Location = new Point(3, 95);
            button_login.Name = "button_login";
            button_login.Size = new Size(215, 30);
            button_login.TabIndex = 4;
            button_login.Text = "登录";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(label_name);
            flowLayoutPanel1.Controls.Add(textBox_name);
            flowLayoutPanel1.Controls.Add(label_password);
            flowLayoutPanel1.Controls.Add(textBox_password);
            flowLayoutPanel1.Controls.Add(button_login);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(221, 128);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // LoginInput
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(flowLayoutPanel1);
            Name = "LoginInput";
            Size = new Size(221, 128);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_name;
        private Label label_password;
        private TextBox textBox_name;
        private TextBox textBox_password;
        private Button button_login;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
