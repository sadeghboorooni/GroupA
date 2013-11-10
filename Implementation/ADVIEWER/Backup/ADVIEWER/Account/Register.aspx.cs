using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

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
            Guid userID = (Guid)Membership.GetUser(RegisterUser.UserName).ProviderUserKey;
            string userFullName = (string)Membership.GetUser(RegisterUser.UserName).UserName;
            if (AccountFunctions.newUser(userID, userFullName, RegisterUser.Email))
            {
                FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            }
            else 
            { 
                //RegisterUser.UnknownErrorMessage = "مشکلی در ایجاد حساب کاربری ایجاد شده، لطفا دوباره تلاش کنید.";
                Response.Redirect("~/account/register.aspx");
            }
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/member/MemberDefault.aspx";
            }
            Response.Redirect(continueUrl);
        }

    }
}
