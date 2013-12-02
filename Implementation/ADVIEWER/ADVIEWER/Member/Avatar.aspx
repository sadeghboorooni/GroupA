<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="Avatar.aspx.cs" Inherits="ADVIEWER.Member.WebForm1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
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
    var validFilesTypes = ["jpeg", "jpg", "png", "gif"];
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



  <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
                <cc1:AsyncFileUpload runat="server" ID="AsyncImageUpload" Width="400px" 
                CompleteBackColor="White" ThrobberID="imgLoader" 
                OnUploadedComplete="AsyncImageUpload_UploadedComplete" 
                OnClientUploadComplete = "ClientUploadComplete" ClientIDMode="AutoID" 
                Height="20px" UploaderStyle="Traditional"  />
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
    <asp:Button ID="saveImage" runat="server" onclick="SaveImage_Click" class ="btn btn-primary"
        Text="ذخیره" />
</asp:Content>