﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ADVIEWER.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
        protected void LoginUser_LoggedIn(object sender, EventArgs e) 
        {
            MembershipUser mu = Membership.GetUser(LoginUser.UserName);
            AccountCodes.loginUser((Guid)mu.ProviderUserKey);
        }
    }
}