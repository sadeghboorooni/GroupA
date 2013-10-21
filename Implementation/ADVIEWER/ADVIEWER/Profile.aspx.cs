using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ADVIEWER.DataModel;
using ADVIEWER.Codes;

namespace ADVIEWER
{

    public partial class Profile : System.Web.UI.Page
    {
        public string about, name, tell, mobile, addr, pic, title, mail;
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                int ID = int.Parse(Request.QueryString["id"]);
                if (Request.RawUrl.ToLower().Contains("/profile-"))
                {
                    if (Request.QueryString["page"] != null)
                    {
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", "profile.aspx?id=" + ID + "&page=" + Request.QueryString["page"]);
                        Response.Redirect("~/profile.aspx?id=" + ID + "&page=" + Request.QueryString["page"]);
                    }
                    else
                    {
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", "profile.aspx?id=" + ID);
                        Response.Redirect("~/profile.aspx?id=" + ID);
                    }
                }

            }
            catch
            {
                Response.Redirect("/404.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"]);
            User userprofile = AccountCodes.GetUserInformation(ID);
            about = userprofile.About;
            name = userprofile.FullName;
            tell = userprofile.Tell;
            mobile = userprofile.Mobile;
            addr = userprofile.Address;
            pic = userprofile.PicAddress;
            title = "صفحه اختصاصی" + userprofile.FullName;

            /*Advertisment[] test = { Advertisment.CreateAdvertisment(1, -1, "title", "text", "", true, "fullname", "email", DateTime.Now, DateTime.Now, 2, 1, 2) };

            CollectionPager1.DataSource = test;*/ //test view

            CollectionPager1.DataSource = AccountCodes.GetUserAdvs(ID);
            
            CollectionPager1.BindToControl = Repeater1;
            Repeater1.DataSource = CollectionPager1.DataSourcePaged;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Repeater rptDemo = sender as Repeater; // Get the Repeater control object.

            // If the Repeater contains no data.
            if (rptDemo != null && rptDemo.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    // Show the Error Label (if no data is present).
                    Label lblErrorMsg = e.Item.FindControl("lblErrorMsg") as Label;
                    if (lblErrorMsg != null)
                    {
                        lblErrorMsg.Visible = true;
                    }
                }
            }

        }

    }
}