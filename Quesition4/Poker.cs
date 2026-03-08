namespace Quesition4;

public partial class Poker : Form {
    private Random rand = new Random();
    private List<Card> player1Cards = new();        // 玩家1的牌组
    private List<Card> player2Cards = new();        // 玩家2的牌组

    private PictureBox[] PictureBoxes1;
    private PictureBox[] PictureBoxes2;

    private int p1Score = 0;                        // 玩家1分数
    private int p2Score = 0;                        // 玩家2分数
    private int rounds = 0;                         // 已经进行的轮数


    private int? p1Selected = null;
    private int? p2Selected = null;

    public Poker() {
        InitializeComponent();
        PictureBoxes1 = new PictureBox[] {
            pictureBox_p1card0,
            pictureBox_p1card1,
            pictureBox_p1card2,
            pictureBox_p1card3,
            pictureBox_p1card4
        };
        PictureBoxes2 = new PictureBox[] {
            pictureBox_p2card0,
            pictureBox_p2card1,
            pictureBox_p2card2,
            pictureBox_p2card3,
            pictureBox_p2card4
        };

        // 绑定扑克牌的点击事件
        for (int i = 0; i < 5; i++) {
            int index = i;
            PictureBoxes1[i].Click += (s, e) => SelectP1(index);
            PictureBoxes2[i].Click += (s, e) => SelectP2(index);
        }

        StartGame();
    }

    // 发牌的逻辑
    private void StartGame() {
        // 初始化各项属性
        rounds = 0;

        player1Cards.Clear();
        player2Cards.Clear();

        p1Score = 0;
        p2Score = 0;

        label_score.Text = "Score: 0 - 0";

        // 随机制造牌组并背面朝上
        for (int i = 0; i < 5; i++) {
            player1Cards.Add(RandomCard());
            player2Cards.Add(RandomCard());
        }
        

        foreach(PictureBox pictureImage in PictureBoxes1) {
            pictureImage.Enabled = true;
            pictureImage.Image = Properties.Resources.cardBack_blue2;
        }

        foreach(PictureBox pictureImage in PictureBoxes2) {
            pictureImage.Enabled = true;
            pictureImage.Image = Properties.Resources.cardBack_red2;
        }
    }

    // 抽取随机卡牌
    private Card RandomCard() {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        // 随机选定花色和牌面数字
        string suit = suits[rand.Next(4)];
        int value = rand.Next(1, 14);

        // 从项目资源中加载图片并创建卡牌对象
        string name = $"card{suit}{value}";
        Image img = (Image)Properties.Resources.ResourceManager.GetObject(name);
        return new Card {
            Suit = suit,
            Value = value,
            Image = img
        };
    }

    // 玩家1选择牌的逻辑
    private void SelectP1(int index) {
        if (p1Selected != null) return;

        p1Selected = index;

        PictureBoxes1[index].Image = player1Cards[index].Image;
        // 选牌后禁用该牌，防止重复选择
        PictureBoxes1[p1Selected.Value].Enabled = false;

        TryCompare();
    }

    // 玩家2选择牌的逻辑
    private void SelectP2(int index) {
        if (p2Selected != null) return;

        p2Selected = index;

        PictureBoxes2[index].Image = player2Cards[index].Image;

        PictureBoxes2[p2Selected.Value].Enabled = false;

        TryCompare();
    }

    // 比较牌面大小
    private void TryCompare() {
        // 另外一方未选牌，无法比较
        if (p1Selected == null || p2Selected == null)
            return;

        rounds ++;

        Card c1 = player1Cards[p1Selected.Value];
        Card c2 = player2Cards[p2Selected.Value];

        if (c1.Value > c2.Value)
            p1Score++;
        else if (c1.Value < c2.Value)
            p2Score++;

        label_score.Text = $"Score: {p1Score} - {p2Score}";

        p1Selected = null;
        p2Selected = null;

        if (rounds == 5)
            CheckGameEnd();
    }

    // 判断游戏是否结束
    private void CheckGameEnd() {
        int opened = 0;

        // 数一下已经打开的牌面
        foreach (var pb in PictureBoxes1)
            if (pb.Image != Properties.Resources.cardBack_blue2)
                opened++;

        if (opened == 5) {
            string msg;

            if (p1Score > p2Score)
                msg = "Player 1 获胜!";
            else if (p1Score < p2Score)
                msg = "Player 2 获胜!";
            else
                msg = "平局!";

            MessageBox.Show(msg);
        }
    }

    private void button_restart_Click(object sender, EventArgs e) {
        StartGame();
    }
}
