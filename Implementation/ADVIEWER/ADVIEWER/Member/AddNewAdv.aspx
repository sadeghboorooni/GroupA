<%@ Page Title="افزودن آگهی جدید" Language="C#" MasterPageFile="~/member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AddNewAdv.aspx.cs" Inherits="ADVIEWER.Member.AddNewAdv" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery.tokeninput.js"></script>

    <link rel="stylesheet" href="../styles/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../styles/token-input-facebook.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    var errorMessage;
    window.onload = function () {
        errorMessage = $get("<%=lblMesg.ClientID %>").innerHTML;
        $get("<%=lblMesg.ClientID %>").innerHTML = "";
        AjaxControlToolkit.AsyncFileUpload.prototype._onStart = function () {
            var valid = this.raiseUploadStarted(new AjaxControlToolkit.AsyncFileUploadEventArgs(this._inputFile.value, null, null, null));
            if (typeof valid == 'undefined') {
                valid = true;
            }
            if (valid) {
                valid = Validate(this._inputFile.value);
                if (!valid) {
                    //this._innerTB.value = "";
                    //this._innerTB.style.BackColor = "White";
                    $get("dvFileInfo").style.display = 'none';
                    $get("dvFileErrorInfo").style.display = 'block';   
                }
            }
            return valid;
        }
    }
    var validFilesTypes = ["jpeg", "jpg" , "png" , "gif"];
    function Validate(path) {
        $get("dvFileErrorInfo").style.display = 'none';
        $get("<%=lblMesg.ClientID%>").innerHTML = "";
        var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
        var isValidFile = false;
        for (var i = 0; i < validFilesTypes.length; i++) {
            if (ext == validFilesTypes[i]) {
                isValidFile = true;
                break;
            }
        }
        if (!isValidFile) {
            $get("<%=lblMesg.ClientID %>").innerHTML = errorMessage;
        }
        return isValidFile;
    }
    function ClientUploadComplete(sender, args) {
        $get("dvFileErrorInfo").style.display = 'none';
        $get("dvFileInfo").style.display = 'block';
        $get("<%=lblSuccess.ClientID%>").innerHTML = "عکس شما با موفقيت آپلود شد.";
        $get("<%=lblFileNameDisplay.ClientID%>").innerHTML = args.get_fileName();
        $get("<%=lblFileSizeDisplay.ClientID%>").innerHTML = args.get_length();
        $get("<%=lblContentTypeDisplay.ClientID%>").innerHTML = args.get_contentType();
        }
