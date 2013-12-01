using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class EditProfile : System.Web.UI.Page
    {
        public string UserFavoriteGroups;
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = AccountFunctions.currentUserId();
            if (!IsPostBack)
            {
                AssignorUser CurUser = AccountFunctions.GetUserInformation(UserID);
                txtAddress.Text = CurUser.Address;
                txtMob.Text = CurUser.Mobile;
                txtName.Text = CurUser.FullName;
                txtTell.Text = CurUser.Tell;
                txtYahoo.Text = CurUser.YahooID;
                txtAbout.Text = CurUser.About;
                txtfax.Text = CurUser.Fax;
                ltrmail.Text = CurUser.Mail;
                ltrprofile.Text = string.Format("<a href='/profile.aspx?id={0}' target='_blank'>صفحه پروفایل شما</a>", UserID);
            }
            UserFavoriteGroups = MemberFunctions.GetUserFavoriteGroups(UserID);
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            int UserID = AccountFunctions.currentUserId();
            string FullName = txtName.Text.Trim();
            string Address = txtAddress.Text.Trim();
            string Mobile = txtMob.Text.Trim();
            string About = txtAbout.Text;
            string Tell = txtTell.Text;
            string Fax = txtfax.Text;
            string YahooID = txtYahoo.Text;
            string FavGroups = FavGrouptxt.Text;
            AccountFunctions.UpdateUserInfo(UserID, FullName, About, Address, Fax, Mobile, Tell, YahooID, FavGroups);
            msg.Visible = true;
            UserFavoriteGroups = MemberFunctions.GetUserFavoriteGroups(UserID);
      
        } 

    }
}