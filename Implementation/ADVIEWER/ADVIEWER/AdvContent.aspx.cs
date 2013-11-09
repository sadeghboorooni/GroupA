using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DAL;
using ADVIEWER.BAL;
using ADVIEWER.Account;

namespace ADVIEWER
{
    public partial class AdvContent : System.Web.UI.Page
    {
        public Advertisment curAdv;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                try
                {
                    id = int.Parse(Request.QueryString["id"]);
                }
                catch
                {
                    Response.Redirect("404.aspx");
                }
            }
            else { Response.Redirect("404.aspx"); }

            curAdv = MemberFunctions.GetAdvertismentData(id);
            if ((curAdv == null || !curAdv.IsConfirmed) && !AccountFunctions.IsManager()) { Response.Redirect("404.aspx"); }
            LoadUserAdvertisments();
        
        }

        protected void LoadUserAdvertisments()
        {
            UserAdvsRepeater.DataSource = MemberFunctions.GetUserConfirmedAdvs(curAdv.UserId);
            UserAdvsRepeater.DataBind();
        }

        protected void UserAdvsRepeater_PreRender(object sender, EventArgs e)
        {
            if (UserAdvsRepeater.Items.Count < 1)
            {
                subgroupadi.Visible = false;
            }
        }
    }
}