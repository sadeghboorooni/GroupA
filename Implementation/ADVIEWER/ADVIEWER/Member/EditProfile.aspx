<%@ Page Title="ویرایش مشخصات کاربری" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="ADVIEWER.Member.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script src="../Scripts/jquery.tokeninputforfavoritegroup.js" type="text/javascript"></script>

    <link rel="stylesheet" href="../styles/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../styles/token-input-facebook.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
 <div class="adv">
 <h2 class="alert hero-unit memberheader" >ویرایش مشخصات کاربری</h2>
 <div class="alert alert-success" style="font-size:17px;display:inline-block" runat="server" id="msg" visible="false">
                مشخصات شما ذخیره شد.
            </div>
        <div class="contenttext" style="margin:15px;line-height:30px">
        <div class="left leftinfo" >
        <span class="title">
        افزودن علاقه مندی ها
        </span>
        <div class="clear"></div>
        <div>
         در این قسمت شما می توانید از بین دسته بندی های موجود حداکثر
          <span style="color:Red;font-size:20px;">3</span> 
          دسته بندی را به عنوان دسته بندی های موردعلاقه ی خود انتخاب کنید.
     این کار موجب خواهد شد تا تبلیغات صفحه ی اول بر اساس این علاقه مندی ها نمایش داده شود.
        </div>
            <asp:TextBox ID="FavGrouptxt" ClientIDMode="Static" runat="server" Height="24px" Width="420px"></asp:TextBox>
        
        <script type="text/javascript">
            $(document).ready(function () {
                $("#FavGrouptxt").tokenInput("../BAL/JsonMaker.aspx?entity=favoritegroup", {
                    theme: "facebook", preventDuplicates: true, tokenLimit: 3, prePopulate: <%= UserFavoriteGroups %>
                });
            });
        </script>

            </div>
        </div>

        <div class="contenttext" style="margin:15px;line-height:30px">
            
            <div class="left leftinfo" >
            این اطلاعات در هنگام درج آگهی، برای مشخصات آگهی دهنده استفاده می شوند.<br />
            همچنین در 
                <asp:Literal ID="ltrprofile" runat="server"></asp:Literal> این اطلاعات نمایش داده می شوند.
            <br /> 
            <i class="icon-ok"></i> نام می تواند نام شخصی شما، نام شرکت شما و ... باشد.
            <br />

            <span class="title" >ایمیل</span>
            <div class="clear"></div>
            <div class="EmailViewer" style="background:#f9f9f9; padding:0px 6px;display:inline-block">
                <asp:Literal ID="ltrmail" runat="server"></asp:Literal>
            </div>
            <br /> 
            <span class="title"><span class="ess">×</span>نام کامل</span>
            <div class="clear"></div>
            <asp:TextBox ID="txtName" Width="220" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="required"
                    ControlToValidate="txtName" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator><br />
            
            <span class="title" >موبایل </span>
            <div class="clear"></div>
            <asp:TextBox ID="txtMob" Width="220" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator4" ValidationGroup="required" Display="Dynamic" style="color:Red" ValidationExpression="[0][9][0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+" runat="server" ErrorMessage="شماره ی وارد شده صحیح نیست" ControlToValidate="txtMob"></asp:RegularExpressionValidator>
            <br />

            <span class="title" >تلفن </span>
            <div class="clear"></div>
            <asp:TextBox ID="txtTell" Width="220" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator5" ValidationGroup="required" Display="Dynamic" style="color:Red" ValidationExpression="[0][0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+" runat="server" ErrorMessage="شماره ی وارد شده صحیح نیست" ControlToValidate="txtTell"></asp:RegularExpressionValidator>
            <br />
            
            <span class="title" >دورنگار </span>
            <div class="clear"></div>
            <asp:TextBox ID="txtfax" Width="220" runat="server"></asp:TextBox><br />
            
            <span class="title" >شناسه یاهو</span>
            <div class="clear"></div>
            <asp:TextBox ID="txtYahoo" Width="220" placeholder="مثال:JohnSmith@yahoo.com" onfocus="this.placeholder=''" onblur="this.placeholder='مثال:JohnSmith@yahoo.com'" runat="server"></asp:TextBox>
               <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" style="padding-right:5px;vertical-align:3px;color:Red" ValidationGroup="required" Display="Dynamic" 
                    ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@yahoo.com" runat="server"  ErrorMessage="شناسه وارد شده صحیح نیست." ControlToValidate="txtYahoo"></asp:RegularExpressionValidator>
            <br />
            <span class="title">درباره </span>
            <div class="clear"></div>
            <asp:TextBox ID="txtAbout" TextMode="MultiLine" style="resize:none" Width="220" runat="server"></asp:TextBox><br />
            <span class="title">آدرس </span>
            <div class="clear"></div>
            <asp:TextBox ID="txtAddress" TextMode="MultiLine" style="resize:none" Width="220" runat="server"></asp:TextBox><br />
            
            <div class="spacer"></div>
            <center><asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn btn-primary" runat="server" ValidationGroup="required" Text="ذخیــره" /></center>
            <div class="clear">
            </div>
        </div>
    </div>
    </div>

</asp:Content>
