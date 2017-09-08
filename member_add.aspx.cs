using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;


public partial class member_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null || Session["act"].ToString() != "0")
        {
            Table1.Visible = false;
            Response.Write("<script>alert('此功能仅向具有此权限的管理员开放！');</script>");
            Response.Write("<script language=\"javascript\">setTimeout(location.href='index.aspx',3000)</script>");
        }
        else
        {
            TableRow row;
            TableCell cell;
            string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select * from demo.administrator order by act,Administrator_ID";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader sdr = comm.ExecuteReader();
            while (sdr.Read())
            {
                string sactstr,sact= sdr["act"].ToString();
                if (sact == "0") sactstr = "超级管理员"; else sactstr = "普通管理员";
                row = new TableRow();
                Table1.Rows.Add(row);
                //账号
                cell = new TableCell
                {
                    Text = sdr["Administrator_ID"].ToString()
                };
                row.Cells.Add(cell);
                //姓名
                cell = new TableCell
                {
                    Text = sdr["Name"].ToString()
                };
                row.Cells.Add(cell);
                //密码
                if (sact=="0")
                {
                    cell = new TableCell
                    {
                        Text = "***"
                    };
                }
                else
                {
                    cell = new TableCell
                    {
                        Text = sdr["Password"].ToString()
                    };
                }
                row.Cells.Add(cell);
                //权限
                cell = new TableCell
                {
                    Text = sactstr
                };
                row.Cells.Add(cell);
                if (sact == "0")
                {
                    cell = new TableCell
                    {
                        Text = "<a href=\"#\" class=\"btn btn-simple btn-danger btn-icon remove\"><i class=\"fa fa-times\">不可编辑</i></a>"
                    };
                }
                else
                {
                    cell = new TableCell
                    {
                        Text = "<a href=\"#\" class=\"btn btn-simple btn-warning btn-icon edit\"><i class=\"fa fa-edit\" onclick=\"\"></i></a><a href =\"#\" class=\"btn btn-simple btn-danger btn-icon remove\"><i class=\"fa fa-times\"></i></a></asp:TableCell>"
                    };
                }
                
                row.Cells.Add(cell);
            }
            conn.Close();
        }


    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        int f = 0;
        if (In_Name.Text == "")
        { In_Name.CssClass = "form-control error"; f = 1; }
        if (In_ID.Text == "")
        { In_ID.CssClass = "form-control error"; f = 1; }
        if(In_Code1.Text != In_Code2.Text)
        {
            In_Code1.CssClass = "form-control error";
            In_Code2.CssClass = "form-control error";
            Label1.Text = "两次输入密码不一致";
        }
        else if(f == 1)
        {
            Label1.Text = "请填红色项写";
        }
        else
        {
            string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(str); conn.Open();
            string sql = "insert into demo Administrator (Administrator_ID,Password,Name) Values(@iid,@iname,@pwd)";
            

            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.Add("iid", In_ID.Text);
            comm.Parameters.Add("iname", In_Name.Text);
            comm.Parameters.Add("pwd", In_Code1.Text);
            int n = comm.ExecuteNonQuery();
            if (n!=0)
            {
                Response.Write("<script>alert('添加成功，即将跳转到管理页面');</script>");
                Response.Write("<script language=\"javascript\">setTimeout(location.href='member_add.aspx',1000)</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败，数据库异常！');</script>");

            }
        }
    }
}