<%@ Page Title="صفحه کاربری" Language="C#" MasterPageFile="~/member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="MemberDefault.aspx.cs" Inherits="ADVIEWER.member.MemberDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 <div class="groups rounded">
            <div class="right">
                <a href='AddNewAdv.aspx'>
                    <img src="Images/NewAdv.png" alt="" />
                    <h6>
                        آگهی جدید</h6>
                </a>
            </div>
            <p>
                برای درج آگهی و تبلیغات خود کلیک کنید.</p>
            <div class="clear">
            </div>
        </div>
        
        <div class="groups rounded">
            <div class="right">
                <a href='AdvsList.aspx'>
                    <img src="Images/AdvsList.png" alt="" />
                    <h6>
                        لیست آگهی‏ها</h6>
                </a>
            </div>
            <p>
                برای مشاهده آگهی و تبلیغات خود کلیک کنید.</p>
            <div class="clear">
            </div>
        </div>

         <div class="groups rounded">
            <div class="right">
                <a href="TicketsList.aspx">
                    <img src="Images/Ticket.png" alt="" />
                    <h6>
                        لیست تیکت‏ها</h6>
                </a>
            </div>
            <p>
                سوالات خود را از مدیر سایت بپرسید.</p>
            <div class="clear">
            </div>
        </div>

        <div class="groups rounded">
            <div class="right">
                <a href="EditProfile.aspx">
                    <img src="Images/User-Info.png" alt="" />
                    <h6>
                        ویرایش مشخصات</h6>
                </a>
            </div>
            <p>
                مشخصات عمومی خود را ویرایش کنید.</p>
            <div class="clear">
            </div>
        </div>
        <div class="groups rounded">
            <div class="right">
                <a href="../Account/ChangePassword.aspx">
                    <img src="Images/ChangePassword.png" alt="" />
                    <h6>
                        تغییر رمز ورود</h6>
                </a>
            </div>
            <p>
                رمز ورود به حساب کاربری خود را تغییر دهید.</p>
            <div class="clear">
            </div>
        </div>
             
        <div class="groups rounded">
            <div class="right">
                <asp:LinkButton runat="server" OnClick = "ExitFuction">
                    <img src="Images/Exit.png" alt="" />
                    <h6>
                        خروج</h6>
                </asp:LinkButton>
            </div>
            <p>
            خروج امن از سایت و پاک کردن اطلاعات ورود شما.
            </p>
            </div>
        
</asp:Content>
