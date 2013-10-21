<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ADVIEWER.Member.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 <div class="adv">
        <div class="contenttext" style="margin:15px;line-height:30px">
           <div class="alert alert-success" style="font-size:18px;background:#e5ffd5 url('../images/Submit.png') no-repeat right center;padding-right:40px;display:inline-block" runat="server" id="msg" visible="false">
                مشخصات شما ذخیره شد.
            </div>
            <h2 class="alert hero-unit" >ویرایش مشخصات کاربری</h2>
            <hr /> 
            <div class="left leftinfo" >
            این اطلاعات در هنگام درج آگهی، برای مشخصات آگهی دهنده استفاده می شوند.<br />
            همچنین در 
                <asp:Literal ID="ltrprofile" runat="server"></asp:Literal> این اطلاعات نمایش داده می شوند.
            <br /> 
            <i class="icon-ok"></i> نام می تواند نام شخصی شما، نام شرکت شما و ... باشد.
            <br />

            <label >ایمیل</label>
            <div style="width:227px; background:#f9f9f9; padding:0px 6px; direction:ltr; float:right; margin-left:47px;">
                <asp:Literal ID="ltrmail" runat="server"></asp:Literal>
            </div>
            <br /> 
            <label ><span class="ess">×</span>نام کامل</label>
            <asp:TextBox ID="txtName" Width="220" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="required"
                    ControlToValidate="txtName" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator><br />
            
            <label >موبایل </label>
            <asp:TextBox ID="txtMob" Width="220" runat="server"></asp:TextBox><br />

            
            <label >تلفن </label>
            <asp:TextBox ID="txtTell" Width="220" runat="server"></asp:TextBox><br />
            
            <label >دورنگار </label>
            <asp:TextBox ID="txtfax" Width="220" runat="server"></asp:TextBox><br />
            
            <label >شناسه یاهو</label>
            <asp:TextBox ID="txtYahoo" Width="220" placeholder="مثال:JohnSmith@yahoo.com" onfocus="this.placeholder=''" onblur="this.placeholder='مثال:JohnSmith@yahoo.com'" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" style="padding-right:5px;vertical-align:3px;color:Red" ValidationGroup="required" Display="Dynamic" 
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@yahoo.com" runat="server"  ErrorMessage="شناسه وارد شده صحیح نیست." ControlToValidate="txtYahoo"></asp:RegularExpressionValidator>
            <br />
            <label class="top">درباره </label>
            <asp:TextBox ID="txtAbout" TextMode="MultiLine" style="resize:none" Width="220" runat="server"></asp:TextBox><br />
            <label  class="top">آدرس </label>
            <asp:TextBox ID="txtAddress" TextMode="MultiLine" style="resize:none" Width="220" runat="server"></asp:TextBox><br />
            
            <div class="spacer"></div>
            <center><asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" ValidationGroup="required" Text="ذخیــره" /></center>
            <div class="clear">
            </div>
        </div>
    </div>
    </div>
</asp:Content>
