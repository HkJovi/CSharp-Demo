using System;
using System.Drawing;
using System.Windows.Forms;

namespace 接球Game
{
    public partial class BallCatchGame : Form
    {
        Balls balls;
        public delegate void CancelorBidingDele(BallMod bmd);  //声明绑定和取消绑定接球事件委托
        public delegate void ScoreCallback();  //修改得分委托
        public delegate void deleCatchBall(int x, int width, int y, int height, ScoreCallback callback, CancelorBidingDele cancelcatchball); //声明接球委托
        public event deleCatchBall eventCatchBall;  //声明接球事件
        public void OnCatchBall()  //事件
        {
            if (eventCatchBall != null)
                eventCatchBall(button1.Location.X, button1.Size.Width, button1.Location.Y,button1.Size.Height,ChangeScore,CancelCatchBall);
        }


        public BallCatchGame()
        {
            InitializeComponent();
            balls = new Balls();
        }     

        private void btn_start_Click(object sender, EventArgs e)
        {
            panel.MouseMove += panel1_MouseMove;
            toolStripButton1.Enabled = false;
            timer1.Start();
            timer2.Start();         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            balls.DropBall();  //球下落
            balls.DrawBalls(this.panel,CancelCatchBall);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int cout = balls._Ballmods.Count;
            Random rd = new Random();
            int speed = rd.Next(5, 25);
            balls.AddBallmod(speed,BidingCatchBall);  //添加球绑定委托
            OnCatchBall();
            balls.DrawBalls(this.panel,CancelCatchBall);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Hide();
            Point pt = this.panel.PointToClient(Control.MousePosition);
            int x = (pt.X < (panel.Width - button1.Width)) ? pt.X : panel.Width - button1.Width;
            button1.Location = new Point(x, panel.Height - button1.Height - 1);
        }

        private  void ChangeScore() //修改分数方法
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.sound);
            sp.Play();
            int score=int.Parse(label1.Text);
            label1.Text = (score + 1).ToString();
        }
        
        private void CancelCatchBall(BallMod bmd)  //取消接球事件绑定方法
        {
            eventCatchBall -= bmd.BallCatched;
        }
        private void BidingCatchBall(BallMod bmd)   //绑定接球事件方法
        {
            eventCatchBall += bmd.BallCatched;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("您当前得分为：" + label1.Text + " \n确定要退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
                this.Dispose();
        }

    }
}
