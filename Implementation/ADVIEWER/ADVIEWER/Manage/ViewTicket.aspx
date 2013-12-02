<%@ Page Title="مشاهده تیکت" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="ViewTicket.aspx.cs" Inherits="ADVIEWER.Manage.ViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title><%= TicketTitle %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
  
     <div class="fullcontent">
        <h2 class="title blue">
            <%= TicketTitle %></h2>     
                <div class="bordered" style='<%# Eval("IsManageReply").ToString().ToLower() == "true" ? "background: #f2f2f2;" : "background: #fbfbfb" %>'>
                <div class="ticketdetails">
                    <span style="float:right"><i class="icon-user"></i> فرستنده: <%= TicketUser%></span>
                    <span style="float:left"><i class="icon-calendar"></i> <%=TicketDate%></span>
                </div>
                <div class="clear"></div>
                
                    <%= TicketText%>
                <div class="clear">
                </div>
            </div>
            </div>
        <h2 class="title red">
           پاسخ به تیکت
        </h2>
        <div class="bordered">
         
         <div id="txt" runat="server">
         <label class="title">متن پاسخ</label>
         <asp:TextBox ID="AnswerTextBox" runat="server" TextMode="MultiLine" Width="300" Height="80px"></asp:TextBox> <span style="color:Red">×</span><br />
         <div style=" padding-right:288px">
         <asp:Button ID="sendButton" runat="server" Text="ارسال" onclick="sendButton_Click" /></div>
         </div>
         </div>

 
</asp:Content> 
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>
