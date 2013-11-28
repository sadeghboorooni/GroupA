using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Manage
{
    public partial class EditStateCity : System.Web.UI.Page
    {
        private int SCId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    SCId= int.Parse(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("~/404.aspx");
                }

                LoadStates();

                NameTextBox.Text = MemberFunctions.GetStateCityData(SCId).Name;

            }
        }
        private void LoadStates()
        {

            statesDropDownList.Items.Add(new ListItem("استان", "null"));
            int? stateId = MemberFunctions.GetStateCityData(SCId).StateId;
            foreach (AssignorStateCity sc in BAL.MemberFunctions.GetStates())
            {
                ListItem li = new ListItem(sc.Name, sc.ID.ToString());
                statesDropDownList.Items.Add(li);
                if (sc.ID == stateId) li.Selected = true;
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int? newStateId = null;
            if (statesDropDownList.SelectedValue != "null") newStateId = int.Parse(statesDropDownList.SelectedValue);
            MemberFunctions.UpdateStateCityData(int.Parse(Request.QueryString["id"]), NameTextBox.Text, newStateId);

        }
    }
}