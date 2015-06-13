using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace _126邮箱SMTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSendPerson.Text == "")
            {
                MessageBox.Show("发送人不能为空！");
                return;
            }
            if (txtRecivePerson.Text == "")
            {
                MessageBox.Show("收件人不能为空！");
                return;
            }
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.To.Add(txtRecivePerson.Text);
            //这个地方可以发送给多人，但是没有实现，可以用“，”分割，之后取得每个收件人的地址。
            //也可以抄送给多人。
            msg.From = new MailAddress(txtSendPerson.Text);
            if (txtSubject.Text != "")
            {
                msg.Subject = txtSubject.Text;
            }
            else
            {
                msg.Subject = "未填写主题！";
                MessageBox.Show("真的不需要填写主题吗！");
            }
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码
            msg.Body = txtContent.Text;
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码
            msg.IsBodyHtml = false;
            msg.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(txtSendPerson.Text, txtPassword.Text);
            //client.Host = "localhost";//这个发布出去啊。应该是当做了垃圾邮件了。
            client.Host = "smtp.126.com";
            object userState = msg;
            try
            {
                client.SendAsync(msg, userState);
                MessageBox.Show("发送成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "邮件发送出错！");
            }

        }
    }
}
