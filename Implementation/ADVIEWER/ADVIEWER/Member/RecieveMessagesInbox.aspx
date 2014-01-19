<%@ Page Title="صندوق پیام های دریافتی" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="RecieveMessagesInbox.aspx.cs" Inherits="ADVIEWER.Member.RecieveMessagesInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
            <h2 class="alert hero-unit memberheader">پیام های دریافتی شما</h2>
         
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
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="عنوان" HeaderText="عنوان">
                        <ItemTemplate>
                        <p>
                        <%# string.Format("<a href='ViewMessage.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Text").ToString().Replace("<br />", "").Substring(0,Eval("Text").ToString().Count() /3) + "...")%> 
                        
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
                <asp:TemplateField FooterText="فرستنده پیام" HeaderText="فرستنده پیام">
                        <ItemTemplate>
                        <p>
                         <%# string.Format("<a href='../Profile.aspx?ID={0}'>{1}</a>", Eval("SenderID"), Eval("User.FullName"))%>
                        </a>
                        </p>
                        </ItemTemplate>
                        <HeaderTemplate>
                            فرستنده پیام
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
                        <ItemStyle Width="90" HorizontalAlign="Center"/>
                    </asp:TemplateField>

                </Columns>
                <PagerSettings Position="Bottom" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <p style="font-size:17px;color:Red">هیچ پیامی وجود ندارد.</p>
                </EmptyDataTemplate>
            </asp:GridView>
                 
</asp:Content>
