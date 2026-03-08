namespace Question2
{
    partial class JudgeChinese
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
            label1 = new Label();
            Input_chinese = new TextBox();
            label2 = new Label();
            textBox_result = new TextBox();
            button_check = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 92);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "输入：";
            // 
            // Input_chinese
            // 
            Input_chinese.Location = new Point(112, 112);
            Input_chinese.Name = "Input_chinese";
            Input_chinese.Size = new Size(131, 23);
            Input_chinese.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(112, 138);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 2;
            label2.Text = "判断结果";
            // 
            // textBox_result
            // 
            textBox_result.AccessibleRole = AccessibleRole.None;
            textBox_result.Location = new Point(112, 158);
            textBox_result.Name = "textBox_result";
            textBox_result.Size = new Size(131, 23);
            textBox_result.TabIndex = 3;
            // 
            // button_check
            // 
            button_check.Location = new Point(126, 229);
            button_check.Name = "button_check";
            button_check.Size = new Size(75, 23);
            button_check.TabIndex = 4;
            button_check.Text = "检测";
            button_check.UseVisualStyleBackColor = true;
            button_check.Click += button_check_Click;
            // 
            // JudgeChinese
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 347);
            Controls.Add(button_check);
            Controls.Add(textBox_result);
            Controls.Add(label2);
            Controls.Add(Input_chinese);
            Controls.Add(label1);
            Name = "JudgeChinese";
            Text = "判断汉字";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox Input_chinese;
        private Label label2;
        private TextBox textBox_result;
        private Button button_check;
    }
}
