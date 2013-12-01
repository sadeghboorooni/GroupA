<%@ Page Title="مشاهده تیکت" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="ViewTicket.aspx.cs" Inherits="ADVIEWER.Member.ViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title><%= TicketTitle %></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="alert hero-unit memberheader">مشاهده تیکت</h2>

     <div class="fullcontent">
        <div>
        <div style="display:inline-block;font-size:22px;">
            <span style="color:cornflowerblue;font-size:17px">عنوان تیکت:&nbsp</span>
            <%= TicketTitle %>
            </div>
            </div>
                <div class="btm-tab-btn ptr LocoSelect">متن تیکت</div>
                <div style="float: left;position: relative;top: 20px;"><i class="icon-calendar"></i> <%#Eval("RegDate") + " ساعت: " + Eval("RegDate") %></div>     
                <div class="contenttext" style="margin-top:10px;margin-bottom:10px;">
                <span style="float:right;margin:15px;">
                
                    <%= TicketText%>
                    </span>
                <div class="clear">
                </div>
            </div>
            </div>
        
        <div class="bordered">
         
         <div class="btm-tab-btn ptr LocoSelect">پاسخ مدیر</div>
         <div style="float: left;position: relative;top: 20px;"><i class="icon-calendar"></i> <%#Eval("RegDate") + " ساعت: " + Eval("RegDate") %></div>     
         <div class="contenttext" style="margin-top:10px;margin-bottom:10px;">
                <div style="margin:15px;">
         <div runat="server" id="ticketAnswer">  
         </div>
         </div>
         </div>

         </div>
</asp:Content>
