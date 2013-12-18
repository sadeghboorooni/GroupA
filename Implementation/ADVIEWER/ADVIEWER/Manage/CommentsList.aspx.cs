 ﻿using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Web;
 using System.Web.UI;
 using System.Web.UI.WebControls;
 using ADVIEWER.BAL;
 
 namespace ADVIEWER.Manage
 {
     public partial class CommentsList : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {
             LoadCommentGridView();
         }
 
         private void LoadCommentGridView()
         {
             CommentGridView.DataSource = MemberFunctions.GetListCommentData();
             CommentGridView.DataBind();
         }
 
         protected void CommentGridView_RowCommand(object sender, GridViewCommandEventArgs e)
         {
             if (e.CommandName == "deleteComment")
             {
                 int id = int.Parse(e.CommandArgument.ToString());
                 MemberFunctions.DeleteComment(id);
             }
 
             else if (e.CommandName == "ConfirmComment")
             {
                 int id = int.Parse(e.CommandArgument.ToString());
                 MemberFunctions.ConfirmComment(id);
             }
             LoadCommentGridView();
         }
 
         protected void DeleteSelectedComments(object sender, EventArgs e)
         {
             CheckBox chkAdd;
             int rowCount;
             rowCount = CommentGridView.Rows.Count;
             int i;
             for (i = 0; i <= (rowCount - 1); i++)
             {
                 chkAdd = (CheckBox)CommentGridView.Rows[i].FindControl("chkBxSelect");
                 int ID = int.Parse(CommentGridView.DataKeys[i].Value.ToString());
                 if (chkAdd.Checked == true)
                 {
                     MemberFunctions.DeleteComment(ID);
                 }
             }
 
             LoadCommentGridView();
         }
 
         protected void ConfirmSelectedComments(object sender, EventArgs e)
         {
             CheckBox chkAdd;
             int rowCount;
             rowCount = CommentGridView.Rows.Count;
             int i;
             for (i = 0; i <= (rowCount - 1); i++)
             {
                 chkAdd = (CheckBox)CommentGridView.Rows[i].FindControl("chkBxSelect");
                 int ID = int.Parse(CommentGridView.DataKeys[i].Value.ToString());
                 if (chkAdd.Checked == true)
                 {
                     MemberFunctions.ConfirmComment(ID);
                 }
             }
 
             LoadCommentGridView();
         }
     }
 }
