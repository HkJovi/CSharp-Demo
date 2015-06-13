using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace 接球Game
{
    public class BallMod
    {
        private Posation pos;  //球坐标
        private Label ballBody;  //球身
        public Label BallBody
        {
            get { return ballBody; }
            set { ballBody = value; }
        }
        private Color color = Color.LightBlue;  //颜色
        private Size size = new Size(20, 20);  //大小
        private int dropspeed = 5; //默认下落速度

        public BallMod()  //构造球
        {
            AddBallMod();
        }
        public BallMod(int dropspeed)//构造球
        {
            if (dropspeed > 0)
                this.dropspeed = dropspeed;
            AddBallMod();
        }

        private Point RandomLocation()  //随机位置
        {
            Random rd = new Random();
            int x = rd.Next(400);
            return new Point(x, 0);
        }
        public void AddBallMod()  //添加球
        {
            ballBody = new Label();
            ballBody.Size = size;
            ballBody.BackColor = color;
            ballBody.BorderStyle = BorderStyle.None;
            ballBody.Location = RandomLocation();
            pos.X = ballBody.Location.X;
            pos.Y = ballBody.Location.Y;
        }
        public void BallDroping()  //球下落
        {
            ballBody.Location = new Point(pos.X, pos.Y + dropspeed);
            pos.X = ballBody.Location.X;
            pos.Y = ballBody.Location.Y;
        }
        public void BallCatched(int x, int width, int y, int height, BallCatchGame.ScoreCallback callback, BallCatchGame.CancelorBidingDele cancelcatchball) //接球button的参数
        {
            if (ballBody.Location.X < x + width && ballBody.Location.X + ballBody.Size.Width > x && (ballBody.Location.Y + ballBody.Size.Height >= y ||ballBody.Location.Y <= y+height && ballBody.Location.Y >= y ))
            {
                callback(); //修改得分
                cancelcatchball(this);
            }
        }
    }

    struct Posation
    {
        public int X;
        public int Y;
    }
}
