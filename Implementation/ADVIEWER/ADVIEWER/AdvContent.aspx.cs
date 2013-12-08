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
        public AssignorUser CurUser;
        public Single UserAdvRate = 0, AverageAdvRate = 0;
        public int CountOfRates, CurrentUserID;
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

            CurrentUserID = AccountFunctions.currentUserId();
            if (AccountFunctions.currentUserId() != -1)
            {
                CurUser = AccountFunctions.GetUserInformation(AccountFunctions.currentUserId());
                EmailTextBox.Text = CurUser.Mail;
                EmailTextBox.Enabled = false;
            }

            foreach (AssignorComment Asc in PublicFunctions.GetAdvComments(curAdv.ID))
            {
                AssignorUser TempUser = new AssignorUser();
                if (Asc.SenderID != -1)
                    TempUser = AccountFunctions.GetUserInformation(Asc.SenderID);
                else
                {
                    TempUser.ID = -1;
                    TempUser.PicAddress = "Styles/Images/nopic11.jpg";
                    TempUser.FullName = "ناشناس";
                    TempUser.Address = "نا معلوم";
                }

                AllComments.InnerHtml += "<li><div class=\"vc-comment \" data-comment-id=\"\" data-owner-id=\"\" data-item-id=\"\" data-comment-format=\"default\">" +
            "<div class=\"vc-comment-inner shadow   default\">" +
                "<div class=\"vc-comment-body\"><div class=\"vc-comment-user-avatar\"><img src='/HPicturer.ashx?w=300&amp;h=300&amp;path=" + TempUser.PicAddress + "'/></div>" +
                        "<div class=\"vc-comment-user\"><a class=\"comment-user-name vc-profile-link\"";
                
                if (TempUser.ID == -1)
                    AllComments.InnerHtml += "";
                else
                    AllComments.InnerHtml += "href='/profile.aspx?ID=" + TempUser.ID + "'>";

                AllComments.InnerHtml += TempUser.FullName + "</a>" +
                            "<span class=\"comment-user-seperator\">•</span>" +
                            "<span class=\"comment-user-city\">" + TempUser.Address + "</span></div>" +
                    "<div class=\"vc-comment-content\"><div class=\"comment-content-text summery-content\">" +
                          "<b> </b>" + Asc.Text + "</div>" +
                    "</div>" +
                    "<div class=\"vc-comment-footer\">" +
                        "<span class=\"time-posted\">" + (DateTime.Now - Asc.RegistrationDate) + "</span>" + "</div>" +
                "</div></div></div>" + "</li>";
            }

            AddCommentText.Text = "";
        
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
            List<AssignorAdvertisment> Temp = MemberFunctions.GetUserConfirmedAdvs(curAdv.UserId).ToList();
            Temp.Remove(Temp.Find(t=>t.ID== curAdv.ID));
            UserAdvsRepeater.DataSource = Temp;
            UserAdvsRepeater.DataBind();
        }

        protected void UserAdvsRepeater_PreRender(object sender, EventArgs e)
        {
            if (UserAdvsRepeater.Items.Count < 1)
            {
                subgroupadi.Visible = false;
            }
        }

        protected void SubmitComment_Click(object sender, EventArgs e)
        {

            int CurUserID = AccountFunctions.currentUserId();
            PublicFunctions.SetComment(curAdv.ID, AddCommentText.Text, EmailTextBox.Text, CurUserID);
            
        }
    }
}