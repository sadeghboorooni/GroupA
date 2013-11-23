<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="EditStateCity.aspx.cs" Inherits="ADVIEWER.Manage.EditStateCity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ویرایش استان و شهر</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    

        <div class="fullcontent">
        <h2 class="title green">
            ویرایش استان و شهر</h2>
        <div class="bordered">
          
                <label class="title" >نام</label>
                <asp:TextBox ID="NameTextBox" Width="340" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="NameTextBox" runat="server" ErrorMessage="×" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <br />
                <%--<label class="title">توضیحات</label>
                <asp:TextBox ID="DescriptonTextBox" TextMode="MultiLine" Height="100" Width="340" MaxLength="2000" runat="server"></asp:TextBox><br />--%>
                <label class="title" for="parentsDropDownList">
                    استان</label>
                <asp:DropDownList ID="statesDropDownList" ClientIDMode="Static" Width="360" runat="server">
                </asp:DropDownList>
              
                <br />
                <div class="sp"></div>
                
                <asp:Button ID="submitButton" runat="server" ValidationGroup="required" 
                    Text="ذخیره" onclick="submitButton_Click" />
         
             
        </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>