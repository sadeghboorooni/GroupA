using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.Codes;

namespace ADVIEWER.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            Guid userID = (Guid)Membership.GetUser(RegisterUser.UserName).ProviderUserKey;
            string userFullName = (string)Membership.GetUser(RegisterUser.UserName).UserName;
            AccountCodes.newUser(userID,userFullName);
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/member/MemberDefault.aspx";
            }
            Response.Redirect(continueUrl);
        }

    }
}
