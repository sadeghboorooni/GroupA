using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Manage
{
    public partial class EditGroup : System.Web.UI.Page
    {
        private int groupid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    groupid = int.Parse(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("~/404.aspx");
                }

                LoadGroups();

                titleTextBox.Text = MemberFunctions.GetGroupData(groupid).GroupName;

            }
        }
        private void LoadGroups()
        {

            parentsDropDownList.Items.Add(new ListItem("اصلی", "null"));
            int? parentId = MemberFunctions.GetGroupData(groupid).ParentID;
            foreach (AssignorGroup g in BAL.MemberFunctions.GetParentGroups())
            {
                ListItem li = new ListItem(g.GroupName, g.ID.ToString());
                parentsDropDownList.Items.Add(li);
                if (g.ID == parentId) li.Selected = true;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int? newParentId = null;
            if (parentsDropDownList.SelectedValue != "null") newParentId = int.Parse(parentsDropDownList.SelectedValue);
            MemberFunctions.UpdateGroupData(int.Parse(Request.QueryString["id"]), titleTextBox.Text, newParentId);

        }
    }
}