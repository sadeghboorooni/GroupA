<%@ Page Title="لیست تیکت ها" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="TicketsList.aspx.cs" Inherits="ADVIEWER.Member.TicketsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
            <h2>درخواست‏های شما</h2>
         
            <asp:GridView CssClass="gridview" ID="TicketGridView" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" EnableModelValidation="True" Width="100%" OnRowCommand="TicketGridView_RowCommand"
                AllowPaging="True" GridLines="None" PageSize="20" EnableTheming="False" EnableViewState="False"
                ShowFooter="True" >
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
                    <asp:TemplateField FooterText="عنوان" SortExpression="FullName" HeaderText="عنوان">
                        <ItemTemplate>
                        <p>
                        <%# Eval("RegDate").ToString() == Eval("LastUpdate").ToString() ? string.Format("<a style='color:Red' href='viewTicket.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Title")) : string.Format("<a href='viewTicket.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Title")) %>
                        
                        </a>
                        </p>
                        </ItemTemplate>
                        <HeaderTemplate>
                            عنوان
                        </HeaderTemplate>
                        <FooterTemplate>
                       
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="متن" SortExpression="FullName" HeaderText="عنوان">
                        <ItemTemplate>
                        <p>
                         <%# Eval("RegDate").ToString() == Eval("LastUpdate").ToString() ? string.Format("<a style='color:Red' href='viewTicket.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Title")) : string.Format("<a href='viewTicket.aspx?ID={0}'>{1}</a>", Eval("ID"), Eval("Title"))%>
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
                        <%# Eval("RegDate") %> 
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

                    <asp:TemplateField HeaderText="حذف">
                        <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server" OnClientClick="return confirm('از حذف تیکت اطمینان دارید؟');"
                                    CommandName="deleteTicket" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف تیکت"
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
                    <p class="empty">هیچ تیکتی وجود ندارد. <a href="AddNewTicket.aspx">برای ایجاد تیکت کلیک کنید</a>.</p>
                </EmptyDataTemplate>
            </asp:GridView>
                 
 <a href="AddNewTicket.aspx" class="btn btn-primary" ><i class="icon-plus"></i> تیکت جدید</a>
       <asp:LinkButton ID="DeleteAllTickets" runat="server" CssClass="btn btn-primary" OnClick="DeleteSelectedTickets" OnClientClick="return confirm('از حذف تیکت های انتخاب شده اطمینان دارید؟');"> <i class="icon-remove" style="color:Red"></i>حذف انتخاب شده ها</asp:LinkButton>&nbsp;&nbsp;&nbsp;
            <div class="clear">
            </div>


<script type="text/javascript">
    function SelectAllCheckboxesGridView1(chk) {
        $('#<%=TicketGridView.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }

    </script>
</asp:Content>
