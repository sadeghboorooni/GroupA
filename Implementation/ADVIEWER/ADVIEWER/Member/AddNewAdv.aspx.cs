using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DataModel;
using ADVIEWER.Codes;

namespace ADVIEWER.Member
{
    public partial class AddNewAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(AdvTitleTxt.Text) || string.IsNullOrEmpty(AdvTexttxt.Text) || string.IsNullOrEmpty(Nametxt.Text) || string.IsNullOrEmpty(KeyWordtxt.Text))
            {
                ltr_error.Text = "فیلدهای الزامی را کامل کنید";
                ltr_error.Visible = true;

                return;
            }

            Advertisment newadv = new Advertisment();

            
            newadv.Title = AdvTitleTxt.Text;
            newadv.Description= AdvShorttxt.Text;
            newadv.Text = System.Text.RegularExpressions.Regex.Replace(AdvTexttxt.Text, "<[^>]*>", string.Empty);
            
            newadv.Link = Linktxt.Text;
            newadv.Address = Addresstxt.Text;
            newadv.FullName = Nametxt.Text;
            newadv.Tell = TellTimetxt.Text;
            newadv.Mobile = Mobiletxt.Text;
            newadv.Price = Pricetxt.Text;
            newadv.TellTime = TellTimetxt.Text;
            newadv.Email = Emailtxt.Text;
            newadv.YahooID = YahooIDtxt.Text;
            if (newadv.Link.ToLower().Trim() == "http://") newadv.Link = "";
            newadv.StarCount = int.Parse(AdvKindDrop.SelectedValue);
            newadv.AdvDuration = int.Parse(MonthDrop.SelectedValue);

            newadv.Pic = "";
            newadv.ExpirationDate = DateTime.Now;
            newadv.LastRenewal = DateTime.Now;
            newadv.RegistrationDate = DateTime.Now;
            newadv.StartDate = DateTime.Now;
            
            

            memberCodes.MakeNewAdvertisment(newadv.StarCount, newadv.Title, newadv.Text, newadv.Pic, newadv.IsActive, newadv.FullName, 
                newadv.Email, newadv.ExpirationDate, newadv.RegistrationDate, newadv.ReviewCount, newadv.AdvDuration, 
                AccountCodes.currentUserId(),KeyWordtxt.Text);
        }
      
    }
}