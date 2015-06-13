using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;   //使用keys
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Collections;

namespace 屏幕截图工具
{
    class Common
    {
        public static string name="";

        #region 全图截屏
        [DllImportAttribute("gdi32.dll")]
        public static extern bool BitBlt(
        IntPtr hdcDest, // 目标 DC的句柄
        int nXDest,
        int nYDest,
        int nWidth,
        int nHeight,
        IntPtr hdcSrc,  // 源DC的句柄
        int nXSrc,
        int nYSrc,
        System.Int32 dwRop  // 光栅的处理数值
        );

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr Hwnd); //其在MSDN中原型为HDC GetDC(HWND hWnd),HDC和HWND都是驱动器句柄（长指针），在C#中只能用IntPtr代替了
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        #endregion

        #region 快捷键
        [DllImport("user32.dll")]
            // 用于注册热键
            public static extern bool RegisterHotKey(
                IntPtr hWnd,                // 要定义热键的窗口的句柄
                int id,                     // 定义热键 ID （不能与其它 ID 重复）           
                KeyModifiers fsModifiers,   // 标识热键是否在按 Alt 、 Ctrl 、 Shift 、 Windows 等键时才会生效
                Keys vk                     // 定义热键的内容
            );
            [DllImport("user32.dll")]
            // 注销热键
            public static extern bool UnregisterHotKey(
                IntPtr hWnd,                // 要取消热键的窗口的句柄
                int id                      // 要取消热键的 ID
            );
            // 定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
            [Flags()]
            public enum KeyModifiers
            {
                None = 0,
                Alt = 1,
                Ctrl = 2,
                Shift = 4,
                WindowsKey = 8
            }
            #endregion

        public static string GetImgName()
        {
            string name;
            DateTime time = DateTime.Now;
            name = time.ToString().Replace(":", "/");
            name = name.Replace("/", "-");
            return name + ".png";
        }

        public static string SaveOther(Image image) //另存为,返回是路径
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|PNG Image|*.png";
                saveFileDialog1.Title = "Save an Image File";


                if (image == null)
                    MessageBox.Show("未找到图片");
                else
                    saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    System.IO.FileStream fs =
                      (System.IO.FileStream)saveFileDialog1.OpenFile();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Gif);
                            break;

                        case 4:
                            image.Save(fs,
                               System.Drawing.Imaging.ImageFormat.Png);
                            break;

                    }
                    fs.Close();
                    MessageBox.Show("保存成功");
                    return saveFileDialog1.FileName;  //返回路径，以便赋值给 FilePosation ，下一次再保存的时候不会执行另存为
                }
                else
                    return "";
            }

        public static string GetExtension(string FilePosation)  //后缀
        {
            return Path.GetExtension(FilePosation).ToLower();
        }

        public static string GetTempFilePosation(string FilePosation)//获取临时文件路径
        {
            return FilePosation.Replace(".", "_temp.");
        }

        public static void Save(Image image, string Extension,string Posation) //保存
        {
            switch (Extension)  //先保存临时文件
            {
                case ".jpg":
                    image.Save(Posation, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case ".gif":
                    image.Save(Posation, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case ".bmp":
                    image.Save(Posation, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case ".png":
                    image.Save(Posation, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                default:
                    throw new Exception("不允许的后缀:" + Posation);
            }
        }

        public static int CheckRegion(Image image, Point formPoint, ArrayList myrects,int Zoom)  //判断是否右键区域内保存,返回-1，表示不在.否则返回编号
        {
            int num=-1;
            int X = formPoint.X;
            int Y = formPoint.Y;
            if (image == null)
            {
                return -1;
            }
            //判断是否单击在现有矩形内
            for (int i = 0; i < myrects.Count; i++)
            {
                MyRect a = myrects[i] as MyRect;
                if (a != null)
                {
                    if ((X > a.X * Zoom && X < a.X * Zoom + a.W * Zoom) && (Y > a.Y * Zoom && Y < a.Y * Zoom + a.H * Zoom))//鼠标在已有矩形框内
                    {
                        num = i;
                        break;
                    }
                }
                if (i == myrects.Count - 1) 
                    return -1;
            }
            return num;
        }

        public static Image GetCutImage(int num, ArrayList myrects,Image image)  //返回切好的小图
        {
                MyRect rect = myrects[num] as MyRect;
                // 目标区域
                Rectangle destRect = new Rectangle(0, 0, rect.W, rect.H);
                // 源图区域
                Rectangle srcRect = new Rectangle(rect.X, rect.Y, rect.W, rect.H);

                // 新建Graphics对象
                Bitmap newImage = new Bitmap(rect.W, rect.H);
                Graphics g = Graphics.FromImage(newImage);
                // 绘图平滑程序
                g.SmoothingMode = SmoothingMode.HighQuality;

                // 图片输出质量
                g.CompositingQuality = CompositingQuality.HighQuality;

                // 输出到newImage对象
                g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);

                return newImage;
        }

        public static int GetUnitImageNum(Point UnitPoint) //获取点击缩略图编号
        {
            int X = UnitPoint.X;
            int Y = UnitPoint.Y;
            if ((Convert.ToInt32(X) / 80) < 1)
            {
                return Convert.ToInt32(Convert.ToInt32(Y) / 80) * 2;
            }
            else
                return Convert.ToInt32(Convert.ToInt32(Y) / 80) * 2 + 1;
        }


    }
}
