namespace Question5;

public partial class EightQueen : Form {
    private bool isRunning = false;
    private bool isPaused = false;
    private bool isStopped = false;

    int[] queens = new int[8];              // queens[row] = col，-1表示该行没有皇后

    private Bitmap boardBitmap;

    private const int cellSize = 84;                // 棋盘格子的大小

    public EightQueen() {
        InitializeComponent();
        for (int i = 0; i < 8; i++)
            queens[i] = -1;

        // 读取棋盘资源
        boardBitmap = new Bitmap(Properties.Resources.Board);

        DrawBoard();
        // 更新状态标签初始文本
        UpdateStatus();
    }

    // 更新状态显示
    private void UpdateStatus()
    {
        if (label_status == null) return;

        if (isStopped)
            label_status.Text = "状态：已停止";
        else if (isRunning)
            label_status.Text = isPaused ? "状态：暂停中" : "状态：运行中";
        else
            label_status.Text = "状态：未开始";
    }

    // 在等待可视化延迟时，支持立即响应暂停/停止
    private async Task WaitOrPauseAsync(int milliseconds)
    {
        int waited = 0;
        const int interval = 50; // 50ms 小间隔，用于快速响应暂停

        while (waited < milliseconds)
        {
            if (isStopped || !isRunning)
                return;

            if (isPaused)
            {
                // 等待直到恢复或被停止
                while (isPaused)
                {
                    await Task.Delay(interval);
                    if (isStopped || !isRunning) return;
                }
                // 继续循环，但不累加等待时间（让用户感知暂停前的状态）
            }
            else
            {
                int delay = Math.Min(interval, milliseconds - waited);
                await Task.Delay(delay);
                waited += delay;
            }
        }
    }

    // 可视化棋盘和皇后
    private void DrawBoard() {
        Bitmap bmp = new Bitmap(boardBitmap);

        using (Graphics g = Graphics.FromImage(bmp)) {
            for (int row = 0; row < 8; row++) {
                if (queens[row] != -1) {
                    int col = queens[row];

                    int x = col * cellSize + 28;
                    int y = row * cellSize + 28;

                    g.DrawImage(Properties.Resources.Queen, x, y, cellSize, cellSize);
                }
            }
        }

        pictureBox_Board.Image = bmp;
    }

    // 八皇后合法判断
    private bool IsValid(int row, int col) {
        for (int r = 0; r < row; r++) {
            int c = queens[r];
            if (c == col) return false;

            if (Math.Abs(r - row) == Math.Abs(c - col))
                return false;
        }
        return true;
    }

    // DFS搜索
    private async Task<bool> DFS(int row) {
        if (isStopped) return false;

        while (isPaused)
            await Task.Delay(100);

        if (row == 8) {
            // 找到一个解，显示当前棋盘
            DrawBoard();

            // 自动进入暂停状态（但保持isRunning为true，这样暂停按钮仍然可用）
            isPaused = true;
            button_pause.Text = "继续";
            UpdateStatus();

            // 弹窗询问是否继续查找下一个解
            var result = MessageBox.Show("找到一个解，是否寻找下一个？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                // 用户选择继续，恢复运行并继续回溯寻找下一个解
                isPaused = false;
                button_pause.Text = "暂停";
                UpdateStatus();
                return false; // 返回false以继续回溯并搜索更多解
            }

            // 用户选择否或关闭对话框，保持暂停状态，返回false以在上层循环中停住（上层会因isPaused而等待）
            return false;
        }

        for (int col = 0; col < 8; col++) {
            if (!isRunning) return false;

            if (IsValid(row, col)) {
                queens[row] = col;

                DrawBoard();

                await WaitOrPauseAsync(100); // 可视化延迟，支持立即暂停

                if (await DFS(row + 1))
                    return true;

                // 如果因为找到解而进入暂停（isPaused==true），在回溯并清除当前皇后之前先等待恢复
                while (isPaused)
                {
                    await Task.Delay(50);
                    if (isStopped || !isRunning)
                        return false;
                }

                queens[row] = -1;

                DrawBoard();

                await WaitOrPauseAsync(100); // 可视化延迟，支持立即暂停
            }
        }
        return false;
    }

    private async void button_start_Click(object sender, EventArgs e) {
        if (isRunning) return;

        isRunning = true;
        isStopped = false;

        button_start.Enabled = false;
        UpdateStatus();

        await DFS(0);

        isRunning = false;
        UpdateStatus();

        button_start.Enabled = true;
    }

    private void button_pause_Click(object sender, EventArgs e) {
        if (!isRunning) return;

        isPaused = !isPaused;

        button_pause.Text = isPaused ? "继续" : "暂停";
        UpdateStatus();
    }

    private void button_stop_Click(object sender, EventArgs e) {
        isStopped = true;
        isRunning = false;
        isPaused = false;

        button_pause.Text = "暂停";

        UpdateStatus();

        for (int i = 0; i < 8; i++) queens[i] = -1;
        
        DrawBoard();

        button_start.Enabled = true;
    }
}
