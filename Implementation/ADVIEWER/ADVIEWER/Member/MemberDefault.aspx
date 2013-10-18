<%@ Page Title="" Language="C#" MasterPageFile="~/member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="MemberDefault.aspx.cs" Inherits="ADVIEWER.member.MemberDefault" %>
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
                <a href="#">
                    <img src="Images/List.png" alt="" />
                    <h6>
                        لیست آگهی ها</h6>
                </a>
            </div>
            <p>
                مشاهده و مدیریت آگهی های درج شده توسط شما.</p>
            <div class="clear">
            </div>
        </div>
        <div class="groups rounded">
            <div class="right">
                <a href="#">
                    <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                    <img src="Images/Email.png" alt="" />
                    <h6>
                        صندوق پیام</h6>
                </a>
            </div>
            <p>
                پیام های دریافتی خود را مشاهده کنید.</p>
            <div class="clear">
            </div>
        </div>
        
        <div class="groups rounded">
            <div class="right">
                <a href="#">
                    <asp:Literal ID="ltrticket" runat="server"></asp:Literal>
                    <img src="Images/Ticket.png" alt="" />
                    <h6>
                        تیکت پشتیبانی</h6>
                </a>
            </div>
            <p>هر مشکل، سوال و نظری دارید از ما بپرسید و پیگیری کنید.</p>
            <div class="clear">
            </div>
        </div>



        <div class="groups rounded">
            <div class="right">
                <a href="#">
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
                رمز ورود به حساب کاربری خود را تغییر دهید</p>
            <div class="clear">
            </div>
        </div>
        <div class="groups rounded">
            <div class="right">
                <a href='#'>
                    <img src="Images/Help.png" alt="" />
                    <h6>
                        راهنمای درج آگهی</h6>
                </a>
            </div>
            <p>
                برای افزایش رتبه و آمار بازدید آگهی خود این راهنما را مطالعه کنید.</p>
            <div class="clear">
            </div>
        </div>
        <div class="groups rounded">
            <div class="right">
                <a href="logout.aspx">
                    <img src="Images/Exit.png" alt="" />
                    <h6>
                        خروج</h6>
                </a>
            </div>
            </div>
        
</asp:Content>
