<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AddNewTicket.aspx.cs" Inherits="ADVIEWER.Member.AddNewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2>ایجاد تیکت جدید</h2>

<div class="contenttext" style="background: #fafafa;">
            <asp:Literal ID="SuccessMessage" Visible ="false" runat="server" ></asp:Literal>
                <label class="title">
                    <span class="ess">×</span>موضوع</label>
                <asp:TextBox ID="SubjectText" runat="server" MaxLength="70" Width="410"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="SubjectText" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                
                <label class="title" style="vertical-align:top">
                    <span class="ess">×</span>پیام</label>
                <asp:TextBox ID="MessageText" runat="server" style="resize:none" TextMode="MultiLine" Width="410" Height="100"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="required"
                    ControlToValidate="MessageText" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
               
                <center>
                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="ارسال"
                        ValidationGroup="required" />
                    <a href="MemberDefault.aspx" class="btn btn-primary" >انصراف</a>
                </center> 
     
            </div>
            <div class="clear">
            </div>

</asp:Content>
