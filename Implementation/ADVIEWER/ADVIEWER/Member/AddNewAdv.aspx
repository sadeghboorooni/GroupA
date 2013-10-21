<%@ Page Title="" Language="C#" MasterPageFile="~/member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AddNewAdv.aspx.cs" Inherits="ADVIEWER.Member.AddNewAdv" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../src/jquery.tokeninput.js"></script>

    <link rel="stylesheet" href="../styles/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../styles/token-input-facebook.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        درج آگهی جدید</h2>
    <asp:Literal ID="SuccessMessage" Visible ="false" runat="server" ></asp:Literal>
    <asp:Literal ID="ltr_error" runat="server"></asp:Literal>
        
        <div class="contenttext">

        <p>
            پرکردن قسمت هایی که با × مشخص شده اند الزامی است.</p>
       <span class="title"><span class="ess">×</span>نوع و مدت آگهی</span>
                <asp:DropDownList ID="AdvKindDrop" CssClass="MyCss" Width="180px" onchange="fill_capital(this.selectedIndex);"
                    runat="server">
                    <asp:ListItem Value="-1">آگهی عادی</asp:ListItem>
                    
                </asp:DropDownList>
                &nbsp;&nbsp; به مدت &nbsp;&nbsp;
                <asp:DropDownList ID="MonthDrop" CssClass="MyCss" Width="180px" runat="server">
                    <asp:ListItem Value="1">یک ماه</asp:ListItem>
                    <asp:ListItem Value="2">دو ماه</asp:ListItem>
                    <asp:ListItem Value="3">سه ماه</asp:ListItem>
                </asp:DropDownList>
             
               
                <div class="spacer">
                </div>
                <label class="title" for="ctl00_content_txtOnvan">
                    <span class="ess">×</span>عنوان آگهی</label>
                <asp:TextBox ID="AdvTitleTxt" runat="server" MaxLength="70" Width="410"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="AdvTitleTxt" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <p class="helper">
                    راهنما: عنوان آگهی خود را به گونه ای واضح و جمله معنی دار بنویسید. کلمات کلیدی(اصلی)
                    را در عنوان به کار ببرید. از تکرار بی مورد کلمات کلیدی پرهیز کنید. بهترین تعداد
                    حروف، حداکثر 60 کاراکتر است.<br />
                </p>
                <label class="title" for="ctl00_content_txtDesciption">
                    توضیحات کوتاه آگهی</label>
                <asp:TextBox ID="AdvShorttxt" runat="server" MaxLength="170" Width="410"></asp:TextBox>
                <p class="helper">
                    راهنما: توضیحی کوتاه و کمی متفاوت با عنوان اصلی و حداکثر 170 کاراکتر وارد کنید.
                    <br />
                    این توضیح کوتاه در جستجو معرف آگهی شماست و <b>از اهمیت بسیار بالایی برخوردار است.</b>
                </p>
                <label class="title" for="ctl00_content_txtText" style="vertical-align:top">
                    <span class="ess">×</span>متن آگهی</label>
                <asp:TextBox ID="AdvTexttxt" runat="server" style="resize:none" TextMode="MultiLine" Width="410" Height="250"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="required"
                    ControlToValidate="AdvTexttxt" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <p class="helper">
                    راهنما: متن آگهی خود را کامل و واضح بیان کنید. این متن تنها راه متقاعد کردن بازدید
                    کننده است. پس از به کار بردن اصطلاحات و جملات نا آشنا خود داری کنید. کلمات کلیدی
                    خود را به جا و هوشمندانه به کار ببرید.
                    <br />
                </p>
                <div class="spacer">
                </div>
    <span class="title">
        کلمات کلیدی آگهی</span>
    <p align="right" dir="rtl">
        <asp:TextBox ID="KeyWordtxt" ClientIDMode="Static" runat="server" Height="24px" Width="420px"></asp:TextBox>
        
        <script type="text/javascript">
            $(document).ready(function () {
                $("#KeyWordtxt").tokenInput("../Codes/JsonMaker.aspx?entity=keyword", {
                    theme: "facebook", preventDuplicates: true, allowFreeTagging: true
            });
            });
        </script>
    
    </p><p class="helper">
                    راهنما: کلمات کلیدی، کلمات یا عباراتی است که کاربران برای یافتن کالا و یا خدمات
                    شما آن ها را در موتور های جستجو به کار می برند. انتخاب کلمات کلیدی
                    مناسب تاثیر بسیاری در افزایش بازدید آگهی شما دارد.
                    <br />
                    کلمات کلیدی موجود در سایت به شما پیشنهاد می شود. در صورت تمایل برای اضافه کردن کلمات جدید بعد از تایپ آن علامت "=" را اضافه کرده یا دکمه ی Tab را بفشارید.
                    <br />
                </p>
                <label class="title" for="ctl00_content_txtPrice">
                    قیمت</label>
                <asp:TextBox ID="Pricetxt" runat="server" MaxLength="190" Width="250"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator3" ValidationGroup="required" Display="Dynamic" ValidationExpression="[0-9]*( ری.ل| تومان)*" runat="server" ErrorMessage="قیمت وارد شده صحیح نیست" ControlToValidate="Pricetxt"></asp:RegularExpressionValidator>
                <p class="helper">
                    راهنما: در صورتی که کالای یا خدمات شما قیمت مشخصی دارد، آن را وارد کنید.
                    <br />
                    ریال یا تومان را نیز می توانید وارد کنید.
                </p>
                <label class="title" for="ctl00_content_txtLink">
                    لینک مرتبط</label>
                <asp:TextBox ID="Linktxt" runat="server" MaxLength="900" CssClass="ltr" Text="http://"
                    Width="250"></asp:TextBox>
                <p class="helper">
                    راهنما: اگر وب سایتی حاوی توضیحات بیشتر در مورد آگهی خود دارید، آدرس آن را وارد
                    کنید.<br />
                    //:http را حتما وارد کنید
                </p>
                <label class="title" for="ctl00_content_FileUpload1">
                    عکس آگهی</label>
            <asp:AsyncFileUpload ID="PictureAsyncFileUpload" OnUploadedComplete="PictureAsyncFileUpload_UploadedComplete" runat="server" />
                
                <p class="helper">
                    راهنما: عکسی که در تمام صفحات برای آگهی شما نمایش داده میشود.<br />
                    1) سایز عکس نباید بیشتر از 50Kb باشد<br />
                    2) حداکثر طول و عرض عکس 400 پیکسل باشد.<br />
                    3) عکس ارسالی با فرمتهای jpg, gif, png باشد<br />
                    4) عکس باید با موضوع آگهی شما مطابقت داشته باشد
                </p>
                <h3 style="font-size:25px;margin-bottom:5px">
                    اطلاعات آگهی دهنده</h3>
                <hr style="margin-top:5px"/>
                <label class="title" for="ctl00_content_txtName">
                    <span class="ess">×</span>نام ارسال کننده</label>
                <asp:TextBox ID="Nametxt" runat="server" MaxLength="100" Width="250"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" ValidationGroup="required"
                    ControlToValidate="Nametxt" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <br />
                <label class="title" for="ctl00_content_txtMob">
                    موبایل</label>
                <asp:TextBox ID="Mobiletxt" runat="server" MaxLength="50" CssClass="ltr" Width="250"></asp:TextBox>
                <br />
                <label class="title" for="ctl00_content_txtTell">
                    تلفن تماس</label>
                <asp:TextBox ID="Telltxt" runat="server" MaxLength="50" CssClass="ltr" Width="250"></asp:TextBox>
                <br />
                <label class="title" for="ctl00_content_txtTell">
                    دورنگار</label>
                <asp:TextBox ID="Faxtxt" runat="server" MaxLength="50" CssClass="ltr" Width="250"></asp:TextBox>
                <br />
                <label class="title" for="ctl00_content_txtTellTime">
                    تماس در ساعات</label>
                <asp:TextBox ID="TellTimetxt" runat="server" MaxLength="100" Text="8 صبح تا 2 بعدازظهر"
                    Width="250"></asp:TextBox>
                <br />
                <label class="title" for="ctl00_content_txtMail">
                   <span class="ess">×</span>ایمیل</label>
                <asp:TextBox ID="Emailtxt" runat="server" MaxLength="100" CssClass="ltr" Width="250"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator3" ValidationGroup="required"
                    ControlToValidate="Emailtxt" runat="server" ErrorMessage="<b>×</b>" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    style="color:Red" ID="RegularExpressionValidator1" ValidationGroup="required" Display="Dynamic" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" runat="server" ErrorMessage="ایمیل وارد شده صحیح نیست." ControlToValidate="Emailtxt"></asp:RegularExpressionValidator>
                <br />
                <label class="title" for="ctl00_content_txtYahooID">
                    شناسه یاهو</label>
                <asp:TextBox ID="YahooIDtxt" runat="server" MaxLength="100" CssClass="ltr" Width="250" placeholder="مثال:JohsSmith@yahoo.com" onfocus="this.placeholder=''" onblur="this.placeholder='مثال:JohsSmith@yahoo.com'"></asp:TextBox>
                    <asp:RegularExpressionValidator
                    style="color:Red" ID="RegularExpressionValidator2" ValidationGroup="required" Display="Dynamic" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@yahoo.com" runat="server" ErrorMessage="شناسه وارد شده صحیح نیست." ControlToValidate="YahooIDtxt"></asp:RegularExpressionValidator>
                <p class="helper">
                    راهنما: در صورتی که آیدی یاهو دارید وارد نمایید. اگر کاربری آگهی شما را ببیند و
                    شما در آن لحظه آنلاین باشید، میتواند با شما چت کند و سریع تر به جواب برسد.
                </p>
                <label class="title top" for="ctl00_content_txtAddress" style="vertical-align:top">
                    آدرس</label>
                <asp:TextBox ID="Addresstxt" runat="server" style="resize:none" MaxLength="1000" TextMode="MultiLine"
                    Width="250"></asp:TextBox>
                
                <center>
                    <asp:Button ID="Button1" class="btn btn-primary" style="text-shadow:none" runat="server" OnClick="Button1_Click" Text="ذخیره آگهی"
                        ValidationGroup="required" />
                    <a href="MemberDefault.aspx" class="btn btn-primary" style="text-shadow:none">انصراف</a>
                </center>
            </div>
            <div class="clear">
            </div>
</asp:Content>
