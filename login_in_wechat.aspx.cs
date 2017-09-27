using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login_in_wechat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //加感叹号！！！

        if (!Request.UserAgent.ToLower().Contains("micromessenger"))
        {
            Response.Write("<script>location.href='fail.html';</script>");
        }
        else if (Session["openid"] == null)//查询openid是否存在
        {

            //返回event页面获取openid存入session
            Response.Write("<script>location.href='event_in_wechat.aspx';</script>");
        }

    }

    protected void Login()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        Session["stu_id"] = TextBox1.Text;
        string sql = "select * from student where Student_ID = @userName and Password = @passWord";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", TextBox1.Text);
        comm.Parameters.Add("passWord", TextBox2.Text);
        conn.Open();
        comm.ExecuteNonQuery();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            // lblMessage.Text = "登录成功";//调试语句，正式使用时删除 
            insert_openid();
        }
        else
        {
            Response.Write("<script>alart('用户名或密码错误')</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void insert_openid()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);


        string sql = "insert into student (Openid) Values(@opid) where Student_ID = @userName";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        comm.ExecuteNonQuery();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            Response.Write("<script>location.href='event_in_wechat.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alart('失败，错误代码01')</script>");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Login();
    }
}