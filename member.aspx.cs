using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请登录');</script>");
            Response.Redirect("login.aspx");
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string clas = In_Class.Text;
       
        Tab(clas);
       
            
    }

    protected void Tab(string clas)
    {
        TableRow row;
        TableCell cell;

        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select * from demo.student where Class=@id;";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", In_Class.Text);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            row = new TableRow();
            Table1.Rows.Add(row);
            //先插入所有
            cell = new TableCell
            {
                Text = sdr["Student_ID"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["Name"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["Grade"].ToString()
            };
            row.Cells.Add(cell);
        }
    }
}