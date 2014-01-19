using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class RecieveMessagesInbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MessageGridView.DataSource = MemberFunctions.GetRecieveMessageInboxDataSource(AccountFunctions.currentUserId()).OrderBy(t=> t.RegistrationDate);
                MessageGridView.DataBind();
            }
        }
    }
}