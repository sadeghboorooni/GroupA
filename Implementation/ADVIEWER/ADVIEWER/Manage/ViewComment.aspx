 <%@ Page Title="متن نظر" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="ViewComment.aspx.cs" Inherits="ADVIEWER.Manage.ViewComment" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 
  <h2 class="title red">
            متن کامل نظر
         </h2>
 
          <asp:TextBox ID="CommentText" runat="server" TextMode="MultiLine" Width="600" Height="250"></asp:TextBox>
 
 </asp:Content>
 <asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
 </asp:Content>