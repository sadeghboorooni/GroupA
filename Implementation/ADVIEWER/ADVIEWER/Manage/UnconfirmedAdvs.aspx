<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="UnconfirmedAdvs.aspx.cs" Inherits="ADVIEWER.Manage.UnconfirmedAdvs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="fullcontent">
        <h2 class="title green">
            لیست آگهی های عادی در انتظار تایید
            <%= adiCount %>
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
                                <a href='<%# Eval("ID",  "displayadv-{0}.aspx") %>' target="_blank">
                                    <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?img={0}&w=70&h=70&path=~/AdvertisePic/' class='advimg' alt='' />",Eval("pic").ToString())%>
                                </a><a href='<%# Eval("ID",  "displayadv-{0}.aspx") %>' class="title" target="_blank">
                                    <%# Eval("Title")%></a>
                                <%--<%# Eval("ConfirmMsg").ToString() == string.Empty ? "" : "<img style='vertical-align:middle; margin-left:3px;' src='images/no.png' /> دلیل عدم تایید قبل: <span>" + "___ConfirmMsg___" + "</span><br>"%>--%>
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
               
                <asp:LinkButton ID="LinkButton3" CssClass="gridbtn" runat="server" OnClick="LinkButton3_Click"><img src="images/add.png" alt="" /> تایید انتخاب شده ها</asp:LinkButton>

                <div style="width: 400px; text-align: left; float: left">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="علت عدم تایید" Style="padding: 7px;
                        width: 220px;"></asp:TextBox>
                    <asp:LinkButton ID="LinkButton4" CssClass="gridbtn" runat="server" OnClick="LinkButton4_Click"><img src="images/delete.png" alt="" /> رد انتخاب شده ها</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
