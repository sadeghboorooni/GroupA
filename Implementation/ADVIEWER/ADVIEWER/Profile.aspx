<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ADVIEWER.Profile" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<div class="adv" runat="server" id="abottext">

    <div class="contenttext rounded" style="background: #fafafa;">
        
            <asp:Literal ID="ltrstars" runat="server"></asp:Literal>
      
            <%= about%>
            
            <h2>
            محصولات این کاربر
            </h2> 
    </div>

    <div class="contactinfo rounded">
                <div class="advcontact">
                    <center>
                            
                    </center>
                    <h2 class="alert alert-success" style="text-align:center;padding-left:0;padding-right:0;">
                        اطـلـاعـات تـمـاس
                    </h2>
                    <h3>
                        <i class="icon-user"></i>
                            <%=name.Trim()%>
                    </h3>
                    <hr />
                    
                             <%=  tell == null || tell =="" ? "" : string.Format("<hr><h3><i class='icon-cog'></i>{0}</h3>", tell)%>
                             <%= mobile==null || mobile == "" ? "" : string.Format("<hr><h3><i class='icon-cog'></i>{0}</h3>", mobile)%>
                                   
                </div>
     </div>
     <div class="ten columns maincontent" style="width:720px">
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                    <ItemTemplate>
                           
                           


                  <%# DateTime.Parse(Eval("ExpirationDate").ToString()) > DateTime.Now && Eval("starcount").ToString() != "-1" ?

                                        "<div class='span3 hero-unit featuredAdv' style='width:28%;background-color:#FFFCBB;'><div style=\"position:absolute;top:0;left:0;z-index:10000\"><img src=\"images/vijesmall.png\" /></div>" : "<div class='span3 hero-unit featuredAdv' style='width:28%;'>"%>
                                        
                    <div class="info-column">
                    
                    <div class="advContainer" style="height:130px;">
                    <a class="pic" href='<%# Eval("ID", "adv.aspx?id={0}")%>'
                        title='<%# Eval("Title")%>'>
                        <img class="img-rounded" src='<%# Eval("Pic","/HPicturer.ashx?img={0}&w=300&h=200&path=~/AdvertisePic/") %>'
                            alt='<%# Eval("Title")%>' />
                    </a>
                    </div>
                   <div class="AdvDesc" style="height:75px;">                        
                        <h3 style="font-family:'bbcbold';color:#777;">
                     
                       <%# Eval("Title")%> 
                        </h3>
                    
                    </div> 
                    <div class="details">
                    <%# DateTime.Parse(Eval("ExpirationDate").ToString()) > DateTime.Now &&  Eval("StarCount").ToString() != "-1" ? string.Format("<span class='right' title='تعداد ستاره محصول'><i class='icon-star'></i>{0}</span><br />", Eval("StarCount")):""%>
                         <%# string.Format("<span class='left' title='تاریخ درج محصول'><i class='icon-calendar'></i>{0} </span>", Eval("StartDate")==null?"":Eval("StartDate").ToString())%>
                    <div style="margin-bottom:10px;float:left;">
                    <a href='<%# Eval("ID", "adv.aspx?id={0}")%>'
                            title='<%# Eval("Title")%>'  class="btn btn-primary">مشاهده جزییات</a>
                    </div>
                    </div>
                    </div>
                </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblErrorMsg" runat="server" Text="<div class='message Warning'>کاربر هیچ تبلیغی ندارد...</div>"
                            Visible="false">
                        </asp:Label>
                    </FooterTemplate>
                </asp:Repeater>
                <div class="clear">
                </div>
                <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="قبلی" ControlCssClass="pager"
                    FirstText="ابتدا" LabelText="صفحه" LastText="آخر" MaxPages="200" NextText="بعدی"
                    PageNumbersDisplay="Numbers" ResultsFormat="نتایج {0}-{1} (از {2})"
                    ResultsLocation="None" EnableViewState="False" LabelStyle="" PageSize="28" ResultsStyle=""
                    ShowLabel="True" PagingMode="QueryString" QueryStringKey="page">
                </cc1:CollectionPager>
            </div>
            </div>

</div>  

</asp:Content>
