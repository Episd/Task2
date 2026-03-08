namespace Question5
{
    partial class EightQueen
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
            pictureBox_Board = new PictureBox();
            button_start = new Button();
            button_pause = new Button();
            button_stop = new Button();
            label_status = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Board).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Board
            // 
            pictureBox_Board.Location = new Point(11, 50);
            pictureBox_Board.Name = "pictureBox_Board";
            pictureBox_Board.Size = new Size(724, 724);
            pictureBox_Board.TabIndex = 0;
            pictureBox_Board.TabStop = false;
            // 
            // button_start
            // 
            button_start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_start.Location = new Point(65, 780);
            button_start.Name = "button_start";
            button_start.Size = new Size(75, 23);
            button_start.TabIndex = 1;
            button_start.Text = "开始";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // button_pause
            // 
            button_pause.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_pause.Location = new Point(316, 781);
            button_pause.Name = "button_pause";
            button_pause.Size = new Size(75, 23);
            button_pause.TabIndex = 2;
            button_pause.Text = "暂停";
            button_pause.UseVisualStyleBackColor = true;
            button_pause.Click += button_pause_Click;
            // 
            // button_stop
            // 
            button_stop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_stop.Location = new Point(548, 781);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(75, 23);
            button_stop.TabIndex = 3;
            button_stop.Text = "终止";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // label_status
            // 
            label_status.AutoSize = true;
            label_status.Location = new Point(22, 19);
            label_status.Name = "label_status";
            label_status.Size = new Size(80, 17);
            label_status.TabIndex = 4;
            label_status.Text = "状态：未开始";
            // 
            // EightQueen
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 810);
            Controls.Add(label_status);
            Controls.Add(button_stop);
            Controls.Add(button_pause);
            Controls.Add(button_start);
            Controls.Add(pictureBox_Board);
            Name = "EightQueen";
            Text = "八皇后";
            ((System.ComponentModel.ISupportInitialize)pictureBox_Board).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_Board;
        private Button button_start;
        private Button button_pause;
        private Button button_stop;
        private Label label_status;
    }
}
