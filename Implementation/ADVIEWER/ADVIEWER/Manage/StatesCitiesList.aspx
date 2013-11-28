<%@ Page Title="مدیریت استان ها و شهرها" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="StatesCitiesList.aspx.cs" Inherits="ADVIEWER.Manage.StatesCitiesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>مدیریت استانها و شهرها</title>
        <script>
            function SelectAllCheckboxesstatesCitiesGridView(chk) {
                $('#<%=statesCitiesGridView.ClientID %>').find("input:checkbox").each(function () {
                    if (this != chk) {
                        this.checked = chk.checked;
                    }
                });
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="fullcontent">
        <h2 class="title blue">
            مدیریت استانها و شهرها</h2>
        <div class="bordered">

            <div style="float: right; width: 420px;">
                <h2 style="padding-top:0;">
                    افزودن شهر یا استان</h2>
                <label class="title">نام</label>
                <asp:TextBox ID="CityStateNameTextBox" Width="230" MaxLength="100" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="required"
                    ControlToValidate="CityStateNameTextBox" runat="server" ErrorMessage="×" Display="Dynamic"
                    ToolTip="فیلد الزامی"></asp:RequiredFieldValidator>
                <br />
                <%--<label class="title">توضیحات</label>
                <asp:TextBox ID="descriptionTextBox" TextMode="MultiLine" Height="100" Width="230" MaxLength="2000" runat="server"></asp:TextBox>
                <br />--%>
                
                <label class="title">استان</label>
                <asp:DropDownList ID="StatesDropDownList" Width="250" runat="server">
                </asp:DropDownList>
                <br />
                <div class="sp"></div>
                
                <%--<label class="title" for="ctl00_content_FileUpload1">
                آیکون (فقط گروه اصلی)</label>
                <asp:FileUpload ID="FileUpload1" runat="server"  Width="230"/> 
                <br />
                بهترین آیکون 50*50 و png می باشد.--%>
                
                <div><asp:Button ID="AddCityButton" runat="server" ValidationGroup="required" 
                    Text="افزودن" onclick="AddCityButton_Click" /></div>
            </div>
            <div style="float: left; width: 490px">
             <asp:GridView CssClass="grid" ID="statesCitiesGridView" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID" EnableModelValidation="True" OnRowCommand="statesCitiesGridView_RowCommand" 
                Width="100%" AllowPaging="True" GridLines="None" PageSize="40" 
                 EnableTheming="False" EnableViewState="False"  OnPageIndexChanging="statesCitiesGridView_PageIndexChanging"
                ShowFooter="True" onrowdatabound="statesCitiesGridView_RowDataBound" >
                <AlternatingRowStyle CssClass="alt" />
                <Columns>

                    <%--<asp:TemplateField FooterText="#" HeaderText="#" InsertVisible="False" 
                        SortExpression="ID">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBxSelect" runat="server" Text='<%# Container.DataItemIndex+1 %>'/>
                        </ItemTemplate>
                        <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesstatesCitiesGridView(this);"
                                Text="#" />
                        </HeaderTemplate>
                        <FooterTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesstatesCitiesGridView(this);"
                                Text="#" />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Font-Names="byekan" HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField FooterText="نام" HeaderText="نام" 
                        SortExpression="Name">
                        <HeaderTemplate>
                          عنوان
                        </HeaderTemplate>
                        <ItemTemplate>
                            <a style="font-size:12px;" href='<%# Eval("id","editStateCity.aspx?id={0}") %>' title='<%# Eval("Name") %>'><%# Eval("StateId") == null ? Eval("Name") : Eval("State.Name") + "->" + Eval("Name")%></a>
                        </ItemTemplate> 
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle Width="250px" />
                    </asp:TemplateField>
                  <%--  <asp:TemplateField HeaderText="آگهی" FooterText="آگهی">
                        <ItemTemplate>
                            <center>
                                <asp:Literal ID="ltr_count" runat="server"></asp:Literal>
                           </center>
                        </ItemTemplate>
                        
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="35px" />
                    </asp:TemplateField>--%>
                      <asp:TemplateField FooterText="تنظیمات" HeaderText="تنظیمات">
                        <ItemTemplate>
                            
                            <asp:LinkButton ID="deleteLinkButton" CommandArgument='<%# Eval("ID") %>' CommandName="deleteStateCity" runat="server"><i class="icon-eraser"></i>حذف</asp:LinkButton>
                            
                            
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="footer" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate >
                هیچ رکوردی وجود ندارد.
                </EmptyDataTemplate>
            </asp:GridView>
            
            </div>
            <div class="clr">
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>
