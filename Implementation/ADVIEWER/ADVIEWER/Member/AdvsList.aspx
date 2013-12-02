<%@ Page Title="لیست آگهی ها" Language="C#" MasterPageFile="~/Member/MemberMaster.Master" AutoEventWireup="true" CodeBehind="AdvsList.aspx.cs" Inherits="ADVIEWER.Member.AdvsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<h2 class="alert hero-unit memberheader">
        لیست آگهی‏ها
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

                                    <%# (bool)Eval("IsConfirmed") ? "وضعیت: <span style='color:#2b7da3; '>در حال نمایش</span>" :
                                                                            (bool)Eval("IsRead") ? "وضعیت: <span style='color:Red'; '>رد شده</span>" : "وضعیت: <span style='color:#FCA326'; '>در انتظار تایید</span>"%>
                                    
                                    </p>
                            </div>
                            <div style="float:left">
                            <p>
                                    <i class="icon-calendar"></i>انقضا:
                                    <span><%# ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( Eval("ExpirationDate"),3) %></span></p>
                            </div>
                            <div class="clear"></div>
                            <div class="AdlistIcon">
                            <%# Eval("IsConfirmed").ToString() == "True" ? string.Format("<a Target='_blank' href='../AdvContent.aspx?ID={0}')><i class='icon-file'></i>مشاهده&nbsp&nbsp</a>", Eval("ID")) : "" %>
                            <%# Eval("StarCount").ToString() != "-1" ? string.Format("<a Target='_blank' href='ManageAdvGallery.aspx?ID={0}')><i class='icon-picture'></i>مدیریت تصاویر</a>", Eval("ID")) : "" %>
                            </div>
                                


                                <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" OnClientClick="return confirm('از حذف این آگهی اطمینان دارید؟');"
                                    CommandName="del" ToolTip="حذف آگهی" style="float:left;color:Black" Text="<i class='icon-remove' style='color:Red'></i>حذف"
                                    CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="renew" ToolTip="به روزرسانی آگهی" style="float:left;color:Black;padding-left:5px;" 
                                Text="<i class='icon-retweet'></i>به روزرسانی" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                                
                            

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

</asp:Content>