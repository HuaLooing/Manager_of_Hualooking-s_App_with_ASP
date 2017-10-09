using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

public partial class event_in_wechat : System.Web.UI.Page
{
    //网页加载的一些判断
    protected void Page_Load(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>swal({type:'success',text:'报名成功',showCancelButton:false,});</script>");
        
        if (!Request.UserAgent.ToLower().Contains("micromessenger"))
        {
           Response.Write("<script>location.href='pages/fail.html';</script>");
        }
        else
        {
            WriteTextLog("加载网页", DateTime.Now.ToLocalTime().ToString());
            //Response.Write("测试1。");
            //Label1.Text = Session["userName"].ToString();
            string st = Request["code"];
            //Response.Write(st);
            if (Session["stu_id"] == null)
            {
                if (get_openid(st) == false)
                {
                    Response.Write("<script>location.href='pages/fail3.html';</script>");
                }
                else
                {
                    check_openid();
                }
            }
            else
            {

                get_ybmlist();
                get_kbmlist();
                get_lscylist();
            }

        }

    }
    //获取用户openid
    protected bool get_openid(string code)
    {

        Session["code"] = code;
        string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=wxd813cf0c8c5b4b8a&secret=b2edd1283451a2aa0fc4849caec86b82&code=" + code + "&grant_type=authorization_code ";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "text/xml";
        Stream reqstream = request.GetRequestStream();
        //声明一个HttpWebRequest请求
        request.Timeout = 9000;
        //设置连接超时时间
        request.Headers.Set("Pragma", "no-cache");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        Stream streamReceive = response.GetResponseStream();
        Encoding encoding = Encoding.UTF8;

        StreamReader streamReader = new StreamReader(streamReceive, encoding);
        string s = streamReader.ReadToEnd();
        streamReceive.Dispose();
        streamReader.Dispose();
        if (s.IndexOf("errcode") == -1)
        {
            int s1 = s.IndexOf("openid");
            int s2 = s.IndexOf("scope");
            //创建openid的session
            WriteTextLog("登录code", code + " " + s.Substring(s1 + 9, s2 - s1 - 12));
            Session["openid"] = s.Substring(s1 + 9, s2 - s1 - 12);
            //调试语句
            // Response.Write(Session["open_id"].ToString());
            //Session["s"] = s;
            return true;
        }
        else
        {
            WriteTextLog("获取openid失败", "");
            return false;
        }
    }
    //检查openid是否在数据库中，然后加载活动列表
    protected void check_openid()
    {
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);

