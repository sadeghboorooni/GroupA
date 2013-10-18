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
            ModelContainer ModelData = new ModelContainer();

            if (string.IsNullOrEmpty(AdvTitleTxt.Text) || string.IsNullOrEmpty(AdvTexttxt.Text) || string.IsNullOrEmpty(Nametxt.Text) || string.IsNullOrEmpty(KeyWordtxt.Text))
            {
                ltr_error.Text = "فیلدهای الزامی را کامل کنید";
                ltr_error.Visible = true;

                return;
            }

            string Title, ShortAdv, AdvText, KeyWord, Link, Address, Name, Price, Mobile, Tell, TellTime,Email,YahooID;
            int AdvKind,AdvMonth;
            Title = AdvTitleTxt.Text;
            ShortAdv = AdvShorttxt.Text;
            AdvText = System.Text.RegularExpressions.Regex.Replace(AdvTexttxt.Text, "<[^>]*>", string.Empty);
            KeyWord = System.Text.RegularExpressions.Regex.Replace(KeyWordtxt.Text, "<[^>]*>", string.Empty);
            Link = Linktxt.Text;
            Address = Addresstxt.Text;
            Name = Nametxt.Text;
            Tell = TellTimetxt.Text;
            Mobile = Mobiletxt.Text;
            Price = Pricetxt.Text;
            TellTime = TellTimetxt.Text;
            Email = Emailtxt.Text;
            YahooID = YahooIDtxt.Text;
            if (Link.ToLower().Trim() == "http://") Link = "";
            AdvKind = int.Parse(AdvKindDrop.SelectedValue);
            AdvMonth = int.Parse(MonthDrop.SelectedValue);

            Advetisement newadv = Advetisement.CreateAdvetisement(1, 2, 3, 4, AdvKind, Title, AdvText, " ",false, Name, Email,DateTime.Now.AddDays(0),DateTime.Now.AddDays(0),0,0,0);

            memberCodes.MakeNewAdvertisment(newadv);
        }
      
    }
}