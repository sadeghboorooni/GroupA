using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Main
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserId = AccountFunctions.currentUserId();
            if (UserId == -1)
            {
                LastAdvsRepeater.DataSource = PublicFunctions.GetLast9Advs();
            }
            else
            {
                LastAdvsRepeater.DataSource = MemberFunctions.GetLast9AdvsByUserGroups(UserId);
            }
            LastAdvsRepeater.DataBind();

        }
    }
}
