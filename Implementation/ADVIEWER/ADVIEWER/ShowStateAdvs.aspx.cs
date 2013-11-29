using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Main
{
    public partial class ShowStateAdvs : System.Web.UI.Page
    {
        public string StateTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = 0;
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    ID = int.Parse(Request.QueryString["ID"]);
                }
                catch
                {
                    Response.Redirect("404.aspx");
                }
                StateTitle = Request.QueryString["Title"];
                GroupAdvRepeater.DataSource = PublicFunctions.GetAdvByStateID(ID);
                GroupAdvRepeater.DataBind();
            }
        }
    }
}