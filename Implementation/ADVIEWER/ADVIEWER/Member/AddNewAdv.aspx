<%@ Page Title="" Language="C#" MasterPageFile="~/member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AddNewAdv.aspx.cs" Inherits="ADVIEWER.Member.AddNewAdv" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../src/jquery.tokeninput.js"></script>

    <link rel="stylesheet" href="../styles/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../styles/token-input-facebook.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div dir="rtl" style="height: 101px">
    <h2 align="right" dir="rtl">
        درج آگهی جدید</h2>
        <p align="right" dir="rtl">
            &nbsp;</p>
    <asp:Literal ID="ltr_error" runat="server"></asp:Literal>
    
        </div>
    
        <p align="right" dir="rtl">
            پرکردن قسمت هایی که با × مشخص شده اند الزامی است.</p>
        <p dir="rtl">
            نوع و مدت آگهی  
            <asp:DropDownList ID="AdvKindDrop" runat="server">
                <asp:ListItem Value="-1">آگهی عادی</asp:ListItem>
            </asp:DropDownList>
        &nbsp; به مدت&nbsp;
            <asp:DropDownList ID="MonthDrop" runat="server">
                <asp:ListItem Value="1">یک ماه</asp:ListItem>
                <asp:ListItem Value="2">دو ماه</asp:ListItem>
                <asp:ListItem Value="3">سه ماه</asp:ListItem>
            </asp:DropDownList>
    </p>
    <p align="right" dir="rtl">
        راهنما: با توجه به نیاز خود و شرح تعرفه ها نوع آگهی و مدت آن را انتخاب کنید.
    </p>
    <p align="right" dir="rtl">
        عنوان آگهی
        <asp:TextBox ID="AdvTitleTxt" runat="server" Width="321px"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        راهنما: عنوان آگهی خود را به گونه ای واضح و جمله معنی دار بنویسید. کلمات 
        کلیدی(اصلی) را در عنوان به کار ببرید. از تکرار بی مورد کلمات کلیدی پرهیز کنید. 
        بهترین تعداد حروف، حداکثر 60 کاراکتر است.</p>
    <p align="right" dir="rtl">
        توضیحات کوتاه آگهی
        <asp:TextBox ID="AdvShorttxt" runat="server" Width="420px"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        راهنما: توضیحی کوتاه و کمی متفاوت با عنوان اصلی و حداکثر 170 کاراکتر وارد کنید.
        <br />
        این توضیح کوتاه در جستجوی گوگل معرف آگهی شماست و <b>از اهمیت بسیار بالایی 
        برخوردار است.</b> </p>
    <p align="right" dir="rtl">
        متن آگهی</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="AdvTexttxt" runat="server" Height="156px" TextMode="MultiLine" 
            Width="438px"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        راهنما: متن آگهی خود را کامل و واضح بیان کنید. این متن تنها راه متقاعد کردن 
        بازدید کننده است. پس از به کار بردن اصطلاحات و جملات نا آشنا خود داری کنید. 
        کلمات کلیدی خود را به جا و هوشمندانه به کار ببرید. </p>
    <p align="right" dir="rtl">
        کلمات کلیدی آگهی</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="KeyWordtxt" ClientIDMode="Static" runat="server" Height="24px" Width="420px"></asp:TextBox>
        
        <script type="text/javascript">
            $(document).ready(function () {
                $("#KeyWordtxt").tokenInput("~/Codes/JsonMaker.aspx?entity=keyword", {

                    theme: "facebook", preventDuplicates: true, allowFreeTagging: true
            });
            });
        </script>
    
    </p>
    <p align="right" dir="rtl">
        راهنما: کلمات کلیدی، کلمات یا عباراتی است که کاربران برای یافتن کالا و یا خدمات 
        شما آن ها را در موتور های جستجو و یا سایت نیازجو به کار میبرند. انتخاب کلمات 
        کلیدی مناسب تاثیر بسیاری در افزایش بازدید آگهی شما دارد.
        <br />
        کلمات کلیدی 
        موجود در سایت به شما پیشنهاد داده می شوند. در صورت تمایل برای اضافه کردن کلمه 
        جدید بعد از تایپ آن علامت = را اضافه کنید یا Tab را بفشارید. </p>
    <p align="right" dir="rtl">
        قیمت</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="Pricetxt" runat="server" Width="299px"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        راهنما: در صورتی که کالای یا خدمات شما قیمت مشخصی دارد، آن را وارد کنید.</p>
    <p align="right" dir="rtl">
        لینک مرتبط</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="Linktxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        عکس مرتبط</p>
    <p align="right" dir="rtl">
        <asp:FileUpload ID="AdvPicUpload" runat="server" />
    </p>
    <p align="right" dir="rtl">
        اطلاعات آگهی دهنده</p>
    <p align="right" dir="rtl">
        نام ارسال کننده</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="Nametxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        موبایل</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="Mobiletxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        تلفن تماس&nbsp;&nbsp;&nbsp; </p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="Teletxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        تماس در ساعات</p>
    <p align="right" dir="rtl">
        <asp:TextBox ID="TellTimetxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        ایمیل<asp:TextBox ID="Emailtxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        یاهو آیدی<asp:TextBox ID="YahooIDtxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        آدرس<asp:TextBox ID="Addresstxt" runat="server"></asp:TextBox>
    </p>
    <p align="right" dir="rtl">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
    </p> 
</asp:Content>
