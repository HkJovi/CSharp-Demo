using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.IO;

namespace 屏幕截图工具
{
    public partial class CutImageTool : Form
    {
        #region  切图变量声明
        Image image;
        MyRect myrect;
        ArrayList myrects = new ArrayList();
        ArrayList UintImages = new ArrayList();
        Image ClickImg; //保存点击的缩略图的图片

        int ReferenceX;//指针的参考线
        int ReferenceY;//指针的参考线

        int MoveX = 0;
        int MoveY = 0;
        int MoveW = 0;//拖动矩形移动的宽度
        int MoveH = 0;//拖动矩形移动的高度
        int MoveID = -1;//拖动移动的矩形索引

        bool CreatRect = true;
        bool CtrlKyeDown = false;
        bool CreatRectSwitch = true; //控制切图内不能画框

        int Zoom = 1;//变焦 表示缩放比例

        static string FilePosation;// 获取打开文件路径
        Point formPoint;  //获取鼠标的坐标
        Bitmap newImage;  //image添加到UnitImage的临时文件，写在这是因为上一轮的最后一次不会清空

        #endregion


        #region 铅笔工具变量声明
        Point mobjStartPoint;
        ArrayList mobjPointsArray;
        ArrayList MobjPointsArrayContainer = new ArrayList();
        Pen MobjPen = new Pen(Color.Blue, 1);
        bool MblStartDrawing;
        bool DrawSwitch=false;   //画图按钮开关
        #endregion

        public CutImageTool()
        {
            InitializeComponent();
            if (Clipboard.GetImage() != null)
            {
                image = Clipboard.GetImage();
                FilePosation = Application.StartupPath + Common.name + ".Png";
            }
            if (image != null)
            {
                PicBox.Enabled = true;
                toolStripButton_pen.Enabled = true;
            }
        }
        //打开图片按钮按下
        private void OpenImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "图片文件|*.jpg;*.bmp;*.gif;*.png";
            dialog.InitialDirectory = @".\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //若有则 清空上一次操作
                if (image != null)
                    image.Dispose();
                ClickImg = null;
                PicBox.Enabled = true;
                toolStripButton_pen.Enabled = true;
                CreatRectSwitch = true; //控制切图内不能画框
                CreatRect = true;
                DrawSwitch = false;
                MoveX = 0;
                MoveY = 0;
                MoveW = 0;//拖动矩形移动的宽度
                MoveH = 0;//拖动矩形移动的高度
                MoveID = -1;//拖动移动的矩形索引
                Zoom = 1;
                myrects.Clear();
                UintImages.Clear();
                UnitImagesBox.Refresh();
                toolStripButton_pen.Checked = false;


