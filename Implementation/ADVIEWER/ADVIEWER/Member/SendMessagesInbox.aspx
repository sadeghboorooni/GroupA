<%@ Page Title="صندوق پیام های ارسالی" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="SendMessagesInbox.aspx.cs" Inherits="ADVIEWER.Member.SendMessagesInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
            <h2 class="alert hero-unit memberheader">پیام های ارسالی شما</h2>
         
            <asp:GridView CssClass="gridview" ID="MessageGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" EnableModelValidation="True" Width="100%" AllowPaging="false" GridLines="None"
                PageSize="20" EnableTheming="False" EnableViewState="False"
                ShowFooter="false" >
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField FooterText="کد" HeaderText="کد" InsertVisible="False">
                    <HeaderTemplate>
                    کد
                    </HeaderTemplate>
                        <ItemTemplate>
                           <%# Eval("id")%>
                        </ItemTemplate>
                        <FooterTemplate>
                       
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="عنوان" HeaderText="عنوان">
                        <ItemTemplate>
                        <p>
                        <%# string.Format("<a href='ViewMessage.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Text").ToString().Replace("<br />", "").Substring(0, Eval("Text").ToString().Count() / 3) + "...")%> 
                        
                        </a>
                        </p>
                        </ItemTemplate>
                        <HeaderTemplate>
                            متن پیام
                        </HeaderTemplate>
                        <FooterTemplate>
                       
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                <asp:TemplateField FooterText="گیرنده پیام" HeaderText="گیرنده پیام">
                        <ItemTemplate>
                        <p>
                         <%# string.Format("<a href='../Profile.aspx?ID={0}'>{1}</a>", Eval("RecieverID"),Eval("User.FullName")) %>
                        </a>
                        </p>
                        </ItemTemplate>
                        <HeaderTemplate>
                            گیرنده پیام
                        </HeaderTemplate>
                        <FooterTemplate>
                       
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="بروزرسانی" HeaderText="بروزرسانی">
                        <ItemTemplate>
                        <p>
                        <%# ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( Eval("RegistrationDate"),3) %> 
                        </p>
                        </ItemTemplate>
                        <HeaderTemplate>
                            تاریخ
                        </HeaderTemplate>
                        <FooterTemplate>
                       
                        </FooterTemplate>
                        
                        <HeaderStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" HorizontalAlign="Center" />
                    </asp:TemplateField>

                </Columns>
                <PagerSettings Position="Bottom" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <p style="font-size:17px;color:Red">هیچ پیامی وجود ندارد. <a href="SendMessageToUsers.aspx">برای ایجاد پیام کلیک کنید</a>.</p>
                </EmptyDataTemplate>
            </asp:GridView>
                 
                 <div style="margin-top:10px" >
 <a href="SendMessageToUsers.aspx" class="btn btn-primary"><i class="icon-plus"></i> پیام جدید</a>
 </div>

</asp:Content>
