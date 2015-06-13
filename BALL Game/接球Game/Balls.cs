using System.Collections.Generic;
using System.Windows.Forms;

namespace 接球Game
{
    class Balls
    {
        List<BallMod> ballmods; //存储BallMod
        public List<BallMod> _Ballmods
        {
            get { return ballmods; }
        }

        public Balls()
        {
            ballmods = new List<BallMod> { };
        }

        private void CheckBalls(Control control,BallCatchGame.CancelorBidingDele cancelcatchball) //检查球是否超出panel范围
        {
            for (int i = 0; i < ballmods.Count; i++)
            {
                BallMod bm = ballmods[i];
                if (bm.BallBody.Location.Y >= control.Height+5)
                {
                    cancelcatchball(bm);
                    ballmods.Remove(bm);                    
                    //control.Controls.Clear(); //代码刷新闪烁严重
                }
            }
        }
        public void AddBallmod(BallCatchGame.CancelorBidingDele bidingcatchball)  //增加球
        {
            AddBallmod(5,bidingcatchball);
        }
        public void AddBallmod(int dropspeed,BallCatchGame.CancelorBidingDele bidingcatchball)  //增加球,下落速度 >0
        {
            BallMod newbm = new BallMod(dropspeed);
            foreach (BallMod bm in ballmods)
            {
                if (bm.BallBody.Location.X - bm.BallBody.Size.Width < newbm.BallBody.Location.X && bm.BallBody.Location.X + bm.BallBody.Size.Width > newbm.BallBody.Location.X)
                {
                    return;  //控制重叠，这里算法有必要添加一下
                }
            }
            ballmods.Add(newbm);
            bidingcatchball(newbm);
        }
        public void DropBall() //所有球下落
        {
            foreach (BallMod bm in ballmods)
            {
                bm.BallDroping();
            }
        }
        public void DrawBalls(Control control, BallCatchGame.CancelorBidingDele cancelcatchball) //画球
        {
            CheckBalls(control, cancelcatchball);
            foreach (BallMod bm in ballmods)
            {
                control.Controls.Add(bm.BallBody);
            }
        }

    }
}
