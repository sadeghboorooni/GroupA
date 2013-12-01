<%@ Page Title="ثبت نام" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="ADVIEWER.Account.Register" %>

    <asp:Content ContentPlaceHolderID="head" runat="server">
        <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
        <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
                        عضویت در سایت
                    </h2>
                    <p>
                        برای عضویت در سایت اطلاعات زیر را وارد کنید.
                    </p>
                    <p>
                        رمز عبور باید داری حداقل <%= Membership.MinRequiredPasswordLength %> کاراکتر باشد.
                    </p>
                    

    <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false"  InvalidPasswordErrorMessage= "رمز عبور وارد شده باید حداقل 6 کاراکتر باشد." UnknownErrorMessage="خطایی رخ داده است. مجددا تلاش فرمایید." DuplicateEmailErrorMessage="ایمیل وارد شده تکراری است." DuplicateUserNameErrorMessage="نام کاربری وارد شده تکراری است." OnCreateUserError="setErrorStyle" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <div style="margin-top:20px;margin-bottom:15px;">
                        <asp:Label ID="ErrorMessage" Visible="false" runat="server"></asp:Label>
                    </div>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>اطلاعات حساب کاربری</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">نام کاربری: </asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="نام کاربری را وارد کنید." ToolTip="نام کاربری را وارد کنید." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">ایمیل: </asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="ایمیل را وارد کنید." ToolTip="ایمیل را وارد کنید." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">رمز عبور: </asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="رمز عبور را واردکنید." ToolTip="رمز عبور را وارد کنید." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">تکرار رمز عبور: </asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="تکرار رمز عبور را وارد کنید." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="تکرار رمز عبور را وارد کنید." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="رمز عبور و تکرار آن یکسان نیستند."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="CreateUserButton" runat="server" CssClass="btn btn-primary" CommandName="MoveNext" Text="تایید" 
                                 ValidationGroup="RegisterUserValidationGroup"/>
                        </p>
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>
