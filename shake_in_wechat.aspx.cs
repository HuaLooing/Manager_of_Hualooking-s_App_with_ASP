using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

public partial class shake_in_wechat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        div1.Style["Display"] = "None";//block为显示
        div2.Style["Display"] = "Block";
        
        if (!Request.UserAgent.ToLower().Contains("micromessenger"))
        {
            Response.Write("<script>location.href='pages/fail.html';</script>");
        }
        else
        {
            //WriteTextLog("加载摇一摇", Request["ticket"]);
            get_openid();          
        }
        
    }
    //从网页ticket获取openid
    protected void get_openid()
    {
        //获取网页ticket
        string ticket = Request["ticket"];
        //构建url
        string url = "https://api.weixin.qq.com/shakearound/user/getshakeinfo?access_token=" + Application["AcessToken"].ToString();
        //发送post数据
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ReadWriteTimeout = 10 * 1000;
        //构建post的json
        String postStr = "{\"ticket\":\"" + ticket + "\",\"need_poi\":1}";
        byte[] data = Encoding.UTF8.GetBytes(postStr);
        request.ContentLength = data.Length;
        Stream myRequestStream = request.GetRequestStream();
        myRequestStream.Write(data, 0, data.Length);
        myRequestStream.Close();
        //接收json数据包
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        string s = myStreamReader.ReadToEnd();
        int s1 = s.IndexOf("openid");
        int s2 = s.IndexOf("page_id");
        if(s1!=-1&&s2!=-1)
        {
            Session["Shake_openid"] = s.Substring(s1 + 9, s2 - s1 - 12);
            //WriteTextLog("加载摇一摇", s);
            check_event();
        }
        else
        {
            WriteTextLog("摇一摇失败", s);
            Session["Shake_openid"] = "-1";
            Response.Write("<script>location.href='pages/fail3.html';</script>");
        }
        
    }

    protected void check_event()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "SELECT ID,Name,Date,DATE_FORMAT(Date,'%H:%m') as Time from event as u where u.Date-now()<=1500 and u.Date-now()>=0 and u.id in (select id from sign as v where id=u.id and v.Student_ID=(select Student_ID from student as h where h.openid=@openid))";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("@openid", Session["Shake_openid"].ToString());
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            div1.Style["Display"] = "Block";
            div2.Style["Display"] = "None";
            Label1.Text = sdr["Name"].ToString();
            Label2.Text = sdr["Time"].ToString();
        }
        else
        {
            div1.Style["Display"] = "None";
            div2.Style["Display"] = "Block";
        }
    }
    //记录log
    protected static void WriteTextLog(string action, string strMessage)
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "insert into log (logaction,logcont,ip) values(@l1,@l2,@l3)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("l1", action);
        comm.Parameters.Add("l2", strMessage);
        comm.Parameters.Add("l3", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
    }
}