        string sql = "select * from student where openid = @opid";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("opid", Session["openid"].ToString());
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        if (sdr.Read())
        {
            //根据openid获取班级姓名后展示活动列表
            Session["stu_id"] = sdr["Student_ID"].ToString();
            Session["stu_class"] = sdr["Class"].ToString();
            //Response.Write(Session["stu_id"].ToString() + Session["stu_class"].ToString());

            //加载表格
            get_ybmlist();
            get_kbmlist();
            //get_lscylist();
        }
        else
        {
            //Response.Write(Session["openid"].ToString()+"</br>"+ Session["s"].ToString());
            Response.Write("<script>location.href='login_in_wechat.aspx';</script>");
        }
        conn.Close();
    }
    //已报名但是未到活动开始时间的活动列表 Table1：活动名称；活动时间；活动类别；主办；学分；编辑
    protected void get_ybmlist()
    {
        TableRow row;
        TableCell cell;
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select ID,Name,DATE_FORMAT(Date,'%y年%m月%d日 %H:%m') as Day,Date,Grade,Kind,Hoster from demo.event where Date > sysdate() and ID in (select ID from sign where Student_ID = @userName)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            row = new TableRow();
            string id = sdr["ID"].ToString();
            Table1.Rows.Add(row);
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
                Text = sdr["Kind"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["Hoster"].ToString()
            };
            row.Cells.Add(cell);
            cell = new TableCell
            {
                Text = sdr["Grade"].ToString()
            };
            row.Cells.Add(cell);
            //添加退选按钮
            cell = new TableCell();
            Button btn = new Button();
            btn.ID = "tx" + id;
            btn.CommandArgument = id;
            btn.CssClass = "btn btn-fill btn-info";
            btn.Text = "退选";
            btn.Click += new EventHandler(tuixuan);
            cell.Controls.Add(btn);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

        }

        conn.Close();
    }
    //可以报名但是未到活动开始时间的活动列表 但是未到活动开始时间的活动列表 Table1：活动名称；活动时间；学分；编辑
    protected void get_kbmlist()
    {
        //根据学生班级获取学生年级判断
        string grade = Session["stu_class"].ToString().Substring(0, 2);
        TableRow row;
        TableCell cell;
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "select ID,Name,DATE_FORMAT(Date,'%y年%m月%d日 %H:%m') as Day,Date,Grade1,Grade2,Grade3,Grade4,Grade,Kind,Hoster from demo.event where Date > sysdate() and ID not in (select ID from sign where Student_ID = @userName)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            //确认年级是否在课报名年级之中
            if ((grade == "17 " && sdr["Grade1"].ToString() == "1") || (grade == "16" && sdr["Grade2"].ToString() == "1") || (grade == "15" && sdr["Grade3"].ToString() == "1") || (grade == "14" && sdr["Grade1"].ToString() == "1"))
            {
                row = new TableRow();
                string id = sdr["ID"].ToString();
                Table1.Rows.Add(row);
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
                    Text = sdr["Kind"].ToString()
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sdr["Hoster"].ToString()
                };
                row.Cells.Add(cell);
                cell = new TableCell
                {
                    Text = sdr["Grade"].ToString()
                };
                row.Cells.Add(cell);
                //添加报名按钮
                cell = new TableCell();
                Button btn = new Button();
                btn.ID = "bm" + id;
                btn.CommandArgument = id;
                btn.CssClass = "btn btn-fill btn-info";
                btn.Text = "报名";
                btn.Click += new EventHandler(baoming);
                cell.Controls.Add(btn);
                row.Cells.Add(cell);
                Table1.Rows.Add(row);
            }

        }
        conn.Close();
    }
    //历史的活动列表 包括所有已经报名的活动 Table2：活动名称；活动时间；学分；状态
    protected void get_lscylist()
    {
        TableRow row;
        TableCell cell;
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "SELECT Student_ID,u.ID,Name,DATE_FORMAT(Date, '%y年%m月%d日 %H:%m') AS Day,Grade,k.ein,k.eout,k.Student_ID FROM demo.event AS u INNER JOIN sign as k ON u.ID = k.ID and k.Student_ID = @userName";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        MySqlDataReader sdr = comm.ExecuteReader();
        while (sdr.Read())
        {
            row = new TableRow();
            string id = sdr["ID"].ToString();
            Table1.Rows.Add(row);
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
                Text = sdr["Grade"].ToString()
            };
            row.Cells.Add(cell);
            if (sdr["ein"].ToString() == "1")
            {
                cell = new TableCell
                {
                    Text = "已签到"
                };
            }
            else
            {
                cell = new TableCell
                {
                    Text = "未签到"
                };
            }
            row.Cells.Add(cell);
            Table2.Rows.Add(row);
        }
        conn.Close();
    }
    //报名按钮的操作
    protected void baoming(object sender, EventArgs e)
    {
        
        string id = ((Button)sender).CommandArgument.ToString();
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "insert into sign (id,Student_ID) Values(@id,@userName);";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", id);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        if (comm.ExecuteNonQuery() != 0)
        {
            WriteTextLog("报名成功", "id:" + id + " 学生id:" + Session["stu_id"].ToString());
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>swal({type:'success',text:'报名成功',showCancelButton:false,});</script>");
            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>swal({type:'error',text:'报名失败',showCancelButton:false,});</script>");
            WriteTextLog("报名失败", "id:" + id + " 学生id:" + Session["stu_id"].ToString());
            //Response.Redirect(Request.Url.ToString());
        }
        conn.Close();
    }
    //退选按钮的操作
    protected void tuixuan(object sender, EventArgs e)
    {
        string id = ((Button)sender).CommandArgument.ToString();
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "delete from sign where id = @id and Student_ID= @userName";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("id", id);
        comm.Parameters.Add("userName", Session["stu_id"].ToString());
        conn.Open();
        if (comm.ExecuteNonQuery() != 0)
        {
           
            //Response.Write("<script>swal( type: 'sucess',text: '退选成功',timer: 2000)</script>");
            WriteTextLog("退选成功", "id:" + id + " 学生id:" + Session["stu_id"].ToString());
            Response.Redirect(Request.Url.ToString());
            //ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>swal({type:'success',text:'退选成功',showCancelButton:false,});</script>");
            // ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>noti.showSucess('top','center')</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "", "<script>swal({type:'error',text:'退选失败',showCancelButton:false,});</script>");
            WriteTextLog("退选失败", "id:" + id + " 学生id:" + Session["stu_id"].ToString());
            Response.Redirect(Request.Url.ToString());
        }
        conn.Close();

    }
    //记录日志
    protected static void WriteTextLog(string action, string strMessage)
    {
        
        string str = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; ;
        MySqlConnection conn = new MySqlConnection(str);
        string sql = "insert into log (logaction,logcont,ip) values(@l1,@l2,@l3)";
        MySqlCommand comm = new MySqlCommand(sql, conn);
        comm.Parameters.Add("l1", action);
        comm.Parameters.Add("l2", strMessage);
        comm.Parameters.Add("l3", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
        conn.Open();
        comm.ExecuteNonQuery();
        conn.Close();
        
    }
}