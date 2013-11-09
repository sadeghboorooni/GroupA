using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class TicketsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTicketGridView();
        }

        private void LoadTicketGridView()
        {
            TicketGridView.DataSource = MemberFunctions.GetListTicketData(AccountFunctions.currentUserId());
            TicketGridView.DataBind();
        }


        protected void TicketGridView_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            if (e.CommandName == "deleteTicket") 
            {
                int id = int.Parse(e.CommandArgument.ToString());
                MemberFunctions.DeleteTicket(id);
            }
            LoadTicketGridView();
        }

        protected void DeleteSelectedTickets(object sender, EventArgs e)
        {
            CheckBox chkAdd;
            int rowCount;
            rowCount = TicketGridView.Rows.Count;
            int i;
            for (i = 0; i <= (rowCount - 1); i++)
            {
                chkAdd = (CheckBox)TicketGridView.Rows[i].FindControl("chkBxSelect");
                int ID = int.Parse(TicketGridView.DataKeys[i].Value.ToString());
                if (chkAdd.Checked == true)
                {
                    MemberFunctions.DeleteTicket(ID);
                }
            }

            LoadTicketGridView();
        }

    }
}