using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class AdvsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridViewDataSource();
        }

        private void LoadGridViewDataSource()
        {
            GridView1.DataSource = MemberFunctions.GetUserAdvs(AccountFunctions.currentUserId());
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int ID = int.Parse(e.CommandArgument.ToString());
                MemberFunctions.DeleteAdv(ID);
            }
            LoadGridViewDataSource();
        }
    }

}