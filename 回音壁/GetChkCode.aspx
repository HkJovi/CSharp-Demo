<%@ Page Language="C#" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Drawing.Imaging" %>

<script runat="server">
    /// <summary>
    /// 函数功能为返回一个随机的验证码串，将设置Session的相应值为这个串
    /// </summary>
    /// <param name="SessionName"></param>
    /// <returns></returns>
    private string GenerateCheckCode(string SessionName)
    {
        int number;
        char code;
        string checkCode = String.Empty;

        Random random = new Random();
/* 生成包含大写字母和数字的就用这段
        for (int i = 0; i < 5; i++)
        {
            number = random.Next();

            if (number % 2 == 0)
                code = (char)('0' + (char)(number % 10));
            else
                code = (char)('A' + (char)(number % 26));

            checkCode += code;
        }
*/
        for (int i = 0; i < 4; i++)
        {
            number = random.Next();

            code = (char)('0' + (char)(number % 10));
            
            checkCode += code;
        }

        Session[SessionName] = checkCode;
        return checkCode;
    }

    private void CreateCheckCodeImage(string checkCode)
    {
        Bitmap image = new Bitmap((int)Math.Ceiling(checkCode.Length * 12.5), 22);    //图片的高和宽
        Graphics g = Graphics.FromImage(image);

        try
        {
            //生成随机生成器
            Random random = new Random();

            //清空图片背景色
            g.Clear(Color.White);

            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(checkCode, font, brush, 2, 2);

            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);

                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }

            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Gif);
            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.Form["AddCode"]) == false)
        {
            BLL.AddCode(Request.Form["AddCode"]);
            return;
        }
        
        Response.ClearContent();
        Response.Expires = -1;
        Response.ContentType = "image/gif";
        
        CreateCheckCodeImage(GenerateCheckCode("chkcode"));
    }
</script>