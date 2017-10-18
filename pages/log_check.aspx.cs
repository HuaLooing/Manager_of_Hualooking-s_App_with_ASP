using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class log_check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TableRow row;
        TableCell cell;
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select * from demo.log";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            row = new TableRow();
            Table1.Rows.Add(row);
            //先插入所有
            cell = new TableCell
            {
                Text = sdr["idlog"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["logaction"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["logcont"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["ip"].ToString()
            };
            row.Cells.Add(cell);

        }
    }
}