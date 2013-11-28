using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ADVIEWER.BAL;

namespace ADVIEWER.member
{
    public partial class MemberDefault : System.Web.UI.Page
    {
        //public string picAdd;
        protected void Page_Load(object sender, EventArgs e)
        {
            //picAdd = AccountFunctions.GetUserInformation(AccountFunctions.currentUserId()).PicAddress;
        }

        protected void ExitFuction(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("/Default.aspx", true);
        }
    }
}