using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    public void logini()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        string sql = "select * from administrator where Administrator_ID = @userName and Password = @passWord";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", TextBox1.Text);
        comm.Parameters.Add("passWord", TextBox2.Text);
        conn.Open();
        comm.ExecuteNonQuery();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            // lblMessage.Text = "登录成功";//调试语句，正式使用时删除 
            Session["userName"] = TextBox1.Text;
            Session["act"] = sdr["act"].ToString();
            Response.Write("<script>location.href='index.aspx';</script>");
            WriteTextLog("管理员登录", TextBox1.Text);
            //创建session
        }
        else
        {
            Response.Write("<script>alart('用户名或密码错误')</script>");

            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //queryUserInfo();  
        logini();
    }

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