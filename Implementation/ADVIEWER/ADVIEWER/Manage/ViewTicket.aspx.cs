using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;
using ADVIEWER.DAL;

namespace ADVIEWER.Manage
{
    public partial class ViewTicket : System.Web.UI.Page
    {
        public string TicketTitle, TicketText , TicketUser ;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int TicketID = int.Parse(Request.QueryString["id"]);
                Ticket t= MemberFunctions.GetTicketData(TicketID);
                TicketTitle = t.Title;
                TicketText = t.Text;
                //ModelContainer ml = new ModelContainer();
                //TicketUser = ml.Users.Where(u => u.ID == TicketID).Select(s=>s.FullName).First();
            }
            catch
            {
                Response.Redirect("~/manage/");
            }
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            int TicketID = int.Parse(Request.QueryString["id"]);
            MemberFunctions.SetTicketAnswer(TicketID, AnswerTextBox.Text.Trim());
        }


    }
}