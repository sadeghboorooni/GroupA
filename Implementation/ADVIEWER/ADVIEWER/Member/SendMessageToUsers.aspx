<%@ Page Title="ارسال پیام" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="SendMessageToUsers.aspx.cs" Inherits="ADVIEWER.Member.SendMessageToUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery.tokeninput.js"></script>

    <link rel="stylesheet" href="../styles/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../styles/token-input-facebook.css" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

 <h2 class="alert hero-unit memberheader">
        ارسال پیام به کاربران</h2>

        <asp:Literal ID="SuccessMessage" runat="server" Visible = "false"></asp:Literal>

        <div class="contenttext" style="padding:15px">
        
 <div style="font-size:17px;margin-bottom:5px;color:CornflowerBlue">
     <span class="ess">×</span>   انتخاب کاربر:</div>
    <p>
        <asp:TextBox ID="UsersTxt" ClientIDMode="Static" runat="server" Height="24px" Width="420px"></asp:TextBox>
        
        <script type="text/javascript">
            $(document).ready(function () {
                $("#UsersTxt").tokenInput("../BAL/JsonMaker.aspx?entity=user", {
                    theme: "facebook", preventDuplicates: true
                });
            });
        </script>
</p>

  <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="required"
                    ControlToValidate="UsersTxt" runat="server" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>

        <p class="helper">
                 راهنما: برای انتخاب کاربران کافی است نام کاربری آنها را در قسمت بالا وارد کنید. همچنین با نوشتن حروف ابتدایی نام کاربران، نام کامل آنها به شما پیشنهاد داده می شود.

                </p>

                <div class="btm-tab-btn ptr LocoSelect"><span class="ess">×</span>متن پیام</div>
                <div class="contenttext" style="margin-top:10px;margin-bottom:10px;">

                <asp:TextBox ID="MessageContentTxt" Width="98%" CssClass="messagecontent" TextMode="MultiLine"  BorderStyle="None" runat="server"></asp:TextBox>

                <div class="clear">
                </div>
            </div>

<asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="MessageContentTxt" runat="server" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>



            <asp:Button ID="SendMessageBtn" ValidationGroup="required" runat="server" OnClick="SendMessageBtn_Click" CssClass="btn btn-primary" Text="ارسال پیام" />
    </div>

</asp:Content>
