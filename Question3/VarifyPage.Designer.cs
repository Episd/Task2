namespace Question3;

partial class VarifyPage {
    /// <summary> 
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
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
        pictureBox1 = new PictureBox();
        button_back = new Button();
        trackBar1 = new TrackBar();
        flowLayoutPanel1 = new FlowLayoutPanel();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
        flowLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        pictureBox1.Location = new Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(300, 200);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // button_back
        // 
        button_back.AutoSize = true;
        button_back.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        button_back.Dock = DockStyle.Bottom;
        button_back.Location = new Point(3, 260);
        button_back.Name = "button_back";
        button_back.Size = new Size(300, 27);
        button_back.TabIndex = 1;
        button_back.Text = "返回";
        button_back.UseVisualStyleBackColor = true;
        button_back.Click += button_back_Click;
        // 
        // trackBar1
        // 
        trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
        trackBar1.Location = new Point(3, 209);
        trackBar1.Name = "trackBar1";
        trackBar1.Size = new Size(300, 45);
        trackBar1.TabIndex = 2;
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowLayoutPanel1.Controls.Add(pictureBox1);
        flowLayoutPanel1.Controls.Add(trackBar1);
        flowLayoutPanel1.Controls.Add(button_back);
        flowLayoutPanel1.Dock = DockStyle.Fill;
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new Size(306, 290);
        flowLayoutPanel1.TabIndex = 3;
        // 
        // VarifyPage
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Controls.Add(flowLayoutPanel1);
        Name = "VarifyPage";
        Size = new Size(306, 290);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private PictureBox pictureBox1;
    private Button button_back;
    private TrackBar trackBar1;
    private FlowLayoutPanel flowLayoutPanel1;
}
