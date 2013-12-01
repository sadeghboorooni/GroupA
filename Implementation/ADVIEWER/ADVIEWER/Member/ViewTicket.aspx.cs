using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class ViewTicket : System.Web.UI.Page
    {
        public string TicketTitle, TicketText , TicketUser ;
        protected void Page_Load(object sender, EventArgs e)
        {
            int TicketID = int.Parse(Request.QueryString["id"]);
            AssignorTicket t = MemberFunctions.GetTicketData(TicketID);
            TicketTitle = t.Title;
            TicketText = t.Text;
            if (t.Answer != "" && t.Answer != null)
            {
                ticketAnswer.InnerText = t.Answer;
            }
            else
            {
                ticketAnswer.InnerText = "هنوز پاسخی از سوی مدیر برای این تیکت درج نشده است.";
                ticketAnswer.Attributes.Add("style", "color:red");

            }

        }

    }
}