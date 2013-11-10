<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AdvsList.aspx.cs" Inherits="ADVIEWER.Member.AdvsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
        <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
    </h2>
    <asp:Literal ID="ltr_error" runat="server"></asp:Literal>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="20"
        DataKeyNames="ID" AllowPaging="True" GridLines="None" EnableTheming="False" EnableViewState="False"
        Width="100%" ShowHeader="false" EnableModelValidation="True"
        OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <div class="contenttext search2" style="line-height: 40px;margin-bottom:20px">
                        
                            <div style="color:Red;float:left">
                                کد:
                                <%# Eval("id") %></div>
                           
                         <%--   <%# Eval("pic").ToString() == "noimage.png" ? "" : string.Format("<a href='ad-{3}.aspx?{2}'><img src='/HPicturer.ashx?img={0}&w=170&h=170&path=~/AdvertisePic/' class='rounded' title='{1}' alt='{2}' /></a>", Eval("pic"), Eval("Title"), Agahi.CommonFunctions.ReplaceSpace(Eval("Title")), Eval("id"))%>--%>
                            <div>
                            <span style="margin-bottom: 4px;font-size:22px"><%# Eval("Title")%>&nbsp&nbsp</span>
                             <%# Eval("starCount").ToString() == "-1" ? "" : string.Format("<span style='color:blue'>آگهی ویژه {0} ستاره {1} ماهه</span>", Eval("starCount"), Eval("AdvDuration"))%>
                             </div>
                            <div style="float:right">
                                <p>
                                    <i class="icon-exclamation-sign"></i>
                                    <%# Eval("IsConfirmed").ToString() == "True" ? "وضعیت: <span style='color:#2b7da3; '>در حال نمایش</span>" : "وضعیت: <span style='color:Red'; '>در انتظار تایید</span>"%>
                                    </p>
                            </div>
                            <div style="float:left">
                            <p>
                                    <i class="icon-calendar"></i>انقضا:
                                    <span><%# Eval("ExpirationDate") %></span></p>
                            </div>
                            <div class="clear"></div>
                            <div class="AdlistIcon">
                                <asp:HyperLink ID="HyperLink2" Target="_blank" NavigateUrl='<%# Eval("ID", "../AdvContent.aspx?ID={0}") %>'
                                    runat="server"><i class="icon-file"></i>مشاهده</asp:HyperLink></div>
                                    
                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" OnClientClick="return confirm('از حذف این آگهی اطمینان دارید؟');"
                                    CommandName="del" ToolTip="حذف آگهی" style="float:left;color:Black" Text="<i class='icon-remove' style='color:Red'></i>حذف"
                                    CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                            

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

    <%--<asp:SqlDataSource ID="sds_ad" runat="server" ConnectionString="<%$ ConnectionStrings:ApplicationServices %>"
        SelectCommand="useradlist" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="typ" QueryStringField="typ" Type="Int32" />
            <asp:Parameter Name="UserID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>--%>

</asp:Content>
