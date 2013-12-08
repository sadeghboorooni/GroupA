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
    public partial class Avatar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int UserID = AccountFunctions.currentUserId();
            ltrprofile.Text = string.Format("<a href='/profile.aspx?id={0}' target='_blank'>صفحه پروفایل شما</a>", UserID);
        }

      

        protected void SaveImage_Click(object sender, EventArgs e)
        {
            string tempAdd = "";
            string mainAdd="";
            int userId = AccountFunctions.currentUserId();
            MemberFunctions.deleteImage(userId);

            if (AsyncImageUpload.HasFile)
            {
                tempAdd = "~/Userfiles/profile/temp/";
                mainAdd = "~/Userfiles/profile/main/";
            }

            MemberFunctions.setUserImage(tempAdd, mainAdd, userId,AsyncImageUpload.FileName);
    

        }
        protected void AsyncImageUpload_UploadedComplete(object sender, EventArgs e)
        {
            int userId = AccountFunctions.currentUserId();
            string dirPath = "~/Userfiles/profile/temp/";
            if (!Directory.Exists(MapPath("~/Userfiles/profile/temp/")))
            {
                Directory.CreateDirectory(MapPath("~/Userfiles/profile/temp/"));
            }
            string ext = Path.GetExtension(AsyncImageUpload.FileName).ToLower();
            if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif")
                AsyncImageUpload.SaveAs(MapPath(dirPath + "/" + AsyncImageUpload.FileName));

        }

        protected void deleteImage_Click(object sender, EventArgs e)
        {
            int curId = AccountFunctions.currentUserId();
           MemberFunctions .deleteImage(curId);
            
        }
    }
}