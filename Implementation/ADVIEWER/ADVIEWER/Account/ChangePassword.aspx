<%@ Page Title="تغییر رمز عبور" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="ADVIEWER.Account.ChangePassword" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="../Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
        <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    </asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        تغییر رمز عبور
    </h2>
    <p>
        رمز جدید باید دارای حداقل <%= Membership.MinRequiredPasswordLength %> کاراکتر باشد.
    </p>
    <asp:ChangePassword ID="ChangeUserPassword" ChangePasswordFailureText="رمز عبور فعلی و یا رمز عبور جدید اشتباه وارد شده است."  ContinueDestinationPageUrl="../Member/MemberDefault.aspx" ContinueButtonStyle-CssClass="btn btn-primary" ContinueButtonText="ادامه" SuccessTitleText="" SuccessText="رمز عبور شما با موفقیت تغییر یافت." SuccessTextStyle-CssClass="alert alert-success" SuccessTextStyle-Font-Size="17px" runat="server" CancelDestinationPageUrl="../member/MemberDefault.aspx" EnableViewState="false" RenderOuterTable="false" >
        <ChangePasswordTemplate>
            <div class="failureNotification" style="color: #b94a48;font-size:17px">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        
            </div>
            <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ChangeUserPasswordValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="changePassword">
                    <legend>اطلاعات کاربری </legend>
                    <p>
                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">رمز عبور فعلی: </asp:Label>
                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                             CssClass="failureNotification" ErrorMessage="رمز عبور فعلی را وارد کنید." ToolTip="رمز عبور فعلی را وارد کنید." 
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">رمز عبور جدید: </asp:Label>
                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                             CssClass="failureNotification" ErrorMessage="رمز عبور جدید را وارد کنید." ToolTip="رمز عبور جدید را وارد کنید." 
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">تکرار رمز عبور جدید: </asp:Label>
                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="تکرار رمز عبور جدید را وارد کنید."
                             ToolTip="تکرار رمز عبور جدید را وارد کنید." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="تکرار رمز عبور جدید با رمز عبور جدید یکسان نیست."
                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                    </p>
                </fieldset>
                <p class="submitButton">
                   
                    <asp:Button ID="ChangePasswordPushButton" runat="server" CssClass="btn btn-primary" CommandName="ChangePassword" Text="تغییر رمز" 
                         ValidationGroup="ChangeUserPasswordValidationGroup"/>
                          <asp:Button ID="CancelPushButton" runat="server" CssClass="btn btn-primary" CausesValidation="False" CommandName="Cancel" Text="انصراف"/>
                </p>
            </div>
        </ChangePasswordTemplate>
    </asp:ChangePassword>
</asp:Content>
