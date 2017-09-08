using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class event_list : System.Web.UI.Page
{
    string s1,sid,sname,sclass,sin="";
    protected void Page_Load(object sender, EventArgs e)
    {
        s1 = Request["id"];
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
        else
        {   
            string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
            MySqlConnection conn = new MySqlConnection(str);
            string sql = "select ID,Name,DATE_FORMAT(Date,'%y/%m/%d %h:%m') as Day from demo.event where id=@id";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.Parameters.Add("id", s1);
            conn.Open();
            MySqlDataReader sdr = comm.ExecuteReader();
            while (sdr.Read())
            {
                LID.Text = sdr["ID"].ToString();
                LName.Text = sdr["Name"].ToString();
                LTime.Text = sdr["Day"].ToString();
            }
            conn.Close();
            eventlist();
        }
    }

    protected void eventlist()
    {
        TableRow row;
        TableCell cell;
        
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; 
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select ID,Student_ID,ein,eout from demo.sign where id=@id order by Student_ID";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", s1);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            sid = sdr["Student_ID"].ToString();
            Stuinfo();
            if (sdr["ein"].ToString() == "0")
            {
                sin = "未能签进";
                if (sdr["eout"].ToString() == "0")
                {
                    sin += ",未能签退";
                }
            } 
            else if (sdr["eout"].ToString() == "0")
            {
                sin = "未能签退";
            }
            else
            {
                sin = "成功签到";
            }
                

            row = new TableRow();   
            Table3.Rows.Add(row);
            //先插入所有
            cell = new TableCell
            {
                Text=sid 
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sname
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sclass
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sin
            };
            row.Cells.Add(cell);

            //未能成功签进签退
            if (sdr["ein"].ToString() == "0"|| sdr["eout"].ToString() == "0")
            {
                row = new TableRow();
                Table2.Rows.Add(row);
                //先插入所有
                cell = new TableCell
                {
                    Text = sid
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sname
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sclass
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sin
                };
                row.Cells.Add(cell);
            }
            //成功签到
            else
            {
                row = new TableRow();
                Table1.Rows.Add(row);
                //先插入所有
                cell = new TableCell
                {
                    Text = sid
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sname
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sclass
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sin
                };
                row.Cells.Add(cell);
            }
        }
    }

    protected void Stuinfo()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select Student_ID,Class,Name from demo.student where Student_ID=@Student_ID";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("Student_ID", sid);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            sname = sdr["Name"].ToString();
            sclass = sdr["Class"].ToString();
        }
        Label1.Text = sid + sname + sclass;
        conn.Close();
    }
}