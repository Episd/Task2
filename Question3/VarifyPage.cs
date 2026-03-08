using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Question3;

public partial class VarifyPage : UserControl {

    private Bitmap originalImage;   // 原始图片
    private Bitmap puzzlePiece;     // 拼图块
    private Bitmap baseImageWithHole; // 带有缺口的背景图（不包含移动的拼图块）

    private int puzzleX;            // 拼图正确位置X
    private int puzzleY;            // 拼图正确位置Y

    private int pieceSize = 150;     // 拼图大小
    private bool isActive = false;   // 是否已经触发验证
    private bool isDragging = false; // 自定义拖动标志，用于确保第一次按下即可拖动

    public event EventHandler VarifySuccess;
    public event EventHandler BackClicked;

    private Random rand = new Random();
    public VarifyPage() {
        InitializeComponent();
        InitEvents();
        LoadImage();
    }

    // 绑定事件
    private void InitEvents() {
        trackBar1.MouseDown += TrackBar_MouseDown;
        trackBar1.Scroll += TrackBar_Scroll;
        trackBar1.MouseUp += TrackBar_MouseUp;
        trackBar1.MouseMove += TrackBar_MouseMove;
    }

    // 加载图片资源
    private void LoadImage() {
        originalImage = (Bitmap)Properties.Resources.puzzle1;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.Image = originalImage;
    }

    // 按下滑块事件
    private void TrackBar_MouseDown(object sender, MouseEventArgs e) {
        if (isActive) { return; }
        // 生成拼图并立即把滑块置于鼠标位置，保证按下后可以直接拖动
        GeneratePuzzle();
        isActive = true;

        // 将滑块值映射到当前鼠标 X 位置，确保 thumb 跟随鼠标开始拖动
        try {
            int range = Math.Max(1, trackBar1.Maximum - trackBar1.Minimum);
            int newValue = trackBar1.Minimum + (int)((double)e.X / Math.Max(1, trackBar1.Width) * range);
            newValue = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, newValue));
            trackBar1.Value = newValue;
            DrawPuzzle(trackBar1.Value);
            trackBar1.Focus();
            // 开始自定义拖动并捕获鼠标，保证第一次按下即可拖动
            isDragging = true;
            trackBar1.Capture = true;
        }
        catch {
            // 保持静默，防止在极端情况下抛出异常
        }
    }

    // 自定义鼠标移动处理，确保按下后可以立即拖动
    private void TrackBar_MouseMove(object? sender, MouseEventArgs e) {
        if (!isActive || !isDragging) return;

        try {
            int range = Math.Max(1, trackBar1.Maximum - trackBar1.Minimum);
            int newValue = trackBar1.Minimum + (int)((double)e.X / Math.Max(1, trackBar1.Width) * range);
            newValue = Math.Max(trackBar1.Minimum, Math.Min(trackBar1.Maximum, newValue));
            if (trackBar1.Value != newValue) {
                trackBar1.Value = newValue;
                DrawPuzzle(trackBar1.Value);
            }
        }
        catch {
            // 忽略可能的计算异常
        }
    }

    // 生成小拼图滑块
    private void GeneratePuzzle() {
        // 基于原始图片创建工作副本
        Bitmap img = new Bitmap(originalImage);

        // 随机选择拼图缺口位置（保证在边界内）
        puzzleX = rand.Next(60, Math.Max(61, img.Width - pieceSize - 10));
        puzzleY = rand.Next(20, Math.Max(21, img.Height - pieceSize - 20));

        Rectangle rect = new Rectangle(puzzleX, puzzleY, pieceSize, pieceSize);

        // 裁剪拼图（来自原始图，不包含挖空）
        puzzlePiece = img.Clone(rect, img.PixelFormat);

        // 挖空效果：在工作图上绘制半透明遮罩
        using (Graphics g = Graphics.FromImage(img)) {
            using Brush brush = new SolidBrush(Color.FromArgb(160, Color.Gray));
            g.FillRectangle(brush, rect);
            // 给缺口加一点边缘，让视觉更明显
            using (Pen pen = new Pen(Color.FromArgb(200, Color.White), 2)) {
                g.DrawRectangle(pen, rect);
            }
        }

        // 保存带缺口的基础图，用作后续绘制的底图（不包含移动的拼图块）
        baseImageWithHole = img;

        // 将 pictureBox 显示为 baseImageWithHole 的拷贝（防止直接修改 baseImageWithHole）
        pictureBox1.Image = new Bitmap(baseImageWithHole);

        // 将滑块范围设为图片的像素坐标范围（而不是控件宽度），保证滑块值与图片坐标一致
        trackBar1.Minimum = 0;
        trackBar1.Maximum = Math.Max(0, baseImageWithHole.Width - pieceSize);
        trackBar1.SmallChange = 1;
        trackBar1.LargeChange = Math.Max(1, pieceSize / 2);
    }


    // 滑块移动时，同步拼图移动
    private void TrackBar_Scroll(object sender, EventArgs e) {
        if (!isActive) return;

        DrawPuzzle(trackBar1.Value);
    }

    // 绘制小拼图
    private void DrawPuzzle(int x) {
        if (baseImageWithHole == null || puzzlePiece == null) return;

        // 确保 x 在图片范围内
        int maxX = Math.Max(0, baseImageWithHole.Width - pieceSize);
        int xClamped = Math.Max(0, Math.Min(x, maxX));

        Bitmap img = new Bitmap(baseImageWithHole);

        using (Graphics g = Graphics.FromImage(img)) {
            // 先绘制一点阴影，增强立体感
            using (Brush shadow = new SolidBrush(Color.FromArgb(80, 0, 0, 0))) {
                g.FillRectangle(shadow, xClamped + 2, puzzleY + 2, pieceSize, pieceSize);
            }

            g.DrawImage(puzzlePiece, xClamped, puzzleY);
        }

        // 替换 pictureBox 显示（不修改 baseImageWithHole）
        pictureBox1.Image = img;
    }

    // 松开鼠标时进行拼图位置验证
    private void TrackBar_MouseUp(object sender, MouseEventArgs e) {
        if (!isActive) return;
        // 结束自定义拖动并释放鼠标捕获
        isDragging = false;
        try { trackBar1.Capture = false; } catch { }

        int offset = Math.Abs(trackBar1.Value - puzzleX);
        int tolerance = Math.Max(8, pieceSize / 6); // 容错，随拼图大小调整

        if (offset <= tolerance) {
            MessageBox.Show("验证成功");
            VarifySuccess?.Invoke(this, EventArgs.Empty);
        }
        else {
            MessageBox.Show("验证失败");
        }

        ResetCaptcha();
    }

    // 重置拼图验证
    private void ResetCaptcha() {
        isActive = false;

        // 恢复显示原始图片
        pictureBox1.Image = originalImage;

        // 清理临时图像，释放资源
        if (baseImageWithHole != null) {
            try { baseImageWithHole.Dispose(); } catch { }
            baseImageWithHole = null;
        }

        if (puzzlePiece != null) {
            try { puzzlePiece.Dispose(); } catch { }
            puzzlePiece = null;
        }

        trackBar1.Value = 0;
    }

    private void button_back_Click(object sender, EventArgs e) {
        BackClicked?.Invoke(this, EventArgs.Empty);
    }
}
