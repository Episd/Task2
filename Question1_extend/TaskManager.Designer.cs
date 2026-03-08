namespace Question1_extend
{
    partial class TaskManager
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
            listView_processes = new ListView();
            columnHeaderPid = new ColumnHeader();
            columnHeaderName = new ColumnHeader();
            columnHeaderMemory = new ColumnHeader();
            button_refresh = new Button();
            button_kill = new Button();
            SuspendLayout();
            // 
            // listView_processes
            // 
            listView_processes.Columns.AddRange(new ColumnHeader[] { columnHeaderPid, columnHeaderName, columnHeaderMemory });
            listView_processes.FullRowSelect = true;
            listView_processes.Location = new Point(12, 12);
            listView_processes.Name = "listView_processes";
            listView_processes.Size = new Size(776, 340);
            listView_processes.TabIndex = 0;
            listView_processes.UseCompatibleStateImageBehavior = false;
            listView_processes.View = View.Details;
            // 
            // columnHeaderPid
            // 
            columnHeaderPid.Text = "PID";
            columnHeaderPid.Width = 80;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 480;
            // 
            // columnHeaderMemory
            // 
            columnHeaderMemory.Text = "Memory (MB)";
            columnHeaderMemory.Width = 160;
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(130, 367);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(100, 23);
            button_refresh.TabIndex = 2;
            button_refresh.Text = "刷新";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // button_kill
            // 
            button_kill.Location = new Point(24, 367);
            button_kill.Name = "button_kill";
            button_kill.Size = new Size(75, 23);
            button_kill.TabIndex = 3;
            button_kill.Text = "终止进程";
            button_kill.UseVisualStyleBackColor = true;
            button_kill.Click += button_kill_Click;
            // 
            // TaskManager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_kill);
            Controls.Add(button_refresh);
            Controls.Add(listView_processes);
            Name = "TaskManager";
            Text = "TaskManager";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView_processes;
        private ColumnHeader columnHeaderPid;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderMemory;
        private Button button_refresh;
        private Button button_kill;
    }
}
