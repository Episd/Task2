using System;
using System.Diagnostics;
using System.Linq;

namespace Question1_extend {
    public partial class TaskManager : Form {
        public TaskManager() {
            InitializeComponent();
            RefreshProcessList();
        }

        private void RefreshProcessList() {
            listView_processes.Items.Clear();                           // 清空进程列表

            var processes = Process.GetProcesses().OrderBy(
                p => p.ProcessName, StringComparer.OrdinalIgnoreCase
            );                                                          // 获取进程列表，默认按照进程名称排序

            foreach (var p in processes) {
                string mem = "N/A";
                try {
                    mem = (p.WorkingSet64 / 1024 / 1024).ToString();
                }
                catch { }

                var item = new ListViewItem(new[] {
                    p.Id.ToString(), p.ProcessName, mem
                });
                item.Tag = p.Id;
                listView_processes.Items.Add(item);
            }
        }

        private void button_refresh_Click(object sender, EventArgs e) {
            RefreshProcessList();
        }

        private void button_kill_Click(object sender, EventArgs e) {
            if (listView_processes.SelectedItems.Count == 0) {
                MessageBox.Show("请选择要终止的进程。");
                return;
            }

            foreach (ListViewItem item in listView_processes.SelectedItems) {
                if (item.Tag is int pid) {
                    try {
                        var proc = Process.GetProcessById(pid);
                        // try graceful close first
                        try {
                            if (!proc.CloseMainWindow()) {
                                proc.Kill();
                            }
                            else {
                                proc.WaitForExit(2000);
                                if (!proc.HasExited)
                                    proc.Kill();
                            }
                            MessageBox.Show($"成功终止进程 {item.SubItems[1].Text} (PID: {pid})");
                        }
                        catch {
                            // fallback
                            proc.Kill();
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"无法终止进程 {item.SubItems[1].Text}: {ex.Message}");
                    }
                }
            }

            RefreshProcessList();
        }
    }
}
