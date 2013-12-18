 ﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Web;
 using System.Web.UI;
 using System.Web.UI.WebControls;
 using ADVIEWER.BAL;
 
 namespace ADVIEWER.Manage
 {
     public partial class ViewComment : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {
             AssignorComment ThisComment = new AssignorComment();
 
             try
             {
                 int CommentID = int.Parse(Request.QueryString["id"]);
                 ThisComment = MemberFunctions.GetCommentData(CommentID);
             }
             catch
             {
                 Response.Redirect("~/manage/");
             }
 
             CommentText.Text = ThisComment.Text.Replace("<br />", "");
         }
     }
 }
