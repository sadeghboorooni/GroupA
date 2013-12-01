<%@ Page Title="ورود" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="ADVIEWER.Account.Login" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
        <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
         ورود با حساب کاربری
    </h2>
    <p>
        لطفا نام کاربری و رمز عبور خود را وارد کنید.
        اگر عضو نیستید<asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">عضو شوید</asp:HyperLink>.
    </p>
    <asp:Literal ID="ErrorMessage" Visible ="false" runat="server" ></asp:Literal>

    <asp:Login ID="LoginUser" OnLoginError="setError" runat="server" EnableViewState="false" OnLoggedIn="LoginUser_LoggedIn" DestinationPageUrl = "~/member/MemberDefault.aspx" RenderOuterTable="false">
        <LayoutTemplate>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>اطلاعات کاربری</legend>
                    <p>
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">نام کاربری: </asp:Label>
                        <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="نام کاربری را وارد کنید." ToolTip="نام کاربری را وارد کنید." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">رمز عبور: </asp:Label>
                        <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="رمز عبور را وارد کنید." ToolTip="رمز عبور را وارد کنید." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:CheckBox ID="RememberMe" runat="server"/>
                        <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" style="display:inline;vertical-align:-2px">مرا به خاطر بسپار</asp:Label>
                    </p>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" CommandName="Login" Text="ورود" ValidationGroup="LoginUserValidationGroup"/>
                </p>
            </div>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
