<%@ Page Title="مشاهده ی پیام" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="ViewMessage.aspx.cs" Inherits="ADVIEWER.Member.ViewMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <h2 class="alert hero-unit memberheader">مشاهده پیام</h2>

     <div class="fullcontent">
       
                <div class="btm-tab-btn ptr LocoSelect">متن پیام</div>
                <div id="Div1" runat="server" style="float: left;position: relative;top: 20px;"><i class="icon-calendar"></i> <% = MessageDate%></div>     
                <div class="contenttext" style="margin-top:10px;margin-bottom:10px;">
                <span style="float:right;margin:15px;">
                
                    <%= MessageText%>
                    </span>
                <div class="clear">
                </div>
            </div>
            </div>
        
</asp:Content>
