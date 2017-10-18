using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class login_in_wechat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //加感叹号！！！
        if (!Request.UserAgent.ToLower().Contains("micromessenger"))
        {
            Response.Write("<script>location.href='pages/fail.html';</script>");
        }
        if (Session["openid"] == null)//查询openid是否存在
        {     
            //返回event页面获取openid存入session
            Response.Write("<script>location.href='https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd813cf0c8c5b4b8a&redirect_uri=http%3A%2F%2Fhlghd.cczu.edu.cn%2Fevent_in_wechat.aspx&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect';</script>");
        }

        //Label1.Text = Session["openid"].ToString();
    }
    //校验用户名和密码
    protected void Login()
    {
        System.Diagnostics.Debug.WriteLine("登录中");
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        Session["stu_id"] = TextBox1.Text;
        string sql = "select * from student where Student_ID = @userName and Password = @passWord";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", TextBox1.Text);
        comm.Parameters.Add("passWord", TextBox2.Text);
        conn.Open();
        if (comm.ExecuteNonQuery()!=0)
        {
            check_openid();
        }
        else
        {
            Response.Write("<script>swall('用户名或密码错误')</script>");
        }
        conn.Close();
    }
    //检查账号绑定的openid是否和本机相同
    protected void check_openid()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        Session["stu_id"] = TextBox1.Text;
        string sql = "select * from student where Student_ID = @userName";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", TextBox1.Text);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            if(sdr["openid"].ToString()==Session["openid"].ToString())
                Response.Write("<script>location.href='https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd813cf0c8c5b4b8a&redirect_uri=http%3A%2F%2Fhlghd.cczu.edu.cn%2Fevent_in_wechat.aspx&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect';</script>");
            else if(sdr["openid"].ToString()=="")
                insert_openid();
            else
                Response.Write("<script>location.href='pages/fail2.html';</script>");
        }
        else
        {
            
            WriteTextLog("登录检查错误", "学生id:" + Session["stu_id"].ToString() + "openid:" + Session["openid"].ToString());
            //Label1.Text = "用户名或密码错误";
            //Response.Write("<script>alart('用户名或密码错误')</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }
    //将openid插入学生记录中
    protected void insert_openid()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "update student set openid = @opid where Student_ID = @userName";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        comm.Parameters.Add("opid", Session["openid"].ToString());
        conn.Open();
        if (comm.ExecuteNonQuery()!=0)
        {
            //Label1.Text = "插入openid成功";
            WriteTextLog("openid绑定成功", "学生id:" + Session["stu_id"].ToString());
            Response.Write("<script>location.href='https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxd813cf0c8c5b4b8a&redirect_uri=http%3A%2F%2Fhlghd.cczu.edu.cn%2Fevent_in_wechat.aspx&response_type=code&scope=snsapi_base&state=STATE#wechat_redirect';</script>");
        }
        else
        {
            WriteTextLog("openid更新失败", "学生id:" + Session["stu_id"].ToString()+ "openid:"+ Session["openid"].ToString());
            Response.Write("<script>swall('微信联合登录失败');</script>");
            //Label1.Text = "插入openid失败";
            // Response.Write("<script>alart('失败，错误代码01')</script>");
        }
    }
    //按钮事件
    protected void Button1_Click(object sender, EventArgs e)
    {
        Login();
    }
    //记录日志
    protected static void WriteTextLog(string action, string strMessage)
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "insert into log (logaction,logcont) values(@l1,@l2)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("l1", action);
        comm.Parameters.Add("l2", strMessage);
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
    }

}