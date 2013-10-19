using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ADVIEWER.manage
{
    public partial class ManageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExitFunction(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/Default.aspx", true);
        }
    }
}