using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Manager_of_Hualooking_s_App_with_ASP_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void Insert()
    {
        string str = "server=250826a1.nat123.cc;port=48732;user id=root;password=970527j;database=demo";
        MySqlConnection conn = new MySqlConnection(str);


        string sql = "INSERT INTO `demo`.`event` (`Name`, `Date`, `Grade1`, `Grade2`, `Grade3`, `Grade4`, `Number_linit`, `Hoster`, `Content`) VALUES (`@Name`, `@Date`, `@Grade1`, `@Grade2`, `@Grade3`, `@Grade4`, `@Number_linit`, `@Hoster`, `@Content`);";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("Name", In_Name.Text);
        comm.Parameters.Add("Date", In_Date.Text);
        comm.Parameters.Add("Time", In_Hour.Text + ":" + In_Minutes);
        if (grade1.Checked) comm.Parameters.Add("Grade1", "1"); else comm.Parameters.Add("Grade1", "0");
        if (grade2.Checked) comm.Parameters.Add("Grade2", "1"); else comm.Parameters.Add("Grade2", "0");
        if (grade3.Checked) comm.Parameters.Add("Grade3", "1"); else comm.Parameters.Add("Grade3", "0");
        if (grade4.Checked) comm.Parameters.Add("Grade4", "1"); else comm.Parameters.Add("Grade4", "0");
        comm.Parameters.Add("Number_Limit", In_Limit.Text);
        comm.Parameters.Add("Hoster", In_Hoster.Text);
        comm.Parameters.Add("Content", In_Content.Text);

        conn.Open();
        comm.ExecuteNonQuery();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            // lblMessage.Text = "登录成功";//调试语句，正式使用时删除 
            Response.Write("<script>alart('创建活动成功');</script>");

            //创建session
        }
        else
        {
            Response.Write("<script>alart('错误代码1')</script>");

            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Response.Write("<script>alart('什么鬼');</script>");
        if (In_Name.Text == "")
            In_Name.CssClass = "form-control error";
        else if (In_Date.Text == "")
            In_Date.CssClass = "form-control error";
        else if (In_Hour.Text == "" || Convert.ToInt32(In_Hour.Text) > 24 || Convert.ToInt32(In_Hour.Text) < 0)
            In_Hour.CssClass = "form-control error";
        else if (In_Minutes.Text == "" || Convert.ToInt32(In_Minutes.Text) > 59 || Convert.ToInt32(In_Minutes.Text) < 0)
            In_Minutes.CssClass = "form-control error";
        else if (In_Limit.Text == "")
            In_Limit.Text = "999";
        else if (In_Hoster.Text == "")
            In_Hoster.CssClass = "form-control error";
        else if (In_Content.Text == "")
            In_Content.CssClass = "form-control error";
        else
            Insert();
        
    }
}