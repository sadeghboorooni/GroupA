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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int UserID = AccountFunctions.currentUserId();
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
            AccountFunctions.UpdateUserInfo(UserID, FullName, About, Address, Fax, Mobile, Tell, YahooID);
            msg.Visible = true;
        } 

    }
}