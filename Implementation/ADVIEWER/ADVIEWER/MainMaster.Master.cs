using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;
using ADVIEWER.DAL;

namespace ADVIEWER
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGropus();
        }

        protected void LoadGropus()
        {
            GroupsRepeater.DataSource = MemberFunctions.GetParentGroups();
            GroupsRepeater.DataBind();
        }

        protected void getSubGroupsFunc(object sender, RepeaterItemEventArgs e)
        {

            Literal ltrsub = e.Item.FindControl("GetSubGroups") as Literal;
            int id = int.Parse(ltrsub.Text);
            ltrsub.Text = "";
            Group[] SubGroups = MemberFunctions.GetSubGroups();
            foreach (Group sub in SubGroups)
            {
                ltrsub.Text += string.Format(" <li><a  style=\"font-size:11pt\" href='Group-{0}.aspx?{1} '>{2}</a></li>", sub.ID,sub.GroupName, sub.GroupName);

            }

        }

    }
}