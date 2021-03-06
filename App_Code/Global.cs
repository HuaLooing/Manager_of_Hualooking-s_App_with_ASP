﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Global 的摘要说明
/// </summary>
public partial class Global : System.Web.HttpApplication
{
    public Global()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    void Application_Start(object sender, EventArgs e)
    {
        //WriteTextLog("应用启动", DateTime.Now.ToString("hh:mm:ss"));
        AcessToken_Firsttime();
        System.Timers.Timer myTimer = new System.Timers.Timer(1000);
        myTimer.Elapsed += new System.Timers.ElapsedEventHandler(AcessToken);
        myTimer.Interval = 10 * 60 * 1000;
        myTimer.Enabled = true;

        // 在应用程序启动时运行的代码
    }
    void Application_End(object sender, EventArgs e)
    {
        wakeup();
        //WriteTextLog("应用关闭", DateTime.Now.ToString("hh:mm:ss"));
        // 在应用程序关闭时运行的代码
        
    }
    void Application_Error(object sender, EventArgs e)
    {
        // 在出现未处理的错误时运行的代码
    }
    void Session_Start(object sender, EventArgs e)
    {

        // 在新会话启动时运行的代码
    }
    void Session_End(object sender, EventArgs e)
    {
        
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
    }

    //唤醒应用
    public void wakeup()
    {   
        string strUrl = "http://hlghd.cczu.edu.cn/login.aspx";
        HttpWebRequest _HttpWebRequest = (HttpWebRequest)WebRequest.Create(strUrl);
        HttpWebResponse _HttpWebResponse = (HttpWebResponse)_HttpWebRequest.GetResponse();
        Stream _Stream = _HttpWebResponse.GetResponseStream();//得到回写的字节流
        _HttpWebResponse.Close();
    }
    public void AcessToken_Firsttime()
    {
        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxd813cf0c8c5b4b8a&secret=b2edd1283451a2aa0fc4849caec86b82";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "text/xml";
        Stream reqstream = request.GetRequestStream();
        //声明一个HttpWebRequest请求
        request.Timeout =  20*1000;
        //设置连接超时时间
        request.Headers.Set("Pragma", "no-cache");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream streamReceive = response.GetResponseStream();
        Encoding encoding = Encoding.UTF8;

        StreamReader streamReader = new StreamReader(streamReceive, encoding);
        string s = streamReader.ReadToEnd();
        int s1 = s.IndexOf("access_token");
        int s2 = s.IndexOf("expires_in");
        //Console.WriteLine(s);
        if (s.IndexOf("errcode") == -1 && s1 != -1 & s2 != -1)
        {
            Application["AcessToken"] = s.Substring(s1 + 15, s2 - s1 - 18);
            //WriteTextLog("AccessToken", Application["AcessToken"].ToString());
            //创建openid的session
        }
        else
        {
            WriteTextLog("AccessToken失败获取", s);
        }

    }

    //获取AccessToken，每分钟获取一次
    public void AcessToken(object source, System.Timers.ElapsedEventArgs e)
    {
        wakeup();
        //WriteTextLog("AccessToken", "定时获取");
        string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxd813cf0c8c5b4b8a&secret=b2edd1283451a2aa0fc4849caec86b82";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "text/xml";
        Stream reqstream = request.GetRequestStream();
        //声明一个HttpWebRequest请求
        request.Timeout = 9 * 1000;
        //设置连接超时时间
        request.Headers.Set("Pragma", "no-cache");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream streamReceive = response.GetResponseStream();
        Encoding encoding = Encoding.UTF8;

        StreamReader streamReader = new StreamReader(streamReceive, encoding);
        string s = streamReader.ReadToEnd();
        int s1 = s.IndexOf("access_token");
        int s2 = s.IndexOf("expires_in");
        //Console.WriteLine(s);
        if (s.IndexOf("errcode") == -1 && s1 != -1 & s2 != -1)
        {
            Application["AcessToken"] = s.Substring(s1 + 15, s2 - s1 - 18);
            //WriteTextLog("AccessToken成功获取", s);
            //创建openid的session
        }
        else
        {
            WriteTextLog("AccessToken失败获取", s);
        }

    }

    protected static void WriteTextLog(string action, string strMessage)
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "insert into log (logaction,logcont,ip) values(@l1,@l2,@l3)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("l1", action);
        comm.Parameters.Add("l2", strMessage);
        comm.Parameters.Add("l3", DateTime.Now.ToString("HH:mm:ss"));
        //comm.Parameters.Add("l4", DateTime.Now.ToString("HH:mm:ss")); 
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
    }
}