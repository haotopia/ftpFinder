using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Threading;


namespace ftpSwitch
{
    public partial class Form1 : Form
    {
        string ftpServerIP;
        string[] ftpPassword = { "", "asd123", "111", "1", "aaa", " ", "123456" };
        string FS;
        bool trystate = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ftpServerIP = textBox1.Text;

            if (ValidateIPAddress(ftpServerIP))
            {
                ShowMsg("尝试匿名登陆");
                FtpBySocket(ftpServerIP, "", "");
                if (!trystate)
                {
                    foreach (string psw in ftpPassword)
                    {
                        FtpBySocket(ftpServerIP, "test", psw);
                        if (trystate) break;
                    }
                }
            }
            else
            {
                MessageBox.Show("IP输入格式不对哟，看看是不是输错了");
            }

            /*
            if (ValidateIPAddress(ftpServerIP))
            {
                int i = 0;
                StateShow.Text += "\r\n开始尝试匿名连接";
                if (TryFtp(ftpServerIP, "", ""))
                {
                    StateShow.Text += "\r\n 匿名登陆成功";
                    
                }
                else
                {
                    StateShow.Text += "\r\n 匿名登陆已关闭，尝试简单密码登陆";
                }
                while (!TryFtp(ftpServerIP, "test", ftpPassword[i])&&i<7)
                {
                    StateShow.Text += "\r\n 本次尝试-->用户名：test  ，密码：" + ftpPassword[i];
                    if(i<6)
                    i++;
                }
                if (i >= 7)
                    StateShow.Text += "\r\n 简单密码尝试完毕，未找到匹配密码 " + i;
                else
                    StateShow.Text += "\r\n 扫描成功，用户名：test  密码：" + ftpPassword[i] + " \r\n";

            }
            else
            {
                MessageBox.Show("IP输入格式不对哟，看看是不是输错了");
            }
            */


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Easy.Checked = true;
            StateShow.Text = "";

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public static bool ValidateIPAddress(string ipAddress)
        {
            Regex validipregex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
            return (ipAddress != "" && validipregex.IsMatch(ipAddress.Trim())) ? true : false;
        }

        public bool TryFtp(string Ip, string User, string password)
        {
            bool state = true;
            FtpWebRequest reqFtp;
            reqFtp = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/"));
            try
            {

                //测试ftp是否成功
                reqFtp.Credentials = new NetworkCredential(User, password);
                reqFtp.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFtp.KeepAlive = false;
                reqFtp.Timeout = 1000;
                FtpWebResponse response = (FtpWebResponse)reqFtp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                state = false;
                StateShow.Text += "\r\n 发生错误 --> " + ex.Message;
            }


            return state;
        }
        Socket socket;
        public int FtpBySocket(string Ip, string User, string Password, string Port = "21")
        {

            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(ftpServerIP);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32("21"));
                socket.Connect(point);
                ShowMsg("端口开启");
                Received();

                socket.Send(Encoding.Default.GetBytes(string.Format("{0}{1}", "USER " + User, Environment.NewLine)));
                Received();
                socket.Send(Encoding.Default.GetBytes(string.Format("{0}{1}", "PASS " + Password, Environment.NewLine)));
                Received();
            }
            catch (Exception ex)
            {
                ShowMsg("\r\n 发生错误 --> " + ex.Message);
            }


            return 0;
        }

        void ShowMsg(string str)
        {
            StateShow.AppendText(str + "\r\n");
        }
        void Received()
        {


            byte[] buffer = new byte[1024 * 1024 * 3];
            //实际接收到的有效字节数
            int len = socket.Receive(buffer);

            string str = Encoding.UTF8.GetString(buffer, 0, len);
            ShowMsg(socket.RemoteEndPoint + ":" + str);


            if ((str.Contains("530") || str.Contains("501") || str.Contains("331")))
            {
                trystate = false;


            }


        }

        void ChangeFS(string str)
        {
            FS = str;
        }

    }

}
