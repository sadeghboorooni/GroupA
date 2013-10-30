<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="TicketsList.aspx.cs" Inherits="ADVIEWER.Member.TicketsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
            <h2>درخواست‏های شما</h2>
         
            <asp:GridView CssClass="gridview" ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" DataSourceID="sds_pm" EnableModelValidation="True" Width="100%" 
                AllowPaging="True" GridLines="None" PageSize="20" EnableTheming="False" EnableViewState="False"
                ShowFooter="True" onrowdatabound="GridView1_RowDataBound">
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
                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="javascript:SelectAllCheckboxesGridView1(this);"
                                Text="کد" />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="عنوان" SortExpression="FullName" HeaderText="عنوان">
                        <HeaderTemplate>
                            عنوان
                        </HeaderTemplate>
                        <FooterTemplate>
                         عنوان
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="بروزرسانی" SortExpression="LastUpdate" HeaderText="بروزرسانی">
                        <HeaderTemplate>
                            تاریخ
                        </HeaderTemplate>
                        <FooterTemplate>
                         تاریخ
                        </FooterTemplate>
                        <ItemTemplate>
                           <%-- <p style="text-align:center; title='<%# Agahi.CommonFunctions.String2date(Eval("LastUpdate"), 2, "H") %>'>
                                <%# Agahi.CommonFunctions.String2date(Eval("LastUpdate"), 3, "")%></p>--%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField FooterText="وضعیت"  HeaderText="وضعیت">
                        
                        <ItemTemplate>
                           <center><%# Eval("status").ToString() == "1" ? "<span style='color:#017ad8'>در انتظار پاسخ</span>" : Eval("status").ToString() == "2" ? "<span style='color:#35bd00'>پاسخ داده شده</span>" : "<span style='color:#7f7f7d'>بسته شده</span>"%></center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>

                    <asp:TemplateField FooterText="حذف" HeaderText="حذف">
                        <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return confirm('از حذف تیکت اطمینان دارید؟ تمام اطلاعات مرتبط حذف می شوند.');"
                                    CommandName="Delete" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف تیکت"
                                    CssClass="tooltip"><i class="icon-remove"></i></asp:LinkButton>
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
            <asp:SqlDataSource ID="sds_pm" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
                SelectCommand="Usertickets" SelectCommandType="StoredProcedure" DeleteCommand="update ticket set IsDeleted='true',status=4 where ID=@ID" >
                <DeleteParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="UserID" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
                       
 <a href="AddNewTicket.aspx" class="btn btn-primary" ><i class="icon-plus"></i> تیکت جدید</a>
       <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" onclick="LinkButton1_Click" OnClientClick="return confirm('از حذف تیکت های انتخاب شده اطمینان دارید؟');"> <i class="icon-remove" style="color:Red"></i>حذف انتخاب شده ها</asp:LinkButton>&nbsp;&nbsp;&nbsp;
            <div class="clear">
            </div>


<script type="text/javascript">
    function SelectAllCheckboxesGridView1(chk) {
        $('#<%=GridView1.ClientID %>').find("input:checkbox").each(function () {
            if (this != chk) {
                this.checked = chk.checked;
            }
        });
    }

    </script>
</asp:Content>
