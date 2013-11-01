<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/ManageMaster.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="ADVIEWER.Manage.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>تیکت های پشتیبانی</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
        <div class="NavBar2">
        <div class="NavBar2_resize">
            <a href="default.aspx">مدیریت</a>
            » <a href="Tickets.aspx">تیکت های پشتیبانی</a>
            <p class="time" id="jsClock" style="float: left; color: #fff;">
            </p>
        </div>
        <div class="clr">
        </div>
    </div>

        <div class="fullcontent">
        <h2 class="title green">تیکت های پشتیبانی</h2>
        <div class="bordered">
            
            <asp:GridView CssClass="grid" ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" EnableModelValidation="True" Width="100%" 
                AllowPaging="True" GridLines="None" PageSize="20" EnableTheming="False" EnableViewState="False"
                ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging" 
                onrowdatabound="GridView1_RowDataBound">
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
                        <ItemStyle Font-Names="byekan" HorizontalAlign="Right" Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField FooterText="عنوان" SortExpression="FullName" HeaderText="عنوان">
                        <HeaderTemplate>
                            عنوان
                            <div class="sorting">
                                <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=title&dir=asc":"supporttickets.aspx?sort=title&dir=asc&id="+Request.QueryString["id"]) %>' class="tooltip" title="مرتب سازی صعودی">
                                    <img src="images/sort_up.png" alt="up" /></a> <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=title&dir=desc":"supporttickets.aspx?sort=title&dir=desc&id="+Request.QueryString["id"]) %>'
                                        class="tooltip" title="مرتب سازی نزولی">
                                        <img src="images/sort_down.png" alt="down" /></a>
                            </div>
                        </HeaderTemplate>
                        <FooterTemplate>
                         عنوان
                            <div class="sorting">
                                <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=title&dir=asc":"supporttickets.aspx?sort=title&dir=asc&id="+Request.QueryString["id"]) %>' class="tooltip" title="مرتب سازی صعودی">
                                    <img src="images/sort_up.png" alt="up" /></a> <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=title&dir=desc":"supporttickets.aspx?sort=title&dir=desc&id="+Request.QueryString["id"]) %>'
                                        class="tooltip" title="مرتب سازی نزولی">
                                        <img src="images/sort_down.png" alt="down" /></a>
                            </div>
                        </FooterTemplate>
                        <ItemTemplate>

                            <a href='<%#Eval("id","viewticket.aspx?id={0}") %>' class="title"><img style="margin-bottom:-3px; width:15px" src='<%# Eval("priority","images/{0}.png") %>' alt='' title='<%# Eval("priority","{0} Priority")%>' />
                                <%# Eval("title")%></a>

                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField FooterText="کاربر"  HeaderText="کاربر">
                 
                        <ItemTemplate>
                            <center><a href='<%# Eval("userid","/profile.aspx?id={0}") %>' target="_blank"><%# Eval("FullName")%></a></center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>


                    <asp:TemplateField FooterText="بروزرسانی" SortExpression="LastUpdate" HeaderText="بروزرسانی">
                        <HeaderTemplate>
                            بروزرسانی
                            <div class="sorting">
                                <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=LastUpdate&dir=asc":"supporttickets.aspx?sort=LastUpdate&dir=asc&id="+Request.QueryString["id"]) %>' class="tooltip" title="مرتب سازی صعودی">
                                    <img src="images/sort_up.png" alt="up" /></a> <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=LastUpdate&dir=desc":"supporttickets.aspx?sort=LastUpdate&dir=desc&id="+Request.QueryString["id"]) %>'
                                        class="tooltip" title="مرتب سازی نزولی">
                                        <img src="images/sort_down.png" alt="down" /></a>
                            </div>
                        </HeaderTemplate>
                        <FooterTemplate>
                         بروزرسانی
                            <div class="sorting">
                                <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=LastUpdate&dir=asc":"supporttickets.aspx?sort=LastUpdate&dir=asc&id="+Request.QueryString["id"]) %>' class="tooltip" title="مرتب سازی صعودی">
                                    <img src="images/sort_up.png" alt="up" /></a> <a href='<%= string.Format(Request.QueryString["id"]==null ? "supporttickets.aspx?sort=LastUpdate&dir=desc":"supporttickets.aspx?sort=LastUpdate&dir=desc&id="+Request.QueryString["id"]) %>'
                                        class="tooltip" title="مرتب سازی نزولی">
                                        <img src="images/sort_down.png" alt="down" /></a>
                            </div>
                        </FooterTemplate>
                        <ItemTemplate>
                            <p style="text-align:center; font-family:'b yekan','byekan',tahoma"   title='<%# Agahi.CommonFunctions.String2date(Eval("LastUpdate"), 2, "H") %>'>
                                <%# Agahi.CommonFunctions.String2date(Eval("LastUpdate"), 3, "")%></p>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField FooterText="بخش"  HeaderText="بخش">
                        
                        <ItemTemplate>
                           <center><%# Eval("status").ToString() == "1" ? "<span style='color:#017ad8'>در انتظار پاسخ</span>" : Eval("status").ToString() == "2" ? "<span style='color:#35bd00'>پاسخ داده شده</span>" : Eval("status").ToString() == "3" ? "<span style='color:#7f7f7d'>بسته شده</span>" : "<span style='color:#e54600'>حذف شده</span>"%></center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>

                    <asp:TemplateField FooterText="وضعیت"  HeaderText="وضعیت">
                        
                        <ItemTemplate>
                           <center><%# Eval("part").ToString() == "manage" ? "<span>مدیریت</span>" : Eval("part").ToString() == "programmer" ? "<span>پشتیبانی فنی</span>" : Eval("part").ToString() == "users" ? "<span>پشتیبانی کاربران</span>" : "<span>امور مالی</span>"%></center>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Center"/>
                        <FooterStyle HorizontalAlign="Center" />
                        <ItemStyle Width="90" />
                    </asp:TemplateField>

                    <asp:TemplateField FooterText="تنظیمات" HeaderText="تنظیمات">
                        <ItemTemplate>
                            <center>

                                <asp:LinkButton ID="LinkButton2" runat="server" OnClientClick="return confirm('از حذف تیکت اطمینان دارید؟.');"
                                    CommandName="Delete" CommandArgument='<%# Eval("ID") %>' ToolTip="حذف تیکت"
                                    CssClass="tooltip"><img src="images/delete.png" class="largimg" alt="حذف تیکت" /></asp:LinkButton>

                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirm('از بستن تیکت اطمینان دارید؟');"
                                    CommandName="Update" CommandArgument='<%# Eval("ID") %>' ToolTip="بستن تیکت"
                                    CssClass="tooltip"><img src="images/cancel.png" class="largimg" alt="بستن تیکت" /></asp:LinkButton>
                            </center>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="footer" />
                <PagerSettings Position="Bottom" />
                <PagerStyle CssClass="pager" />
                <EmptyDataRowStyle CssClass="empty" />
                <EmptyDataTemplate>
                    <p class="empty">هیچ تیکتی وجود ندارد.</p>
                </EmptyDataTemplate>
            </asp:GridView>
           
                <DeleteParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:ControlParameter ControlID="GridView1" Name="ID" PropertyName="SelectedValue" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="-1" Name="GroupID" QueryStringField="id"
                        Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>
