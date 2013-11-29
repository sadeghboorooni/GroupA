using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;
using System.IO;

namespace ADVIEWER.Member
{
    public partial class AddNewAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGroupsDropDownList();
                fillStateCityDropDownList();
                int userId = AccountFunctions.currentUserId();
                AssignorUser currusr = AccountFunctions.GetUserInformation(userId);
                Nametxt.Text = currusr.FullName;
                Mobiletxt.Text = currusr.Mobile;
                Telltxt.Text = currusr.Tell;
                Faxtxt.Text = currusr.Fax;
                Emailtxt.Text = currusr.Mail;
                YahooIDtxt.Text = currusr.YahooID;
                Addresstxt.Text = currusr.Address;
                if (Directory.Exists(MapPath("~/Userfiles/AdvPictures/temp/" + userId + "/")))
                {
                    foreach (string file in Directory.GetFiles(MapPath("~/Userfiles/AdvPictures/temp/" + userId + "/")))
                    {
                        File.Delete(file);
                    }
                    Directory.Delete(MapPath("~/Userfiles/AdvPictures/temp/" + userId + "/"));
                }
            }
        }

        private void fillStateCityDropDownList()
        {
            foreach (AssignorStateCity sc in MemberFunctions.GetStateAndCityForDropDown())
            {
                ListItem li = new ListItem(sc.Name, sc.ID.ToString());
                if (sc.StateId == null)
                {
                    //li.Attributes.Add("disabled", "disabled");
                    li.Attributes.Add("style", "color: #fff; background: #68b800; margin:4px 0;padding:2px 15px 2px 0");
                }
                StateCityDropDownList.Items.Add(li);
            }
        }

        private void fillGroupsDropDownList()
        {
            foreach (AssignorGroup g in MemberFunctions.GetSubGroups())
            {
                ListItem li = new ListItem(g.GroupName, g.ID.ToString());
                if (g.ParentID == null)
                {
                    //li.Attributes.Add( "disabled", "disabled" );
                    li.Attributes.Add("style", "color: #fff; background: #68b800; margin:4px 0;padding:2px 15px 2px 0");
                }
                groupsDropDownList.Items.Add(li);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(AdvTitleTxt.Text) || string.IsNullOrEmpty(AdvTexttxt.Text) || string.IsNullOrEmpty(Nametxt.Text))
            {
                ltr_error.Text = "فیلدهای الزامی را کامل کنید";
                ltr_error.Visible = true;

                return;
            }

            int StarCount = int.Parse(AdvKindDrop.SelectedValue);
            int AdvDuration = int.Parse(MonthDrop.SelectedValue);
            string Title = AdvTitleTxt.Text;
            string ShortDescription = AdvShorttxt.Text;
            string Description = System.Text.RegularExpressions.Regex.Replace(AdvTexttxt.Text, "<[^>]*>", string.Empty);
            string KeyWords = KeyWordtxt.Text;
            string Price = Pricetxt.Text;
            string Link = Linktxt.Text;

            string FullName = Nametxt.Text;
            string Mobile = Mobiletxt.Text;
            string Tell = Telltxt.Text;
            string TellTime = TellTimetxt.Text;
            string Email = Emailtxt.Text;
            string YahooID = YahooIDtxt.Text;
            string Address = Addresstxt.Text;
            int groupId = int.Parse(groupsDropDownList.SelectedValue);
            int statecityid = int.Parse(StateCityDropDownList.SelectedValue);
            if (Link.ToLower().Trim() == "http://") Link = "";
            int userId = AccountFunctions.currentUserId();
            string tempAdd = "", mainAdd = "";
            if (AsyncFileUpload1.HasFile)
            {
                tempAdd = "~/Userfiles/AdvPictures/temp/" + userId + "/";
                mainAdd = "~/Userfiles/AdvPictures/main/" + userId + "/";
            }

            MemberFunctions.MakeNewAdvertisment(StarCount, AdvDuration, Title, ShortDescription, Description, KeyWords, Price, Link, FullName,
                                            Mobile, Tell, TellTime, Email, YahooID, Address, userId, tempAdd, mainAdd, AsyncFileUpload1.FileName, groupId,statecityid);
            SuccessMessage.Text = string.Format("<div class='alert alert-success' style='FontSize:17px'> آگهی شما با موفقیت ثبت شد. <br /> آگهی شما در لیست انتظار مدیر قرار گرفت. </div>");
            SuccessMessage.Visible = true;
        }


        protected void AsyncFileUpload1_UploadedComplete(object sender, EventArgs e)
        {
            //empty root - check file type
            int userId = AccountFunctions.currentUserId();
            string dirPath = "~/Userfiles/AdvPictures/temp/" + userId;
            if (!Directory.Exists(MapPath("~/Userfiles/AdvPictures/temp/" + userId)))
            {
                Directory.CreateDirectory(MapPath("~/Userfiles/AdvPictures/temp/" + userId));
            }
            string ext = Path.GetExtension(AsyncFileUpload1.FileName).ToLower();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                AsyncFileUpload1.SaveAs(MapPath(dirPath + "/" + AsyncFileUpload1.FileName));
        }

    }
}