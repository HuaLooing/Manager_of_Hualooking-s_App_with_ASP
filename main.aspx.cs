using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void logini()
    {
        string str = ConfigurationManager.ConnectionStrings["userConnectionString"].ToString();
        SqlConnection conn = new SqlConnection();
        conn.Open();
        string sql = "select * from student where ID = @userName and Password = @password";
        SqlCommand comm = new SqlCommand(sql, conn);
        comm.Parameters.Add("userName", TextBox1.Text);
        comm.Parameters.Add("password", TextBox2.Text);
        SqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            // lblMessage.Text = "登录成功";//调试语句，正式使用时删除
            Session["userName"] = TextBox1.Text;
            Response.Write("<script>location.href='index.aspx';</script>");

            //创建session
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误');</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //queryUserInfo();  
        logini();
    }
}