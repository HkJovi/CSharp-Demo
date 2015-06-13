using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace clock1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region [ToolStripMenu�˵�]
            #region [ToolStripMenu�˵����˳�]
        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notifyIcon1.Dispose();//����notifyIcon������ͼ�껹��
            this.Close();//�رճ���
        }
        #endregion

            #region[ToolStripMenuItem�����ò˵�]
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;//�ָ���ʾ������
            this.WindowState = FormWindowState.Normal;//����ָ�Ϊ����
        }
        #endregion
        #endregion

        #region [������Ϣ��������]
        public void set_messageshowtext()
        {
            if (tm_set == "")
            {
                tm_set = "����˵�ˣ���Ҫ���ҵ绰��";
            }
            this.notifyIcon1.ShowBalloonTip(1000, st_endtime, tm_set, ToolTipIcon.Info);//NotifyIcon.ShowBalloonTip����:ʱ��,����,�ı�,ͼ��;
        }
        #endregion

        #region [��̬��ʾʱ��Timer��Ticker�¼�]
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbl_showTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region [Ӧ�ð�ť�¼�]
        private void btn_setyy_Click(object sender, EventArgs e)
        {
            if (btn_setyy.Text == "��������")
            {
                this.btn_setyy.Text = "��ʼ����ʱ";
                notifyIcon1.Text = "";//���������ʾ
                timer2.Enabled = true;//���ö�ʱ����Ч
                set_clock_setting();//�����������ó���
            }
            else
            {
                set_clock_setting();//�����������ó���
            }
        }
        #endregion

        #region [������������]
        public void set_clock_setting()
        {
            tm_set = this.ttx_set_message.Text.Trim().ToString();//��ȡ�ı�������ʾ����
            string st_systime = DateTime.Now.ToString();//��ȡϵͳʱ��Ϊstring��ʽ
            st_endtime = dtp_input_time.Text;//��ȡ����ʱ��Ϊstring��ʽ
            DateTime DT_sys_time = Convert.ToDateTime(st_systime);//��ȡ��ǰϵͳʱ��
            DateTime DT_end_time = Convert.ToDateTime(st_endtime);//��dtp_input_time��ȡ����ʱ��
            TimeSpan ts_systime = new TimeSpan(DT_sys_time.Ticks);//ת��ϵͳʱ��Ϊ�ɱȽ�����
            TimeSpan ts_endtime = new TimeSpan(DT_end_time.Ticks);//ת������ʱ��Ϊ�ɱȽ�����
            TimeSpan ts_leasttime = ts_endtime.Subtract(ts_systime).Duration();//����ʱ���ȥ��ʼʱ��
            uint dd = Convert.ToUInt32(ts_leasttime.Days);//��ȡʣ��ʱ�������
            uint hh = Convert.ToUInt32(ts_leasttime.Hours);//��ȡʣ��ʱ���Сʱ
            uint mm = Convert.ToUInt32(ts_leasttime.Minutes);//��ȡʣ��ʱ��ķ���
            uint ss = Convert.ToUInt32(ts_leasttime.Seconds);//��ȡʣ��ʱ�����
            Remainder = dd * 24 * 3600 + hh * 3600 + mm * 60 + ss;//��ʱ��ת��Ϊ��
            //this.lbl_settime.Text = ts_leasttime.ToString();//������
            //this.lbl_message.Text = st_endtime;//������
            this.lbl_show_endtime.Visible = true;//ʣ��ʱ�䵹��ʱ��ʾ
            this.lbl_systemtime.Visible = true;//ϵͳ��ǰʱ��
        }
        #endregion

        #region [��������ʱ��Timer��Tick�¼�]
        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_systemtime.Text = "ϵͳʱ��Ϊ��"+DateTime.Now.ToLongTimeString();//ֻ��ʾʱ�䣬����ʾ����
            Remainder--;//ʣ�������ݼ�
            Dayss = Remainder / 86400;//��������
            Hours = (Remainder-Dayss*86400) / 3600;//����Сʱ
            minute = (Remainder - Dayss * 86400 - Hours * 3600) / 60;//�������
            sencond = Remainder%60;//������
            if (Remainder <0)
            {
                lbl_show_endtime.Text = "����ʱδ��ʼ";
            }
            if (sencond < 10)
            {
                lbl_show_endtime.Text = "ʣ��ʱ�䣺" + Dayss + "��" + Hours + "Сʱ" + minute + "��0" + sencond + "��";
                notifyIcon1.Text = "ʣ��ʱ�䣺" + Dayss + "��" + Hours + "Сʱ" + minute + "��0" + sencond + "��";
            }
            else
            {
                lbl_show_endtime.Text = "ʣ��ʱ�䣺" + Dayss + "��" + Hours + "Сʱ" + minute + "��" + sencond + "��";
                notifyIcon1.Text = "ʣ��ʱ�䣺" + Dayss + "��" + Hours + "Сʱ" + minute + "��" + sencond + "��";
            }
            if (Remainder == 0)
            {
                timer2.Enabled = false;
                lbl_show_endtime.Text += "---ʱ�䵽��";
                notifyIcon1.Text += "---ʱ�䵽��";
                btn_setyy.Text = "��������";
                lbl_systemtime.Visible = false;//����ʾϵͳʱ��
                set_messageshowtext();
            }
        }
        #endregion

        #region [���ش������]
        public void function_hideForm()
        {
            this.ShowInTaskbar = false;//���ô���������Ϊ����
            this.WindowState = FormWindowState.Minimized;//���ô���Ϊ��С��
        }
        #endregion

        #region [���ذ�ť�¼�����]
        private void btn_close_Click(object sender, EventArgs e)
        {
            function_hideForm();
        }
        #endregion
    }
}