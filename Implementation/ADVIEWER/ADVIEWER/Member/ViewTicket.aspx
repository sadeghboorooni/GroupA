<%@ Page Title="View Ticket" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="ViewTicket.aspx.cs" Inherits="ADVIEWER.Member.ViewTicket" %>
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
                    <span style="float:left"><i class="icon-calendar"></i> <%#Eval("SendDate") + " ساعت: " + Eval("SendDate") %></span>
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
         
         <div runat="server" id="ticketAnswer">
         
         </div>
         <div style=" padding-right:288px">
         </div>
         </div>
         </div>
</asp:Content>
