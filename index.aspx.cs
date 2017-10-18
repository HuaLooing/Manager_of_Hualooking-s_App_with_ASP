using MySql.Data.MySqlClient;
using System;
using System.Configuration;

public partial class Manager_of_Hualooking_s_App_with_ASP_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
        else
        {
            check();
        }
    }
    protected void check()
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select count(*) as count from event where Date>now()";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        if(sdr.Read())
        {
            Label1.Text = "当前活动数：" + sdr["count"] + "<br/>";
        }
        conn.Close();
        check2();
    }
    protected void check2()
    {

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select count(*) as count from event where Date<now()";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            Label2.Text = "历史活动数：" + sdr["count"] + "<br/>";
        }
        conn.Close();

    }
}