using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DataModel;
using ADVIEWER.Codes;
using System.IO;

namespace ADVIEWER.Member
{
    public partial class AddNewAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userid = AccountCodes.currentUserId();
                User currusr = AccountCodes.GetUserInformation(userid);
                Nametxt.Text = currusr.FullName;
                Mobiletxt.Text = currusr.Mobile;
                Telltxt.Text = currusr.Tell;
                Faxtxt.Text = currusr.Fax;
                Emailtxt.Text = currusr.Mail;
                YahooIDtxt.Text = currusr.YahooID;
                Addresstxt.Text = currusr.Address;


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
            string Tell = TellTimetxt.Text;
            string TellTime = TellTimetxt.Text;
            string Email = Emailtxt.Text;
            string YahooID = YahooIDtxt.Text;
            string Address = Addresstxt.Text;
            if (Link.ToLower().Trim() == "http://") Link = "";
            int userId= AccountCodes.currentUserId();
            string tempAdd = "", mainAdd = "";
            if (PictureAsyncFileUpload.HasFile)
            {
                tempAdd = "~/Userfiles/AdvPictures/temp/" + userId + "/";
                mainAdd = "~/Userfiles/AdvPictures/main/" + userId + "/";
            }
            
            memberCodes.MakeNewAdvertisment(StarCount , AdvDuration , Title , ShortDescription , Description , KeyWords , Price , Link , FullName , 
                                            Mobile , Tell , TellTime , Email , YahooID , Address, userId,tempAdd,mainAdd,PictureAsyncFileUpload.FileName);
            SuccessMessage.Text = string.Format("<div class='alert alert-success' style='FontSize:17px'> آگهی شما با موفقیت ثبت شد. <br /> آگهی شما در لیست انتظار مدیر قرار گرفت. </div>");
            SuccessMessage.Visible = true;
        }


        protected void PictureAsyncFileUpload_UploadedComplete(object sender, EventArgs e) 
        {
            //empty root - check file type
            int userId = AccountCodes.currentUserId();
            string dirPath = "~/Userfiles/AdvPictures/temp/" + userId;
            if (!Directory.Exists(MapPath("~/Userfiles/AdvPictures/temp/" + userId)))
            {
                Directory.CreateDirectory(MapPath("~/Userfiles/AdvPictures/temp/" + userId));
            }

            PictureAsyncFileUpload.SaveAs(MapPath(dirPath+"/" + PictureAsyncFileUpload.FileName));
        }
      
    }
}