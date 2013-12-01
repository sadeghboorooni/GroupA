<%@ Page Title="ویرایش گروه آگهی" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="EditGroup.aspx.cs" Inherits="ADVIEWER.Manage.EditGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ویرایش گروه آگهی</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    

        <div class="fullcontent">
        <h2 class="title green">
            ویرایش گروه آگهی</h2>
        <div class="bordered">
          
                <label class="title" >عنوان</label>
                <asp:TextBox ID="titleTextBox" Width="340" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="titleTextBox" runat="server" ErrorMessage="×" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <br />
                <label class="title" for="ctl00_content_DropDownList1">
                    گروه والد</label>
                <asp:DropDownList ID="parentsDropDownList" Width="360" runat="server">
                </asp:DropDownList>
              
                <br />
                <div class="sp"></div>
                
                <asp:Button ID="submitButton" runat="server" ValidationGroup="required" 
                    Text="ذخیره" onclick="submitButton_Click" />
         
             
        </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>