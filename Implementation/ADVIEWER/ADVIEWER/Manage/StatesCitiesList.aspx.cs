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
    public partial class StatesCitiesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            LoadStatesCities();

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
                    statesCitiesGridView.PageIndex = index - 1;

                }
                catch { statesCitiesGridView.PageIndex = 0; }
            }
        }

        private void LoadStatesCities()
        {
            statesCitiesGridView.DataSource = BAL.MemberFunctions.GetStatesCities();
            statesCitiesGridView.DataBind();

            StatesDropDownList.Items.Add(new ListItem("استان", "null"));

            foreach (StateCity s in BAL.MemberFunctions.GetStates())
            {
                StatesDropDownList.Items.Add(new ListItem(s.Name, s.Id.ToString()));
            }
        }
        protected void statesCitiesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deleteStateCity")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                MemberFunctions.DeleteStateCity(id);
            }

            LoadStatesCities();
        }
        protected void statesCitiesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void statesCitiesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int index = e.NewPageIndex + 1;
            string url = Request.Url.GetLeftPart(UriPartial.Path);

            e.Cancel = true; ;
            Response.Redirect(string.Format("{0}?page={1}", url, index));
        }

        protected void AddCityButton_Click(object sender, EventArgs e)
        {
            string newName = CityStateNameTextBox.Text;
            int? newStateId = null;
            if (StatesDropDownList.SelectedValue != "null") newStateId = int.Parse(StatesDropDownList.SelectedValue);
            MemberFunctions.AddNewStateCity(newName, newStateId);

            Response.Redirect(Request.Url.ToString());
        }
    }
}