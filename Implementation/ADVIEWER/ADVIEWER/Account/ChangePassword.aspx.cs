using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADVIEWER.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void setError(object sender, EventArgs e)
        {
            ErrorMessage.Text = string.Format("<div class='alert alert-danger' style='font-size:17px;display:inline-block;padding: 7px 15px 8px 14px;'>رمز عبور فعلی و یا رمز عبور جدید اشتباه وارد شده است.</div>");
            ErrorMessage.Visible = true;
        }
    }
}
