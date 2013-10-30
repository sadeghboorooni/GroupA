using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADVIEWER.Member
{
    public partial class AddNewTicket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SuccessMessage.Text = string.Format("<div class='alert alert-success' style='font-size:17px'> آگهی شما با موفقیت ثبت شد.</div>");
            SuccessMessage.Visible = true;
        }
    }
}