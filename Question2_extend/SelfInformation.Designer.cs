namespace Question2_extend
{
    partial class SelfInformation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label_name = new Label();
            label_id = new Label();
            label_email = new Label();
            textBox_name = new TextBox();
            label_location = new Label();
            textBox_id = new TextBox();
            textBox_email = new TextBox();
            textBox_location = new TextBox();
            button_check = new Button();
            SuspendLayout();
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(87, 96);
            label_name.Name = "label_name";
            label_name.Size = new Size(116, 17);
            label_name.TabIndex = 0;
            label_name.Text = "请输入姓名（中文）";
            // 
            // label_id
            // 
            label_id.AutoSize = true;
            label_id.Location = new Point(87, 142);
            label_id.Name = "label_id";
            label_id.Size = new Size(68, 17);
            label_id.TabIndex = 1;
            label_id.Text = "请输入学号";
            // 
            // label_email
            // 
            label_email.AutoSize = true;
            label_email.Location = new Point(87, 188);
            label_email.Name = "label_email";
            label_email.Size = new Size(68, 17);
            label_email.TabIndex = 2;
            label_email.Text = "请输入邮箱";
            // 
            // textBox_name
            // 
            textBox_name.Location = new Point(91, 116);
            textBox_name.Name = "textBox_name";
            textBox_name.Size = new Size(100, 23);
            textBox_name.TabIndex = 3;
            // 
            // label_location
            // 
            label_location.AutoSize = true;
            label_location.Location = new Point(87, 234);
            label_location.Name = "label_location";
            label_location.Size = new Size(172, 17);
            label_location.TabIndex = 4;
            label_location.Text = "请输入家庭住址（XX省XX市）";
            // 
            // textBox_id
            // 
            textBox_id.Location = new Point(87, 162);
            textBox_id.Name = "textBox_id";
            textBox_id.Size = new Size(100, 23);
            textBox_id.TabIndex = 5;
            // 
            // textBox_email
            // 
            textBox_email.Location = new Point(87, 208);
            textBox_email.Name = "textBox_email";
            textBox_email.Size = new Size(100, 23);
            textBox_email.TabIndex = 6;
            // 
            // textBox_location
            // 
            textBox_location.Location = new Point(87, 254);
            textBox_location.Name = "textBox_location";
            textBox_location.Size = new Size(100, 23);
            textBox_location.TabIndex = 7;
            // 
            // button_check
            // 
            button_check.Location = new Point(101, 283);
            button_check.Name = "button_check";
            button_check.Size = new Size(75, 23);
            button_check.TabIndex = 8;
            button_check.Text = "验证格式";
            button_check.UseVisualStyleBackColor = true;
            button_check.Click += button_check_Click;
            // 
            // SelfInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 450);
            Controls.Add(button_check);
            Controls.Add(textBox_location);
            Controls.Add(textBox_email);
            Controls.Add(textBox_id);
            Controls.Add(label_location);
            Controls.Add(textBox_name);
            Controls.Add(label_email);
            Controls.Add(label_id);
            Controls.Add(label_name);
            Name = "SelfInformation";
            Text = "个人信息验证";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_name;
        private Label label_id;
        private Label label_email;
        private TextBox textBox_name;
        private Label label_location;
        private TextBox textBox_id;
        private TextBox textBox_email;
        private TextBox textBox_location;
        private Button button_check;
    }
}
