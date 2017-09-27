using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //更改活动后的刷新
        Session["refresh"] = true;
        Session["delete"] = false;
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
        else
        {
            TableRow row;
            TableCell cell;
            string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select ID,Name,DATE_FORMAT(Date,'%y年%m月%d日 %h:%m') as Day,Date,Hoster,Kind,Number_limit,Grade1,Grade2,Grade3,Grade4,Grade from demo.event";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader sdr = comm.ExecuteReader();
            
            while (sdr.Read())
            {
                row = new TableRow();
                int flag = 0;
                string ss = sdr["Date"].ToString(),Grades="";
                DateTime dt1 = DateTime.Parse(ss);
                DateTime dt2 = DateTime.Now;
                if (sdr["Grade1"].ToString() == "1")
                {
                    Grades += "大一";
                    flag = 1;
                } 
                if(sdr["Grade2"].ToString() == "1")
                {
                    if (flag == 1) Grades += ",";
                    Grades += "大二";
                    flag = 1;
                }
                if (sdr["Grade3"].ToString() == "1")
                {
                    if (flag == 1) Grades += ",";
                    Grades += "大三";
                    flag = 1;
                }
                if (sdr["Grade4"].ToString() == "1")
                {
                    if (flag == 1) Grades += ",";
                    Grades += "大四";
                    flag = 1;
                }
                if (DateTime.Compare(dt1, dt2) > 0)
                {
                    Table1.Rows.Add(row);
                    cell = new TableCell
                    {
                        Text = sdr["ID"].ToString()
                        //id.ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Name"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Day"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = Grades
                    };
                    row.Cells.Add(cell);
                    string limition;
                    if (sdr["Number_limit"].ToString() == "999")
                        limition = "人数无限制";
                    else
                        limition = "共可容纳" + sdr["Number_limit"];
                    cell = new TableCell
                    {
                        Text = limition
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Grade"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Kind"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = "<a href=\"event_list.aspx?id=" + sdr["ID"].ToString() + "\" rel=\"tooltip\" title=\"报名列表\"  target=\"_Blank\" class=\"btn btn-info btn-simple btn-xs\"><i class=\"fa fa-user\"></i><a href=\"event_m.aspx?id=" + sdr["ID"].ToString() + "&action=modify\" rel=\"tooltip\" title=\"编辑\" class=\"btn btn-simple btn-warning btn-icon edit\"  target=\"_Blank\"><i class=\"fa fa-edit\" onclick=\"\"></i></a><a href =\"event_m.aspx?id=" + sdr["ID"].ToString() + "&action=delete\" rel=\"tooltip\" title=\"删除\" class=\"btn btn-simple btn-danger btn-icon remove\"><i class=\"fa fa-times\"></i></a></asp:TableCell>"
                    };
                    row.Cells.Add(cell);
                }

                else
                {
                    Table2.Rows.Add(row);
                    cell = new TableCell
                    {
                        Text = sdr["ID"].ToString()
                        //id.ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Name"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Day"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = Grades
                    };
                    row.Cells.Add(cell);
                    string limition;
                    if (sdr["Number_limit"].ToString() == "999")
                        limition = "人数无限制";
                    else
                        limition = "共可容纳" + sdr["Number_limit"];
                    cell = new TableCell
                    {
                        Text = limition
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Grade"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = sdr["Kind"].ToString()
                    };
                    row.Cells.Add(cell);
                    cell = new TableCell
                    {
                        Text = "<a href=\"event_list.aspx?id=" + sdr["ID"].ToString() + "\" rel=\"tooltip\" title=\"报名列表\"  target=\"_Blank\" class=\"btn btn-info btn-simple btn-xs\"><i class=\"fa fa-user\"></i><a href =\"event_m.aspx?id=" + sdr["ID"].ToString() + "&action=delete\" rel=\"tooltip\" title=\"删除\" class=\"btn btn-simple btn-danger btn-icon remove\"><i class=\"fa fa-times\"></i></a></asp:TableCell>"
                    };
                    row.Cells.Add(cell);
                }
                
                
            }

            conn.Close();
        }

    }
}