</script>
    <h2 class="alert hero-unit memberheader">
        درج آگهی جدید</h2>
    <asp:Literal ID="SuccessMessage" Visible ="false" runat="server" ></asp:Literal>
    <asp:Literal ID="ltr_error" runat="server"></asp:Literal>
        
        <div class="contenttext">

        <p>
            پرکردن قسمت هایی که با <span class="ess">×</span> مشخص شده اند الزامی است.</p>
       <span class="title"><span class="ess">×</span>نوع آگهی</span>
                <asp:DropDownList ID="AdvKindDrop" CssClass="MyCss" Width="180px" onchange="fill_capital(this.selectedIndex);"
                    runat="server">
                    <asp:ListItem Value="-1">آگهی عادی</asp:ListItem>
                    <asp:ListItem Value="1">ویژه یک ستاره</asp:ListItem>
                    <asp:ListItem Value="2">ویژه دو ستاره</asp:ListItem>
                    
                </asp:DropDownList>
               <span class="title"><span class="ess">×</span>مدت آگهی</span>
                <asp:DropDownList ID="MonthDrop" CssClass="MyCss" Width="180px" runat="server">
                    <asp:ListItem Value="1">یک ماه</asp:ListItem>
                    <asp:ListItem Value="2">دو ماه</asp:ListItem>
                    <asp:ListItem Value="3">سه ماه</asp:ListItem>
                </asp:DropDownList>
                <div class="clear"></div>
                <span class="title" style="padding-left:5px"><span class="ess">×</span>دسته بندی</span>
                <asp:DropDownList ID="groupsDropDownList" Width="430px" runat="server">
                </asp:DropDownList>
                <p class="helper">
                    راهنما: بخشی که از نظر موضوعی بیشترین انطباق با آگهی شما را دارد انتخاب کنید. انتخاب
                    صحیح و دقیق بخش مربوط به آگهی، تاثیر بسزایی در میزان مشاهده آگهی شما دارد.
                </p>
               <span class="title"><span class="ess">×</span>استان و شهر</span>
                <asp:DropDownList ID="StateCityDropDownList" CssClass="MyCss" Width="430px" runat="server">
                </asp:DropDownList>
                <p class="helper">
                    راهنما: در صورتی که خدمات شما در استان و شهر خاصی ارائه می شود، استان و شهر را انتخاب
                    کنید.
                </p>
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
                $("#KeyWordtxt").tokenInput("../BAL/JsonMaker.aspx?entity=keyword", {
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
                    ID="RegularExpressionValidator3" ValidationGroup="required" Display="Dynamic" style="color:Red" ValidationExpression="[0-9]*( ری.ل| تومان)*" runat="server" ErrorMessage="قیمت وارد شده صحیح نیست" ControlToValidate="Pricetxt"></asp:RegularExpressionValidator>
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

                
                <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
                <cc1:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="400px" 
                CompleteBackColor="White" ThrobberID="imgLoader" 
                OnUploadedComplete="AsyncFileUpload1_UploadedComplete" 
                OnClientUploadComplete = "ClientUploadComplete" ClientIDMode="AutoID" 
                Height="20px" UploaderStyle="Traditional"  /><br />
                <asp:Image ID="imgLoader" runat="server" ImageUrl="./Images/loader.gif" />
                <div style=" border: 1px solid #cccccc; display : none ; width: 350px" id="dvFileErrorInfo">
                    <asp:Label ID="lblErrorStatus" Font-Bold="true" runat="server" Text="خطا:" />
                    <asp:Label ID="lblMesg" runat="server" style = "color:red" Text = "فرمت فایل انتخاب شده اشتباه می باشد.یک عکس با فرمت های معرفی شده انتخاب کنید." />
                </div>
                <div style="border: 1px solid #cccccc; display: none; width: 350px" id="dvFileInfo">
                    <asp:Label ID="lblSuccess" runat="server" style = "color:green; font-weight:bold;" /><br />
                    <asp:Label ID="lblFileName" Font-Bold="true" runat="server" Text="نام فايل :" />
                    <asp:Label ID="lblFileNameDisplay" runat="server" /><br />
                    <asp:Label ID="lblFileSize" Font-Bold="true" runat="server" Text="اندازه فايل : " />
                    <asp:Label ID="lblFileSizeDisplay" runat="server" /><br />
                    <asp:Label ID="lblContentType" Font-Bold="true" runat="server" Text="توع فايل :" />
                    <asp:Label ID="lblContentTypeDisplay" runat="server" /><br />
                 </div>

                <p class="helper">
                    راهنما: عکسی که در تمام صفحات برای آگهی شما نمایش داده میشود.<br />
                    1) عکس ارسالی 
                    باید از میان فرمت های jpg, gif, png , jpeg باشد<br />
                    2) عکس باید با موضوع آگهی شما مطابقت داشته باشد
                باشد
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
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator4" ValidationGroup="required" Display="Dynamic" style="color:Red" ValidationExpression="[0][9][0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+" runat="server" ErrorMessage="شماره ی وارد شده صحیح نیست" ControlToValidate="Mobiletxt"></asp:RegularExpressionValidator>
                <br />
                <p class="helper">
                راهنما: برای وارد کردن شماره موبایل و تلفن تماس فقط از اعداد استفاده کنید. همچنین شماره ی موبایل با 09 شروع می شود.
                </p>
                <label class="title" for="ctl00_content_txtTell">
                    تلفن تماس</label>
                <asp:TextBox ID="Telltxt" runat="server" MaxLength="50" CssClass="ltr" Width="250"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator5" ValidationGroup="required" Display="Dynamic" style="color:Red" ValidationExpression="[0][0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+[0-9]+" runat="server" ErrorMessage="شماره ی وارد شده صحیح نیست" ControlToValidate="Telltxt"></asp:RegularExpressionValidator>
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
                    شما در آن لحظه آنلاین باشید، می تواند با شما چت کند و سریع تر به جواب برسد.
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
