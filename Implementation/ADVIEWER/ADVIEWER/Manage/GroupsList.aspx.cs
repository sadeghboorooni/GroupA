using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Manage
{
    public partial class GroupsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadGroups();

            if (Request.QueryString["page"] != null)
            {
                int index = 0;
                try
                {
                    index = int.Parse(Request.QueryString["page"]);
                }
                catch { }
                try
                {
                    groupsGridView.PageIndex = index - 1;

                }
                catch { groupsGridView.PageIndex = 0; }
            }
        }

        private void LoadGroups()
        {
            groupsGridView.DataSource = BAL.MemberFunctions.GetSubGroups();
            groupsGridView.DataBind();

            parentsDropDownList.Items.Add(new ListItem("اصلی","null"));

            foreach (AssignorGroup g in BAL.MemberFunctions.GetParentGroups())
            {
                parentsDropDownList.Items.Add(new ListItem(g.GroupName, g.ID.ToString()));
            } 
        }
        protected void groupsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteGroup") 
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                MemberFunctions.DeleteGroup(id);
            }

            LoadGroups();
        }
        protected void groupsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        protected void groupsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int index = e.NewPageIndex + 1;
            string url = Request.Url.GetLeftPart(UriPartial.Path);

            e.Cancel = true; ;
            Response.Redirect(string.Format("{0}?page={1}", url, index));
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string newTitle = titleTextBox.Text;
            int? newParentId = null;
            if (parentsDropDownList.SelectedValue != "null") newParentId = int.Parse(parentsDropDownList.SelectedValue);
            MemberFunctions.AddNewGroup(newTitle, newParentId);

            Response.Redirect(Request.Url.ToString());
        }
    }
}