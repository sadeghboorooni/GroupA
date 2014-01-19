using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class SendMessageToUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendMessageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                MemberFunctions.AddNewUserMessages(UsersTxt.Text, MessageContentTxt.Text.Replace("\n", "<br />"));
                SuccessMessage.Text = string.Format("<div class='alert alert-success' style='font-size:17px;display:inline-block'>پیام شما با موفقیت ارسال شد.</div>");
                SuccessMessage.Visible = true;
            }
            catch { }
        }
    }
}