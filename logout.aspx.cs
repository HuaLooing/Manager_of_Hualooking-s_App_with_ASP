using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_of_Hualooking_s_App_with_ASP_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session.Remove("userName");
    }
}