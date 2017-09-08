using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class event_m : System.Web.UI.Page
{
    string strid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["delete"].Equals(true))
        {
            Session["delete"] = false;
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        strid = Request["id"];
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
        else if (Request["action"] == "modify")
        {
            if(Session["refresh"].Equals(true))
                Add();
        }
        if (Request["action"] == "delete" && Session["Act"].ToString() == "0")
        {
            if (Session["refresh"].Equals(true))
                Add();
            //更改按钮
            Submit.CssClass = "btn btn-warning btn-fill btn-wd";
            Submit.Text = "删除";
            //禁用textbox
            foreach (Control ctl in this.Controls[1].Controls)
            {
                if (ctl.GetType().Name == "textbox")
                {
                    TextBox tb = new TextBox();
                    tb = (TextBox)this.FindControl(ctl.ID);
                    tb.Enabled = false;
                }
            }
            grade1.Enabled = false;
            grade2.Enabled = false;
            grade3.Enabled = false;
            grade4.Enabled = false;
        }
        else if(Request["action"] == "delete")
        {
            Response.Write("<script>alert('当前用户不能删除项目！');</script>");
            Response.Write("<script language=\"javascript\">setTimeout(location.href='index.aspx',3000)</script>");
        }
        Session["refresh"] = false;

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        
        if (Request["action"] == "delete")
        {
            Delete();
        }
        else
        {
            bool flag = true;
            if (In_Name.Text == "")            { In_Name.CssClass = "form-control error"; flag = false; }
            if (In_Date.Text == "")            { In_Date.CssClass = "form-control error"; flag = false; }
            if (In_Limit.Text == "")            { In_Limit.Text = "999"; }
            if (In_Hoster.Text == "")            { In_Hoster.CssClass = "form-control error"; flag = false; }
            if (In_Content.Text == "")            { In_Content.CssClass = "form-control error"; flag = false; }
            if (In_Kind.Text == "")            { In_Kind.CssClass = "form-control error"; flag = false; }

            if (flag == true)
                Insert();
            else
                Response.Write("<script>alert('红色项未填写或格式错误')</script>");
        }

    }

    protected void Add()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select ID,Name,DATE_FORMAT(Date,'%y/%m/%d %h:%m') as Day,Hoster,Kind,Number_limit,Grade1,Grade2,Grade3,Grade4,Content,Kind from demo.event where id=@id";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", strid);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            In_Name.Text = sdr["Name"].ToString();
            In_Date.Text = sdr["Day"].ToString();
            In_Hoster.Text = sdr["Hoster"].ToString();
            if (sdr["Number_limit"].ToString() != "999")
                In_Limit.Text = sdr["Number_limit"].ToString();
            In_Kind.Text = sdr["Kind"].ToString();
            In_Content.Text = sdr["Content"].ToString();
            if (sdr["Grade1"].ToString() == "1") { grade1.Checked = true; g1.CssClass = "checkbox checkbox-inline checked"; }
            if (sdr["Grade2"].ToString() == "1") { grade2.Checked = true; g2.CssClass = "checkbox checkbox-inline checked"; }
            if (sdr["Grade3"].ToString() == "1") { grade3.Checked = true; g3.CssClass = "checkbox checkbox-inline checked"; }
            if (sdr["Grade4"].ToString() == "1") { grade4.Checked = true; g4.CssClass = "checkbox checkbox-inline checked"; }
        }
        conn.Close();
    }

    protected void Delete()
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        string sql = "delete from demo.event where id= @id";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", Request["id"]);
        conn.Open();
        int n = (int)comm.ExecuteNonQuery();
        if (n != 0)
        {
            Session["delete"] = true;
            Response.Write("<script>alert('删除成功，3秒后自动关闭页面');</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        else
        {
            Response.Write("<script>alert('错误代码3:删除失败，请重试或联系管理员')</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Insert()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        string sql = "update demo.event set Name=@Name, Date=@Date, Grade1=@Grade1, Grade2=@Grade2, Grade3=@Grade3, Grade4=@Grade4, Number_limit=@Number_limit, Hoster=@Hoster, Content=@Content, Kind=@Kind where id=@id;";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", Request["id"]);
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
        conn.Open();
        int n = (int)comm.ExecuteNonQuery();
        if (n != 0)
        {
            Response.Write("<script>alert('更新成功，3秒后自动关闭页面');</script>");
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
        }
        else
        {
            Response.Write("<script>alert('错误代码2:更新失败，请重试或联系管理员')</script>");
            //Response.Redirect("login.aspx");  
        }
        conn.Close();
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
    }
}