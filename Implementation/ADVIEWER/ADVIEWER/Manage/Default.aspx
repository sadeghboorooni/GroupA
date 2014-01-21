﻿<%@ Page Title="پنل مدیریت" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ADVIEWER.Manage.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<div >
<ul id="homebtn">                

        <li><a href="UnconfirmedAdvs.aspx"><img src="images/icons/new.png" alt="" /><span>در انتظار تایید</span></a></li>
        <li><a href="AdReport.aspx"><img src="images/icons/new.png" alt="" /><span>گزارش تبلیغات</span></a></li>
        <li><a href="UserReport.aspx"><img src="images/icons/new.png" alt="" /><span>جستجوی افراد بر اساس زمان وروود</span></a></li>
        <li><a href="SearchUser.aspx"><img src="images/icons/new.png" alt="" /><span>جستجوی افراد </span></a></li>
        <li><a href="GroupsList.aspx"><img src="images/icons/groups.png" alt="" /><span>مدیریت گروه‏ها</span></a></li>
        <li><a href="StatesCitiesList.aspx"><img src="images/icons/groups.png" alt="" /><span>مدیریت شهر‏ها و استان‏ها</span></a></li>
        <li><a href="Tickets.aspx"><img src="images/icons/all.png" alt="" /><span>لیست تیکت‏ها</span></a></li>
        <li><a href="CommentsList.aspx"><img src="images/icons/comment.png" alt="" /><span>لیست نظرات</span></a></li>
        <li><a href="../Account/ChangePassword.aspx"><img src="images/icons/pass.png" alt="" /><span>تغییر رمز ورود</span></a></li>
        <li><asp:LinkButton ID="LinkButton1" runat="server" OnClick="ExitFunction"><img src="images/icons/exit.png" alt="" /><span>خروج</span></asp:LinkButton></li>
    </ul>
    <div class="clear"></div>
    </div>
</asp:Content>
