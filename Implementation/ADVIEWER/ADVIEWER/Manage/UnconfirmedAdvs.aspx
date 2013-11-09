<%@ Page Title="" Language="C#" MasterPageFile="ManageMaster.Master" AutoEventWireup="true" CodeBehind="UnconfirmedAdvs.aspx.cs" Inherits="ADVIEWER.Manage.UnconfirmedAdvs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function SelectAllCheckboxesFreeAdvsGridView(chk) {
            $('#<%=FreeAdvsGridView.ClientID %>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="fullcontent">
        <h2 class="title green">
            لیست آگهی های ویژه در انتظار تایید
            (<%= staredAdvsCount%>)
            </h2>
        <div class="bordered">
            <asp:GridView ID="staredAdvsGridView" runat="server" AutoGenerateColumns="False" PageSize="15"
                CssClass="grid" DataKeyNames="ID" OnPageIndexChanging="staredAdvsGridView_PageIndexChanging"
                AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
                Width="100%" ShowFooter="true">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField FooterText="#" HeaderText="#" InsertVisible="False" SortExpression="ID">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesFreeAdvsGridView(this);"
                                Text="#" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectAdd" CssClass="ch" runat="server" Text='<%# Container.DataItemIndex+1 %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesFreeAdvsGridView(this);"
                                Text="#" />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Font-Names="byekan" HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <ItemTemplate>
                            <div class="groupname">
                                <a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' target="_blank">
                                    <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?w=70&h=70&path={0}' class='advimg' alt='' />",Eval("pic").ToString())%>
                                </a><a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' class="title" target="_blank">
                                    <%# Eval("Title")%></a>
                                <p>
                                    تاریخ:
                                    <%# Eval("RegistrationDate")%>
                                </p>
                                <p>
                                    توسط: <a target="_blank" href='<%# Eval("userid","/profile.aspx?id={0}") %>'>
                                        <%# Eval("FullName") %></a>
                                </p>
                                <p>
                                <%# int.Parse(Eval("starCount").ToString()) == 1 ? "<div><i class='icon-star'></i>آگهی یک ستاره</div>" :
                                    "<div><i class='icon-star'></i><i class='icon-star'></i>آگهی دو ستاره</div>"%>
                                </p>
                            </div>
                        </ItemTemplate>
                        <HeaderTemplate>
                            عنوان آگهی
                        </HeaderTemplate>
                        <FooterTemplate>
                            عنوان آگهی
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="footer" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <p class="empty">
                        آگهی جدیدی وجود ندارد</p>
                </EmptyDataTemplate>
            </asp:GridView>
            <div class="gridbottom">
                <asp:Button ID="ConfirmStaredAdvsButton" runat="server" 
                    Text="تایید انتخاب شده ها" onclick="ConfirmStaredAdvsButton_Click" />

                <div style="width: 400px; text-align: left; float: left">
                    <asp:TextBox ID="denyReasonStaredTextBox" runat="server" placeholder="علت عدم تایید" Style="width: 220px;"></asp:TextBox>
                    <asp:Button ID="DenyStaredAdvsButton" runat="server" Text="رد انتخاب شده ها" 
                        onclick="DenyStaredAdvsButton_Click" />
                </div>
            </div>
        </div>
    </div>


    <div class="fullcontent">
        <h2 class="title green">
            لیست آگهی های عادی در انتظار تایید
            (<%= freeAdvsCount%>)
            </h2>
        <div class="bordered">
            <asp:GridView ID="FreeAdvsGridView" runat="server" AutoGenerateColumns="False" PageSize="15"
                CssClass="grid" DataKeyNames="ID" OnPageIndexChanging="FreeAdvsGridView_PageIndexChanging"
                AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
                Width="100%" ShowFooter="true">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField FooterText="#" HeaderText="#" InsertVisible="False" SortExpression="ID">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesFreeAdvsGridView(this);"
                                Text="#" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectAdd" CssClass="ch" runat="server" Text='<%# Container.DataItemIndex+1 %>' />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesFreeAdvsGridView(this);"
                                Text="#" />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Font-Names="byekan" HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <ItemTemplate>
                            <div class="groupname">
                                <a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' target="_blank">
                                    <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?w=70&h=70&path={0}' class='advimg' alt='' />",Eval("pic").ToString())%>
                                </a><a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' class="title" target="_blank">
                                    <%# Eval("Title")%></a>
                                <p>
                                    تاریخ:
                                    <%# Eval("RegistrationDate")%>
                                </p>
                                <p>
                                    توسط: <a target="_blank" href='<%# Eval("userid","/profile.aspx?id={0}") %>'>
                                        <%# Eval("FullName") %></a>
                                </p>
                                <p>
                                <%# Eval("userid").ToString() == "3855" ? "<img style='vertical-align:middle; margin-left:3px;' src='images/info.png' /> آگهی بدون ثبت نام" : ""%>
                                </p>
                            </div>
                        </ItemTemplate>
                        <HeaderTemplate>
                            عنوان آگهی
                        </HeaderTemplate>
                        <FooterTemplate>
                            عنوان آگهی
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="footer" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <p class="empty">
                        آگهی جدیدی وجود ندارد</p>
                </EmptyDataTemplate>
            </asp:GridView>
            <div class="gridbottom">
                <asp:Button ID="ConfirmFreeAdvsButton" runat="server" 
                    Text="تایید انتخاب شده ها" onclick="ConfirmFreeAdvsButton_Click" />

                <div style="width: 400px; text-align: left; float: left">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="علت عدم تایید" Style="width: 220px;"></asp:TextBox>
                    <asp:Button ID="DenyFreeAdvsButton" runat="server" Text="رد انتخاب شده ها" 
                        onclick="DenyFreeAdvsButton_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
