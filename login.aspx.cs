using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data.MySqlClient;

public partial class main : System.Web.UI.Page
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
            Session["userName"] = sdr["Name"].ToString();
            Session["act"] = sdr["Act"].ToString();
            Response.Write("<script>location.href='index.aspx';</script>");
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
}