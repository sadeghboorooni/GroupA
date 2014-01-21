<%@ Page Title="گزارش تبلیغات" Language="C#" MasterPageFile="ManageMaster.Master" AutoEventWireup="true" CodeBehind="AdReport.aspx.cs" Inherits="ADVIEWER.Manage.AdReport" %>
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

   <div>  
    <asp:Label ID="Label1" runat="server" Text="سال شروع: "></asp:Label>&nbsp
    <asp:TextBox ID="StartDateY" runat="server" MaxLength="4" Width="40"></asp:TextBox>&nbsp&nbsp;
    <asp:Label ID="Label3" runat="server" Text="ماه شروع: "></asp:Label>&nbsp
    <asp:TextBox ID="StartDateM" runat="server" MaxLength="2" Width="20"></asp:TextBox>&nbsp&nbsp;
    <asp:Label ID="Label4" runat="server" Text="روز شروع: "></asp:Label>&nbsp
    <asp:TextBox ID="StartDateD" runat="server" MaxLength="2" Width="20"></asp:TextBox>&nbsp&nbsp<br />&nbsp;

    <asp:Label ID="Label2" runat="server" Text="سال پایان: "></asp:Label>&nbsp
    <asp:TextBox ID="EndDateY" runat="server" MaxLength="4" Width="40"></asp:TextBox>&nbsp&nbsp&nbsp;
    <asp:Label ID="Label5" runat="server" Text="ماه پایان: "></asp:Label>&nbsp&nbsp
    <asp:TextBox ID="EndDateM" runat="server" MaxLength="2" Width="20"></asp:TextBox>&nbsp&nbsp&nbsp;
    <asp:Label ID="Label6" runat="server" Text="روز پایان: "></asp:Label>&nbsp
    <asp:TextBox ID="EndDateD" runat="server" MaxLength="2" Width="20"></asp:TextBox>&nbsp&nbsp&nbsp<br />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;
   
       <asp:Button ID="Button1" runat="server" Text="نمایش" onclick="Button1_Click" />
   </div>
   <div class="fullcontent">
        <h2 class="title green">
            لیست آگهی های ویژه
            (<%= staredAdvsCount%>)
            </h2>
        <div class="bordered">
            <asp:GridView ID="staredAdvsGridView" runat="server" AutoGenerateColumns="False" PageSize="15"
                CssClass="grid" DataKeyNames="ID" OnPageIndexChanging="staredAdvsGridView_PageIndexChanging"
                AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
                Width="100%" ShowFooter="true">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <HeaderTemplate>
                            عنوان آگهی
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="groupname">
                                <a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' target="_blank">
                                <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?w=70&h=70&path={0}' class='advimg' alt='' />",Eval("pic").ToString())%>
                                </a><a class="title" href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' 
                                    target="_blank"><%# Eval("Title")%></a>
                                <p>
                                    تاریخ:
                                    <%# ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( Eval("RegistrationDate"))%>
                                </p>
                                <p>
                                    توسط: <a href='<%# Eval("userid","/profile.aspx?id={0}") %>' target="_blank">
                                    <%# Eval("FullName") %></a>
                                </p>
                                <p>
                                    <%# int.Parse(Eval("starCount").ToString()) == 1 ? "<div><i class='icon-star'></i>آگهی یک ستاره</div>" :
                                    "<div><i class='icon-star'></i><i class='icon-star'></i>آگهی دو ستاره</div>"%>
                                </p>
                            </div>
                        </ItemTemplate>
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
<%--            <div class="gridbottom">
                <asp:Button ID="ConfirmStaredAdvsButton" runat="server" 
                    Text="تایید انتخاب شده ها" onclick="ConfirmStaredAdvsButton_Click" />

                <div style="width: 400px; text-align: left; float: left">
                    <asp:TextBox ID="denyReasonStaredTextBox" runat="server" placeholder="علت عدم تایید" Style="width: 220px;height:16px"></asp:TextBox>
                    <asp:Button ID="DenyStaredAdvsButton" runat="server" Text="رد انتخاب شده ها" 
                        onclick="DenyStaredAdvsButton_Click" />
                </div>
            </div>--%>
        </div>
    </div>


    <div class="fullcontent">
        <h2 class="title green">
            لیست آگهی های عادی 
            (<%= freeAdvsCount%>)
            </h2>
        <div class="bordered">
            <asp:GridView ID="FreeAdvsGridView" runat="server" AutoGenerateColumns="False" PageSize="15"
                CssClass="grid" DataKeyNames="ID" OnPageIndexChanging="FreeAdvsGridView_PageIndexChanging"
                AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
                Width="100%" ShowFooter="True">
                <AlternatingRowStyle CssClass="alt" />
                <Columns>
                    <asp:TemplateField HeaderText="Title" SortExpression="Title">
                        <HeaderTemplate>
                            عنوان آگهی
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="groupname">
                                <a href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' target="_blank">
                                <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?w=70&h=70&path={0}' class='advimg' alt='' />",Eval("pic").ToString())%>
                                </a><a class="title" href='<%# Eval("ID",  "/advcontent.aspx?id={0}") %>' 
                                    target="_blank"><%# Eval("Title")%></a>
                                <p>
                                    تاریخ:
                                    <%# ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( Eval("RegistrationDate"))%>
                                </p>
                                <p>
                                    توسط: <a href='<%# Eval("userid","/profile.aspx?id={0}") %>' target="_blank">
                                    <%# Eval("FullName") %></a>
                                </p>
                                <p>
                                    <%# Eval("userid").ToString() == "3855" ? "<img style='vertical-align:middle; margin-left:3px;' src='images/info.png' /> آگهی بدون ثبت نام" : ""%>
                                </p>
                            </div>
                        </ItemTemplate>
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
     <%--       <div class="gridbottom">
                <asp:Button ID="ConfirmFreeAdvsButton" runat="server" 
                    Text="تایید انتخاب شده ها" onclick="ConfirmFreeAdvsButton_Click" />

               <div style="width: 400px; text-align: left; float: left">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="علت عدم تایید" Style="width: 220px;height:16px"></asp:TextBox>
                    <asp:Button ID="DenyFreeAdvsButton" runat="server" Text="رد انتخاب شده ها" 
                        onclick="DenyFreeAdvsButton_Click" />
                </div>
            </div>--%>
        </div>
    </div>

</asp:Content>
