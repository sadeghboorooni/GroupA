<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AdvsList.aspx.cs" Inherits="ADVIEWER.Member.AdvsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
    </h2>
    <asp:Literal ID="ltr_error" runat="server"></asp:Literal>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="20"
        DataKeyNames="ID" DataSourceID="sds_ad" OnPageIndexChanging="GridView1_PageIndexChanging"
        AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
        Width="100%" OnRowDataBound="GridView1_RowDataBound" ShowHeader="false" EnableModelValidation="True"
        OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <div class="contenttext search2" style="line-height: 40px;margin-bottom:20px">
                        
                            <div style="color:Red;float:left">
                                کد:
                                <%# Eval("id") %></div>
                            <%# Eval("starCount").ToString()=="-1" ? "" : string.Format("<div class='starcontainer rstar' title='آگهی ویژه {0} ستاره {1} ماهه'><div class='stars star{0}'></div></div>", Eval("starCount"), Eval("CreditTime"))%>
                         <%--   <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<a href='ad-{3}.aspx?{2}'><img src='/HPicturer.ashx?img={0}&w=170&h=170&path=~/AdvertisePic/' class='rounded' title='{1}' alt='{2}' /></a>", Eval("pic"), Eval("Title"), Agahi.CommonFunctions.ReplaceSpace(Eval("Title")), Eval("id"))%>--%>
                            <div>
                            <a style="margin-bottom: 4px;font-size:22px" href='<%# Eval("ID", "../AdvContent.aspx?ID={0}") %>'
                                title='<%# Eval("Title")%>'>
                                <%# Eval("Title")%></a></div>
                            <div style="float:right">
                                <p>
                                    <i class="icon-exclamation-sign"></i>
                                    <asp:Literal ID="ltrstat" runat="server" Text="Label"></asp:Literal></p>
                               <%-- <p>
                                    <i class="icon-calendar"></i>انقضا:
                                    <%# Agahi.CommonFunctions.String2date(Eval("ExpirationDate"), 1, "TY") + " - " + Agahi.CommonFunctions.String2date(Eval("ExpirationDate"), 2, "H")%></p>--%>
                            </div>
                            
                            <div class="AdlistIcon">
                               <%-- <asp:HyperLink ID="HyperLink2" Target="_blank" NavigateUrl='<%# Eval("ID", "/adv-{0}.aspx?")+Agahi.CommonFunctions.ReplaceSpace(Eval("title","{0}")) %>'
                                    runat="server"><i class="icon-file"></i>مشاهده|</asp:HyperLink>--%>
                                    
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" OnClientClick="return confirm('از حذف این آگهی اطمینان دارید؟');"
                                    CommandName="del" CssClass="gridlinksred" ToolTip="حذف آگهی" Text="<i class='icon-remove' style='color:Red'></i>حذف"
                                    CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                            </div>

                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle CssClass="footer" />
        <PagerStyle CssClass="pager" />
        <EmptyDataRowStyle CssClass="empty" />
        <EmptyDataTemplate>
            <p style="text-align:center">
                شما هیچ آگهی ندارید. <a href="AddNewAdv.aspx">برای درج آگهی جدید کلیک کنید</a>.</p>
                </div>
        </EmptyDataTemplate>
    </asp:GridView>

    <asp:SqlDataSource ID="sds_ad" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="useradlist" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="typ" QueryStringField="typ" Type="Int32" />
            <asp:Parameter Name="UserID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
