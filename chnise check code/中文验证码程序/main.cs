using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 中文验证码程序
{
    public partial class main : Form
    {
        static string Code = "";
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            string Code = GetCheckCode.GenCode(8);
            char[] char_Code = Code.ToCharArray();
            int[] Code_sort = GetCheckCode.GetRandomSort(0, 8, 8);
            this.pictureBox_CheckCode.Image = GetCheckCode.CreateCheckCodeImage(Code);
            this.pictureBox_CheckCode.Tag = Code.Substring(0,4);

            //Tag 传递字符 
            this.Image1.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[0]].ToString());
            this.Image1.Tag = char_Code[Code_sort[0]].ToString();      
            this.Image2.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[1]].ToString());
            this.Image2.Tag = char_Code[Code_sort[1]].ToString();
            this.Image3.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[2]].ToString());
            this.Image3.Tag = char_Code[Code_sort[2]].ToString();
            this.Image4.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[3]].ToString());
            this.Image4.Tag = char_Code[Code_sort[3]].ToString();
            this.Image5.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[4]].ToString());
            this.Image5.Tag = char_Code[Code_sort[4]].ToString();
            this.Image6.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[5]].ToString());
            this.Image6.Tag = char_Code[Code_sort[5]].ToString();
            this.Image7.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[6]].ToString());
            this.Image7.Tag = char_Code[Code_sort[6]].ToString();
            this.Image8.Image = GetCheckCode.CreateOneCheckCodeImage(char_Code[Code_sort[7]].ToString());
            this.Image8.Tag = char_Code[Code_sort[7]].ToString();
        }

        private void Image1_Click(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            ////  向下改成效果

            //if (picturebox.BorderStyle == BorderStyle.None)   
            //    picturebox.BorderStyle = BorderStyle.FixedSingle;
            //else
            //    picturebox.BorderStyle = BorderStyle.None;
            if (this.Check_image1.Image == null)
            {
                this.Check_image1.Image = picturebox.Image;
                Code += picturebox.Tag;
            }
            else
                if (this.Check_image2.Image == null)
                {
                    this.Check_image2.Image = picturebox.Image;
                    Code += picturebox.Tag;
                }
                else
                    if (this.Check_image3.Image == null)
                    {
                        this.Check_image3.Image = picturebox.Image;
                        Code += picturebox.Tag;
                    }
                    else
                        if (this.Check_image4.Image == null)
                        {
                            this.Check_image4.Image = picturebox.Image;
                            Code += picturebox.Tag;
                        }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            if (this.Check_image4.Image != null)
            {
                this.Check_image4.Image = null;
                Code = Code.Substring(0, Code.Length - 1);
            }
            else
                if (this.Check_image3.Image != null)
                {
                    this.Check_image3.Image = null;
                    Code = Code.Substring(0, Code.Length - 1);
                }
                else
                    if (this.Check_image2.Image != null)
                    {
                        this.Check_image2.Image = null;
                        Code = Code.Substring(0, Code.Length - 1);
                    }
                    else
                        if (this.Check_image1.Image != null)
                        {
                            this.Check_image1.Image = null;
                            Code = Code.Substring(0, Code.Length - 1);
                        }
        }

        private void button_check_Click(object sender, EventArgs e)
        {
            if(CheckCode.fCheckCode(this.pictureBox_CheckCode.Tag.ToString(),Code))
                MessageBox.Show("验证成功，你也是笨蛋！");
            else
                MessageBox.Show("验证失败，你是笨蛋！");
        }


        //此下动画
        private void Image1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BorderStyle = BorderStyle.None;
        }

        private void Image1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void Image1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox picturebox = (PictureBox)sender;
            picturebox.BorderStyle = BorderStyle.None;
        }
    }
}
