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
using System.Data.OleDb;



namespace ftpSwitch
{
    public partial class Form1 : Form
    {
        string ftpServerIP;
        string ftpObjIp;
        string[] ftpPassword = { "", "asd123", "111", "1", "aaa", "123456", " " };
        string FS;
        bool trystate = true;
        bool is_con = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("IP"))
            {
                textBox1.Text="";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ftpServerIP = textBox1.Text;
            ftpObjIp = textBox2.Text;
            bool EF = true;
            if (ValidateIPAddress(ftpServerIP) && ValidateIPAddress(ftpObjIp))
            {
                int check = 0;
                long che = 0;
                int checkObj = 0;
                string sta = boom(ftpServerIP.Split('.'));
                
                string obj = boom(ftpObjIp.Split('.'));

                //string sta = ftpServerIP.Replace(".", "");
                //string obj = ftpObjIp.Replace(".", "");
                check = int.Parse(sta.Substring(sta.Length - 3, 3));
                checkObj = int.Parse(obj.Substring(obj.Length - 3, 3));
                che = System.Math.Abs(long.Parse(sta) - long.Parse(obj));
                if (che >= 255)
                {
                    MessageBox.Show("这都跨网段了，目标小一点吧");
                    return;
                }
                string ip = ftpServerIP;
                while (System.Math.Abs(check - checkObj) >= 0 && EF)
                {
                  
                    ShowMsg("尝试匿名登陆");
                    if(is_con)
                        FtpBySocket(ip, "", "");
                    if (!trystate)
                    {
                        if (is_con)
                        {
                            foreach (string psw in ftpPassword)
                            {
                                FtpBySocket(ip, "test", psw);
                                if (trystate) break;
                                if (!is_con) break;
                            }
                        }
                    }
                    che--;
                    if (string.Equals(ip, ftpObjIp))
                    {
                        EF = false;
                    }
                    else
                    {
                        ip = strsub(ip);
                        is_con = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("IP输入格式不对哟，看看是不是输错了");
            }

            /*
             * 本部分为直接使用FtpWebRequest的版本，如有需要将上面代码注释留下本部分即可
             * 
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
                IPAddress ip = IPAddress.Parse(Ip);
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
                trystate = false;
                is_con = false;
                ShowMsg("\r\n 连接发生错误 --> " + ex.Message);
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


            if (str.Contains("530") || str.Contains("501") || str.Contains("331") || str.Contains("503"))
            {
                trystate = false;

            }
            else
            {
                trystate = true;
            }


        }

        void ChangeFS(string str)
        {
            FS = str;
        }


        private static string connStr = @"Provider = Microsoft.Ace.OLEDB.12.0;Data Source = C:\Users\lflx1\source\repos\ftpSwitch\dbs\ftpfinder.mdb";
        void DB()
        {
            try
            {
                OleDbConnection oleDb = new OleDbConnection(connStr);
                MessageBox.Show(oleDb.DataSource);
            }
            catch
            {

            }
        }

        private void StateShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string boom(string[] strings)
        {
            string str="";
            foreach (string s in strings)
            {
                switch (s.Length)
                {
                    case 1:
                        str += "00" + s;
                        break;
                    case 2:
                        str += "0" + s;
                        break;
                    case 3:
                        str += s;
                        break;
                }
            }
            return str;
        }
        public string strsub(string str)
        {
            string st = "";
            string[] s= str.Split('.');

            for(int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    st += (int.Parse(s[i]) + 1).ToString();
                }
                else
                {
                    st += s[i]+".";
                }
            }
            return st;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Contains("IP"))
            {
                textBox2.Text = "";
            }
        }
    }

}
