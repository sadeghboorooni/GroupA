using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ADVIEWER.BAL;

namespace ADVIEWER.Manage
{
    public partial class ManageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AccountFunctions.IsManager()) 
            {
                Response.Redirect("~/4.4.aspx");
            }
        }

        protected void ExitFunction(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/", true);
        }


    }
}