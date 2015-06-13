using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace MyText
{
    class MyTextBox:TextBox
    {
        private string tips = ""; //保存提示信息
        private Color TipColor = Color.LightGray; //提示文字颜色
        private Color OldColor;  //文字的颜色
        private Color backColor = Color.Red;  //背景色       
        private Color oldBackColor;
       

        //属性
        [Category("Appearance"), Description("水印文字")]
        public string WaterTips
        {
            get { return tips; }
            set
            {
                tips = value;
                SetTipsText();
                Invalidate();
            }
        }

        [Category("Appearance"), Description("文字颜色")]
        public Color WaterTipsColor
        {
            get { return TipColor; }
            set
            {
                TipColor = value;
                Invalidate();
            }
        }

        [Category("Appearance"), Description("背景颜色")]
        public Color TipsBackColor
        {
            get { return backColor; }
            set
            { 
                backColor = value;
                Invalidate();
            }
        }
        public MyTextBox()
        {
            oldBackColor = base.BackColor;
            OldColor = base.ForeColor;
            base.Enter += MyText_Enter;
            base.Leave += MyText_Leave;
            base.TextChanged += MyText_TextChanged;
            base.Click += MyText_Enter;
        }

        private void SetTipsText()  //写文字
        {
            if (base.Text == "" || base.Text ==WaterTips )   
            {
                base.Text = tips;
                base.ForeColor = TipColor;
            }
            else
            {
                base.ForeColor = OldColor;
            }
        }

        //事件
        private void MyText_Enter(object sender, EventArgs e)
        {
            if (base.Text == WaterTips)
            {
                base.Text = "";  
            }
            base.BackColor = backColor;
        }

        private void MyText_Leave(object sender, EventArgs e)
        {
            SetTipsText();
            base.BackColor = oldBackColor;
        }

        private void MyText_TextChanged(object sender, EventArgs e)
        {
            if (base.Text != WaterTips && base.Text.Length > 0)
            {
                base.ForeColor = OldColor;
            }
            else
            {
                base.ForeColor = TipColor;
            }
        }
        
    }
}
