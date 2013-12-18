 <%@ Page Title="نظرات کاربران" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="CommentsList.aspx.cs" Inherits="ADVIEWER.Manage.CommentsList" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>نظرات کاربران</title>
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

 <h2>نظرات کاربران</h2>
          
             <asp:GridView CssClass="gridview" ID="CommentGridView" runat="server" AutoGenerateColumns="False"
                 DataKeyNames="ID" EnableModelValidation="True" Width="100%" OnRowCommand="CommentGridView_RowCommand"
                 AllowPaging="false" GridLines="None" PageSize="20" EnableTheming="False" EnableViewState="False"
                 ShowFooter="false" >
                 <AlternatingRowStyle CssClass="alt" />
                 <Columns>
                     <asp:TemplateField FooterText="کد" HeaderText="کد" InsertVisible="False" SortExpression="ID">
                     <HeaderTemplate>
                     <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesGridView1(this);"
                                 Text="کد" />
                     </HeaderTemplate>
                         <ItemTemplate>
                             <asp:CheckBox ID="chkBxSelect" runat="server" Text='<%# Eval("id")%>' />
                         </ItemTemplate>
                         <FooterTemplate>
                        
                         </FooterTemplate>
                         <FooterStyle HorizontalAlign="Right" />
                         <HeaderStyle HorizontalAlign="Right" />
                         <ItemStyle HorizontalAlign="Right" Width="60px" />
                     </asp:TemplateField>
                     <asp:TemplateField FooterText="ایمیل کاربر" SortExpression="FullName" HeaderText="ایمیل کاربر">
                         <ItemTemplate>
                         <p>
                         <%# Eval("Email") %> 
                         </a>
                         </p>
                         </ItemTemplate>
                         <HeaderTemplate>
                             ایمیل کاربر
                         </HeaderTemplate>
                         <FooterTemplate>
                        
                         </FooterTemplate>
                         <HeaderStyle HorizontalAlign="Right" />
                          <ItemStyle HorizontalAlign="Right" Width="200px" />
                     </asp:TemplateField>
                     <asp:TemplateField FooterText="متن" SortExpression="FullName" HeaderText="عنوان">
                         <ItemTemplate>
                         <p>
                         <a href='ViewComment.aspx?id=<%# Eval("Id") %>'>
                         <%# Eval("Text") %> 
                         </a>
                         </p>
                         </ItemTemplate>
                         <HeaderTemplate>
                             متن
                         </HeaderTemplate>
                         <FooterTemplate>
                        
                         </FooterTemplate>
                         <HeaderStyle HorizontalAlign="Right" />
                     </asp:TemplateField>
                     <asp:TemplateField FooterText="بروزرسانی" SortExpression="LastUpdate" HeaderText="بروزرسانی">
                         <ItemTemplate>
                         <p>
                         <%# ADVIEWER.BAL.PublicFunctions.SolarDateConvertor(Eval("RegistrationDate"), 3)%> 
                         </p>
                         </ItemTemplate>
                         <HeaderTemplate>
                             تاریخ
                         </HeaderTemplate>
                         <FooterTemplate>
                        
                         </FooterTemplate>
                         
                         <HeaderStyle HorizontalAlign="Right" />
                         <HeaderStyle HorizontalAlign="Center"/>
                         <FooterStyle HorizontalAlign="Center" />
                         <ItemStyle Width="90" />
                     </asp:TemplateField>
 
                     <asp:TemplateField HeaderText="تایید">
                         <ItemTemplate>
                                 <asp:LinkButton ID="ConfirmButton" runat="server" CommandName="ConfirmComment" CommandArgument='<%# Eval("ID") %>' ToolTip="تایید نظر"
                                     CssClass="tooltip"><i class="icon-check" style="color:Green"></i></asp:LinkButton>
                             </center>   
                         </ItemTemplate>
                         <FooterStyle HorizontalAlign="Center" />
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle Width="30px" />
                     </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="حذف">
                         <ItemTemplate>
                                 <asp:LinkButton ID="DeleteButton" runat="server" OnClientClick="return confirm('از حذف نظر اطمینان دارید؟');"
                                     CommandName="deleteComment" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف نظر"
                                     CssClass="tooltip"><i class="icon-remove" style="color:Red"></i></asp:LinkButton>
                             </center>   
                         </ItemTemplate>
                         <FooterStyle HorizontalAlign="Center" />
                         <HeaderStyle HorizontalAlign="Center" />
                         <ItemStyle Width="30px" />
                     </asp:TemplateField>
                 </Columns>
                 <FooterStyle CssClass="footer" />
                 <PagerSettings Position="Bottom" />
                 <PagerStyle CssClass="pager" />
                 <EmptyDataRowStyle CssClass="empty" />
                 <EmptyDataTemplate>
                     <p class="empty">هیچ نظری وجود ندارد.</p>
                 </EmptyDataTemplate>
             </asp:GridView>
                  
                  <div style="margin:20px;">
        <asp:LinkButton ID="DeleteAllComments" runat="server" CssClass="btn btn-primary" OnClick="DeleteSelectedComments" OnClientClick="return confirm('از حذف نظرات انتخاب شده اطمینان دارید؟');"> <i class="icon-remove" style="color:Red;vertical-align:-1px;padding-left:2px"></i>حذف انتخاب شده ها</asp:LinkButton>&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="ConfirmAllComment" runat="server" CssClass="btn btn-primary" OnClick="ConfirmSelectedComments"> <i class="icon-check" style="color:Green;vertical-align:-3px;padding-left:2px"></i>تاییدانتخاب شده ها</asp:LinkButton>
        </div>
             <div class="clear">
             </div>
 
 
 <script type="text/javascript">
     function SelectAllCheckboxesGridView1(chk) {
         $('#<%=CommentGridView.ClientID %>').find("input:checkbox").each(function () {
             if (this != chk) {
                 this.checked = chk.checked;
             }
         });
     }
 
     </script>

     </asp:Content>
 <asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
 </asp:Content>