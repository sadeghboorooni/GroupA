using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ADVIEWER.Codes;
using ADVIEWER.DataModel;

namespace ADVIEWER.member
{
    public partial class MemberMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = AccountCodes.currentUserId();
            User UserName = AccountCodes.GetUserInformation(UserID);
            if (!IsPostBack)
            {
                ltrprofile.Text = string.Format("<a href='/profile.aspx?id={0}' target='_blank'><i class='icon-user'></i>مشاهده ی صفحه ی شخصی</a>", UserID);
                ltr_username2.Text = string.Format("<strong>{0} </strong>", UserName.FullName);
                if (UserName.IsManager == true)
                {
                    ManagerPanel.Text = string.Format("| <a href='/Manage/Default.aspx'>پنل مدیریت</a>");
                    ManagerPanel.Visible = true;
                }
            }
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