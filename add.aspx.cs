using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class add : System.Web.UI.Page
{
    string hour, minutes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
        
    }

    protected void Insert()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        string sql = "INSERT INTO demo.event (Name, Date, Grade1, Grade2, Grade3, Grade4, Number_limit, Hoster, Content, Kind, Grade) VALUES (@Name, @Date, @Grade1, @Grade2, @Grade3, @Grade4, @Number_Limit, @Hoster, @Content, @Kind ,@Grade);";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("Name", In_Name.Text);
        comm.Parameters.Add("Date", In_Date.Text);
        if (grade1.Checked) comm.Parameters.Add("Grade1", "1"); else comm.Parameters.Add("Grade1", "0");
        if (grade2.Checked) comm.Parameters.Add("Grade2", "1"); else comm.Parameters.Add("Grade2", "0");
        if (grade3.Checked) comm.Parameters.Add("Grade3", "1"); else comm.Parameters.Add("Grade3", "0");
        if (grade4.Checked) comm.Parameters.Add("Grade4", "1"); else comm.Parameters.Add("Grade4", "0");
        comm.Parameters.Add("Number_Limit", In_Limit.Text);
        comm.Parameters.Add("Hoster", In_Hoster.Text);
        comm.Parameters.Add("Content", In_Content.Text);
        comm.Parameters.Add("Kind", In_Kind.Text);
        comm.Parameters.Add("Grade", In_Grade.Text);
        conn.Open();
        int n=(int)comm.ExecuteNonQuery();
        if (n!=0)
        {
            Response.Write("<script>alert('添加活动成功，3秒后跳转到管理页面');</script>");
            Response.Write("<script language=\"javascript\">setTimeout(location.href='manage.aspx',3000)</script>");
        }
        else
        {
            Response.Write("<script>alert('错误代码1')</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        bool flag = true;
        if (In_Name.Text == "")
        { In_Name.CssClass = "form-control error"; flag = false; }
        if (In_Date.Text == "")
        { In_Date.CssClass = "form-control error"; flag = false; }
        if (In_Limit.Text == "")
        { In_Limit.Text = "999"; }
        if (In_Hoster.Text == "")
        { In_Hoster.CssClass = "form-control error"; flag = false; }
        if (In_Content.Text == "")
        { In_Content.CssClass = "form-control error"; flag = false; }
        if (In_Kind.Text == "")
        { In_Kind.CssClass = "form-control error"; flag = false; }
        if (In_Grade.Text == "")
        { In_Grade.CssClass = "form-control error"; flag = false; }
        if (flag==true)
            Insert();
        else
            Response.Write("<script>alert('红色项未填写')</script>");


    }
}