                image = Image.FromFile(dialog.FileName);
                FilePosation = dialog.FileName;
                PicBox.Width = image.Width;
                PicBox.Height = image.Height;
            }
        }

        //放大按钮
        private void Enlarge_Click(object sender, EventArgs e)
        {
            if (image == null) return;
            Zoom++;
            if (Zoom >= 8)
            {
                Zoom = 8;
            }
            PicBox.Refresh();
        }

        //缩小按钮
        private void NarrowBtn_Click(object sender, EventArgs e)
        {
            if (image == null) return;
            Zoom--;
            if (Zoom <= 1)
            {
                Zoom = 1;
            }
            PicBox.Refresh();
        }

        //鼠标键按下
        private void PicBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (DrawSwitch == false&&CreatRectSwitch == true)
            {
                if (e.Button == MouseButtons.Left)   //限定左键划定区域
                {
                    Point formPoint = PicBox.PointToClient(Control.MousePosition);//获取鼠标当前坐标
                    int X = formPoint.X;
                    int Y = formPoint.Y;
                    PicBox.Refresh();
                    if (image == null)
                    {
                        return;
                    }
                    //判断是否单击在现有矩形内
                    for (int i = 0; i < myrects.Count; i++)
                    {
                        MyRect a = myrects[i] as MyRect;
                        if (a != null)
                        {
                            if (X > a.X * Zoom && X < a.X * Zoom + a.W * Zoom && Y > a.Y * Zoom && Y < a.Y * Zoom + a.H * Zoom) //鼠标在已有矩形框内
                            {
                                MoveX = a.X * Zoom;
                                MoveY = a.Y * Zoom;
                                MoveW = X - a.X * Zoom;
                                MoveH = Y - a.Y * Zoom;
                                MoveID = i;
                                CreatRect = false;
                                DrawSelectRect(a);
                                return;
                            }
                        }
                        if (i == myrects.Count - 1) CreatRect = true;
                    }
                    //判断是否新建矩形
                    if (CreatRect)
                    {
                        myrect = new MyRect();
                        myrect.X=X;
                        myrect.Y=Y;
                        if (myrect.X < 2 ) //最小2 X 2
                            myrect.X = 2;
                        if (myrect.Y < 2)
                            myrect.Y = 2;
                    }
                }
            }
            else
                if(DrawSwitch == true)
            {
                //设置鼠标图象为铅笔图象
                //Cursor signCursor = new Cursor(@"d:\\pen.ico");
                //this.Cursor = signCursor;

                //设置开始标记的点
                mobjStartPoint = new Point(e.X , e.Y );
                mobjPointsArray = new ArrayList();
                Pen pen = new Pen(MobjPen.Color, MobjPen.Width);
                mobjPointsArray.Add(pen);
                mobjPointsArray.Add(mobjStartPoint);
                MblStartDrawing = true;
            }
        }

        //鼠标键移动
        private void PicBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawSwitch == false && CreatRectSwitch == true)
            {
                formPoint = PicBox.PointToClient(Control.MousePosition);//鼠标相对于窗体左上角的坐标
                toolStripStatusLabel_point.Text = formPoint.X.ToString() + "," + formPoint.Y.ToString();
                PicBox.Refresh();
                if (image == null)
                {
                    return;
                }
                //参考线 
                ReferenceX = formPoint.X;
                ReferenceY = formPoint.Y;
                //绘制参考线
                DrawReferenceLine();

                //新建矩形
                if (CreatRect)
                {
                    if (myrect != null)
                    {
                        myrect.W = Math.Abs(formPoint.X - myrect.X);
                        myrect.H = Math.Abs(formPoint.Y - myrect.Y);
                        if (myrect.W < 2)
                            myrect.W = 2;
                        if (myrect.H < 2)
                            myrect.H = 2;
                        //绘制鼠标切出的矩形
                        DrawCutRect(myrect);
                    }
                }
                //单击在现有矩形内移动
                else
                {

                    if (MoveID >= 0)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            (myrects[MoveID] as MyRect).X = (formPoint.X - MoveW) / Zoom;
                            (myrects[MoveID] as MyRect).Y = (formPoint.Y - MoveH) / Zoom;
                            if ((myrects[MoveID] as MyRect).X <= 0)
                            {
                                (myrects[MoveID] as MyRect).X = 0;
                            }
                            if ((myrects[MoveID] as MyRect).Y <= 0)
                            {
                                (myrects[MoveID] as MyRect).Y = 0;
                            }
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            (myrects[MoveID] as MyRect).W = ((formPoint.X - (myrects[MoveID] as MyRect).X * Zoom) / Zoom);
                            (myrects[MoveID] as MyRect).H = ((formPoint.Y - (myrects[MoveID] as MyRect).Y * Zoom) / Zoom);
                        }
                    }

                }
            }
            else
                if (DrawSwitch == true)
            {
                try
                {
                    //移动中进行画图
                    if (MblStartDrawing)
                    {
                        //path.StartFigure();
                        Point currentPoint = new Point(e.X , e.Y);
                        mobjPointsArray.Add(currentPoint);
                        PicBox.CreateGraphics().DrawLine(MobjPen, mobjStartPoint, currentPoint);  //屏幕划线
                        if (ClickImg != null)
                        {
                            Graphics g_click_image;
                            g_click_image = Graphics.FromImage(ClickImg);
                            g_click_image.DrawLine(MobjPen, mobjStartPoint, currentPoint); //保存在ClickImg上
                        }
                        else
                        {
                            Graphics g_temp = Graphics.FromImage(image);
                            g_temp.DrawLine(MobjPen, mobjStartPoint, currentPoint); //保存在image上    
                        }
                        mobjStartPoint = currentPoint;
                    }
                    else
                    {
                        if (Cursor.Position.X >= PicBox.Left  && Cursor.Position.X <= PicBox.Right &&
                            Cursor.Position.Y >= PicBox.Top  && Cursor.Position.Y <= PicBox.Bottom )
                        {
                            PicBox.Focus();        //如果鼠标位于工具栏上，转移焦点到工具栏
                        }
                        else
                        {
                            this.Focus();               //转移焦点到窗口
                        }
                    }
                }
                catch 
                {
                    if (MessageBox.Show("画图错误:请打开图片") == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }
        }

        //鼠标键抬起
        private void PicBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (DrawSwitch == false && CreatRectSwitch == true)
            {
                if (image == null)
                {
                    return;
                }
                //单击在现有矩形内抬起
                if (!CreatRect)
                {
                    MoveX = 0;
                    MoveY = 0;
                    MoveW = 0;
                    MoveH = 0;
                    MoveID = -1;
                }
                //新建矩形抬起
                if (CreatRect)
                {
                    if (myrect != null)
                    {
                        myrect.X = myrect.X / Zoom;
                        myrect.Y = myrect.Y / Zoom;
                        myrect.W = myrect.W / Zoom;
                        myrect.H = myrect.H / Zoom;
                        myrects.Add(myrect);
                        myrect = null;
                    }

                }
            }
            else
                if (DrawSwitch == true)
            {
                this.Cursor = Cursors.Arrow;
                MblStartDrawing = false;
                MobjPointsArrayContainer.Add(mobjPointsArray);
                //Invalidate();
            }
        }

        //显示框内的内容
        private void PicBox_Paint(object sender, PaintEventArgs e)
        {
            if (ClickImg == null)
            {
                DrawImage(image, e);
                DrawMyrects(e);
            }
            else
                DrawImage(ClickImg, e);
        }

        //绘制图片
        private void DrawImage(Image img, PaintEventArgs e)
        {
            if (img == null) return;
            Bitmap bitmap = new Bitmap(img);
            Rectangle destRect = new Rectangle(0, 0, img.Width * Zoom, img.Height * Zoom);
            Rectangle srcRect = new Rectangle(0, 0, img.Width, img.Height);
            PicBox.Width = image.Width * Zoom;
            PicBox.Height = image.Height * Zoom;
            e.Graphics.DrawImage(bitmap, destRect, srcRect, GraphicsUnit.Pixel);
        }

        //绘制鼠标切出的矩形
        private void DrawCutRect(MyRect rect)
        {
            if (rect == null) return;
            Pen pen = new Pen(Color.Red, 1);//设置笔的粗细为,颜色为红色
            Graphics g = PicBox.CreateGraphics();
            g.DrawRectangle(pen, rect.X, rect.Y, rect.W, rect.H);
        }

        //绘制参考线
        private void DrawReferenceLine()
        {
            Pen pen = new Pen(Color.Green, 1);//设置笔的粗细为,颜色为蓝色
            Graphics g = PicBox.CreateGraphics();
            g.DrawLine(pen, 0, ReferenceY, PicBox.Width, ReferenceY);
            g.DrawLine(pen, ReferenceX, 0, ReferenceX, PicBox.Height);
        }
        //绘制已经截好的矩形
        private void DrawMyrects(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 1);//设置笔的粗细为,颜色为红色
            String text;
            for (int i = 0; i < myrects.Count; i++)
            {
                text = "" + i;
                MyRect a = myrects[i] as MyRect;
                if (a != null)
                    e.Graphics.DrawRectangle(pen, a.X * Zoom, a.Y * Zoom, a.W * Zoom, a.H * Zoom);
                e.Graphics.DrawString(text, new Font("Verdana", 6 * Zoom), new SolidBrush(Color.Tomato), new Point(a.X * Zoom + 1, a.Y * Zoom + 1));
            }
        }

        //选中的矩形变换颜色
        private void DrawSelectRect(MyRect rect)
        {
            if (rect == null) return;
            Pen pen = new Pen(Color.Black, 1);//设置笔的粗细为,颜色为红色
            Graphics g = PicBox.CreateGraphics();
            g.DrawRectangle(pen, rect.X * Zoom, rect.Y * Zoom, rect.W * Zoom, rect.H * Zoom);
        }

        private void CutImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 17)
            {
                CtrlKyeDown = true;
            }
        }

        private void DetermineBtn_Click(object sender, EventArgs e)
        {
            if (image == null)
                return;
            newImage = null; //清空上一次保存的newImage
            if (myrects.Count <= 0)   //检查坐标数组
                return;
            UnitImagesBox.Enabled = true;
            UintImages.Clear();
            for (int i = 0; i < myrects.Count; i++)
            {
                MyRect rect = myrects[i] as MyRect;
                // 目标区域
                Rectangle destRect = new Rectangle(0, 0, rect.W, rect.H);
                // 源图区域
                Rectangle srcRect = new Rectangle(rect.X, rect.Y, rect.W, rect.H);

                // 新建Graphics对象
                newImage = new Bitmap(rect.W, rect.H);
                Graphics g = Graphics.FromImage(newImage);
                // 绘图平滑程序
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 图片输出质量
                g.CompositingQuality = CompositingQuality.HighQuality;

                // 输出到newImage对象
                g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);

                UintImages.Add(newImage);
            }
            UnitImagesBox.Refresh();
        }

        private void UnitImagesBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < UintImages.Count; i++)
            {
                Image uImg = UintImages[i] as Image;
                Rectangle destRect = new Rectangle((i % 2) * 80, (i / 2) * 80, 80, 80);
                Rectangle srcRect = new Rectangle(0, 0, uImg.Width, uImg.Height);
                e.Graphics.DrawImage(uImg, destRect, srcRect, GraphicsUnit.Pixel);
                e.Graphics.DrawRectangle(new Pen(Color.Red), destRect);
            }
        }

        private void Set_Badge_Click(object sender, EventArgs e)  //水印
        {
            Font V_font = new Font("微软雅黑", 12); ;
            int V_p = 1;
            if (ClickImg != null)
            {
                V_p = toolStripComboBox1.SelectedIndex + 1;//设置文字的显示位置
                ClickImg = BadgeImage.SetBadge(ClickImg, toolStripTextBox1.Text, V_font, V_p);//调用自定义方法
            }
            else
            {
                if (image != null)
                {
                    V_p = toolStripComboBox1.SelectedIndex + 1;//设置文字的显示位置
                    image = BadgeImage.SetBadge(image, toolStripTextBox1.Text, V_font, V_p);//调用自定义方法
                }
                else
                    MessageBox.Show("未打开图片！");
            }
            PicBox.Refresh();
        }

        private void exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ClickImg!=null)
                ClickImg.Dispose();
            if (image != null)
            image.Dispose();
            if (FilePosation != null)  
            {
                if (File.Exists(Common.GetTempFilePosation(FilePosation)))
                    File.Delete(Common.GetTempFilePosation(FilePosation));
            }
            this.Dispose();
            this.Close();
        }

        private void saveother_ToolStripMenuItem_Click(object sender, EventArgs e) //另存为
        {
            if (Common.SaveOther(image) != "")  //过滤掉另存为取消的时候， FilePosation 赋值
            {
                FilePosation = Common.SaveOther(image);
                image.Dispose();
                image = Image.FromFile(FilePosation);
            }
        }

        private void save_ToolStripMenuItem_Click(object sender, EventArgs e)  //需要临时文件
        {
            if (FilePosation != null)
            {
                string Extension = Common.GetExtension(FilePosation);
                if (File.Exists(FilePosation))
                {
                    Common.Save(image, Extension, Common.GetTempFilePosation(FilePosation));//保存临时文件
                    image.Dispose(); //释放原文件
                    image = Image.FromFile(Common.GetTempFilePosation(FilePosation));//打开临时文件
                    File.Delete(FilePosation);  //删除原来文件
                    Common.Save(image, Extension, FilePosation); //将临时文件保存为原文件
                    image.Dispose();//释放临时文件
                    image = Image.FromFile(FilePosation);//打开原来文件
                    File.Delete(Common.GetTempFilePosation(FilePosation)); //删除临时文件
                    MessageBox.Show("保存成功");
                }
                else
                    Common.SaveOther(image);
            }
            else
                FilePosation = Common.SaveOther(image);
        }

        private void toolStripButton_clear_Click(object sender, EventArgs e)  //清空按钮
        {
            UintImages.Clear();
            UnitImagesBox.Refresh();
            myrects = new ArrayList();
            UintImages = new ArrayList();
            PicBox.Refresh();
            UnitImagesBox.Enabled = false;

            if (FilePosation != null)
            {
                string Extension = Common.GetExtension(FilePosation);
                if (File.Exists(FilePosation))
                {
                    if (image != null)
                        image.Dispose();
                    image = Image.FromFile(FilePosation);
                    if(File.Exists(Common.GetTempFilePosation(FilePosation)))
                    File.Delete(Common.GetTempFilePosation(FilePosation));
                    PicBox.Refresh();
                }
            }

            else
                MessageBox.Show("请先打开图片！");

        }

        private void ToolStripMenuItem_saveother_Click(object sender, EventArgs e)  //右键另存为
        {
            int num = -1;
            num = Common.CheckRegion(image, formPoint, myrects, Zoom);//获取返回切图的编号
            if (num != -1)
            {
                Common.SaveOther(Common.GetCutImage(num, myrects, image));
            }
            else
            {
                if (ClickImg != null)
                    Common.SaveOther(ClickImg);
                else
                    MessageBox.Show("未选中区域或者未打开图片！");
            }
        }

        private void ToolStripMenuItem_copychipboard_Click(object sender, EventArgs e)
        {
            int num = -1;
            Point formPoint = PicBox.PointToClient(Control.MousePosition);//获取鼠标当前坐标
            num = Common.CheckRegion(image, formPoint, myrects, Zoom);//获取返回切图的编号
            if (num != -1)
            {
                Clipboard.Clear();
                Clipboard.SetImage(Common.GetCutImage(num, myrects, image));
                MessageBox.Show("复制成功！");
            }
            else
            {
                if (ClickImg != null)
                {
                    Clipboard.Clear();
                    Clipboard.SetImage(ClickImg);
                    MessageBox.Show("复制成功！");
                }
                else
                    if (image != null)
                    {
                        Clipboard.Clear();
                        Clipboard.SetImage(image);
                        MessageBox.Show("复制成功！");
                    }
                    else
                    MessageBox.Show("未选中区域或者未打开图片！");
            }
        }

        private void UnitImagesBox_MouseClick(object sender, MouseEventArgs e)  //缩略图变成主图
        {
            Point UnitPoint = UnitImagesBox.PointToClient(Control.MousePosition);
            int UnitNum = Common.GetUnitImageNum(UnitPoint);
            if (UnitNum >= UintImages.Count)
                return;
            ClickImg = Common.GetCutImage(UnitNum, myrects, image);
            PicBox.Refresh();
            CreatRectSwitch = false;
            if (toolStripButton_pen.Checked == true)
            {
                toolStripButton_pen.Checked = false;  //返回关闭铅笔
                DrawSwitch = false;
            }
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            ClickImg = null;
            PicBox.Refresh();
            CreatRect = true;
            CreatRectSwitch = true;
            if (toolStripButton_pen.Checked == true)
            {
                toolStripButton_pen.Checked = false;  //返回关闭铅笔
                DrawSwitch = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) //获取右点击坐标  保存到formPoint
        {

            formPoint = PicBox.PointToClient(Control.MousePosition);//获取鼠标当前坐标
        }

        private void toolStripButton_pen_Click(object sender, EventArgs e) //画笔按钮
        {
            if (DrawSwitch == false)
            {
                PicBox.Refresh();    //刷新掉参考线
                DrawSwitch = true;
                mobjPointsArray = null;
            }
            else
            {
            if (FilePosation != null)
            {
                string Extension = Common.GetExtension(FilePosation);
                if (File.Exists(FilePosation))
                {
                    if (File.Exists(Common.GetTempFilePosation(FilePosation)))  //如果已经有临时文件
                    {
                        Common.Save(image, Extension, Common.GetTempFilePosation(Common.GetTempFilePosation(FilePosation)));//保存临时文件的临时文件
                        image.Dispose();
                        image = Image.FromFile(Common.GetTempFilePosation(Common.GetTempFilePosation(FilePosation)));//打开临时文件的临时文件
                        File.Delete(Common.GetTempFilePosation(FilePosation));  //删除临时文件
                        Common.Save(image, Extension, Common.GetTempFilePosation(FilePosation)); //将临时的临时文件保存为临时文件
                        image.Dispose();//释放临时文件
                        image = Image.FromFile(Common.GetTempFilePosation(FilePosation));//打开临时文件
                        File.Delete(Common.GetTempFilePosation(Common.GetTempFilePosation(FilePosation))); //删除临时的临时文件
                    }
                    else
                    {
                        Common.Save(image, Extension, Common.GetTempFilePosation(FilePosation));//保存临时文件
                        image.Dispose(); //释放原文件
                        image = Image.FromFile(Common.GetTempFilePosation(FilePosation));//打开临时文件
                    }
                }
            }
                DrawSwitch = false;
            }
        }

        private void CutImageTool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                open_ToolStripMenuItem.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.R)
            {
                exit_ToolStripMenuItem.PerformClick();
            }        
        }


    }


    public class MyRect
    {
        public int X =2;
        public int Y =2;
        public int W =2;
        public int H =2;
    };

}
