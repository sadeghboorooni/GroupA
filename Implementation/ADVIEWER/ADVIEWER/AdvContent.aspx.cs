using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Main
{
    public partial class AdvContent : System.Web.UI.Page
    {
        public AssignorAdvertisment curAdv;
        public Single UserAdvRate = 0, AverageAdvRate = 0;
        public int CountOfRates;
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
            LoadRates();
            LoadUserAdvertisments();
        
        }

        private void LoadRates()
        {
            AverageAdvRate = PublicFunctions.GetAdvAverageRate(curAdv.ID);
            AverageAdvRate = (Single)Math.Round((decimal)AverageAdvRate, 2, MidpointRounding.AwayFromZero);
            CountOfRates = PublicFunctions.CountOfRates(curAdv.ID);
            if (AccountFunctions.currentUserId() != -1)
            {
                UserAdvRate = MemberFunctions.GetAdvUserRate(curAdv.ID);
            }
            else 
            {
                if (Session["AdvRates"] != null)
                {
                    List<AssignorRate> sessionRates = (List<AssignorRate>)Session["AdvRates"];
                    if (sessionRates.Where(t => t.AdvertismentId == curAdv.ID).Count() > 0)
                    {
                        AssignorRate r = sessionRates.Where(t => t.AdvertismentId == curAdv.ID).First();
                        UserAdvRate = r.Value;
                    }
                }
            }
        }

        protected void LoadUserAdvertisments()
        {
            UserAdvsRepeater.DataSource = MemberFunctions.GetUserConfirmedAdvs(curAdv.UserId).SkipWhile(t => t.ID == curAdv.ID);
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