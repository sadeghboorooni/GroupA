<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AdvContent.aspx.cs" Inherits="ADVIEWER.AdvContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/member.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<div class="latestwork" style="padding:5px;
    -webkit-border-radius: 5px;">

    
    <div class="adv">
        <h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
            <%= curAdv.Title %>
        </h2>
        <asp:Literal ID="ltrvije" Visible="false" runat="server" Text="<h1><i class='icon-star'></i>آگهی ویژه</h1>"></asp:Literal>
        <div style="padding-right:10px;padding-bottom:10px">
            <asp:Literal ID="ltrstars" runat="server" Visible="false"></asp:Literal>
           
           
           
           
            <div class="contactinfo rounded" style="vertical-align:top;">
              
                <div class="info-column">
             
                <div class="advContainer">
                  
                        <%= curAdv.Pic == "noimage.png" ? "<img src='noimage.png' class='advpic' />" : string.Format("<a href='AdvertisePic/{0}' title='{1}' style='line-height:12px;' rel='slide'><img src='/HPicturer.ashx?img={0}&w=300&h=300&path=~/AdvertisePic/' class='advpic' alt='{1}' /></a>", curAdv.Pic, curAdv.Title)%>
                        </div>

                 <h2 class="alert alert-success" style="text-align:center;padding-left:0;padding-right:0;">
                        اطـلـاعـات تـمـاس
                    </h2>
                    <div>
                   <h3>
                        <i class="icon-user"></i>
                            <%= curAdv.FullName.Trim() %>
                    </h3>
                    <hr />
                        <i class="icon-pencil"></i><b><a onclick="return popup(this,'ارسال پیام به آگهی دهنده',1,380,410)"
                            href='<%= string.Format("sendpm-{0}.aspx",ID) %>'>&nbsp ارسال پیام به آگهی دهنده</a></b>
                   <hr />
                    <%= curAdv.Mobile == null ? "" : string.Format("<p><i class='icon-mobile-phone' style='padding-right:2px;padding-left:3px'></i> <b style='font:bold 14px tahoma'>{0}</b></p> <hr />", curAdv.Mobile)%>
                     
                    <%= curAdv.Tell == null ? "" : string.Format("<p><i class='icon-phone'></i> <b style='font:bold 14px tahoma'>{0}</b></p> <hr />", curAdv.Tell)%>
                    
                    
                </div>
                </div>
            </div>
           
            <%= curAdv.Description %>
           
                </div>
            <div class="clear">
            </div>
            <div runat="server" id="imglist" class="adslider">
                <br />
                <h2 style="margin-bottom: 10px">
                    <i class="icon-picture"></i>تـصــاویـر ایـن آگـهـی</h2>

                        
            </div>
   
    </div>
    <hr />
    <asp:Literal ID="ltrexmsg" Visible="false" runat="server"></asp:Literal>
    <div class="info">
        <h3 class="alert alert-success" style="text-align:center;margin:0;">
            اطلاعات آگهی دهنده</h3>
        <div class="white advcontact" style="height: 290px; overflow-y: auto; overflow-x: hidden">
            <p>
                <i class="icon-user"></i>نام: <a class="tooltip" href='<%= string.Format("/profile.aspx?id={0}",curAdv.UserId) %>'>
                    <%= curAdv.User.FullName %>
                    <span class="classic help">مشاهده اطلاعات آگهی دهنده</span></a> 
            </p>
            <hr />
            <p>
                <i class="icon-pencil"></i><a onclick="return popup(this,'ارسال پیام به آگهی دهنده',1,380,410)"
                    href='<%= string.Format("sendpm-{0}.aspx",ID) %>'>برای ارسال پیام به آگهی دهنده
                    کلیک کنید</a>
            </p>
            <%= curAdv.Mobile == null ? "<hr><p><i class='icon-cog'></i>موبایل: ----</p>" : string.Format("<hr><p><i class='icon-cog'></i>موبایل: {0}</p>", curAdv.Mobile)%>
            <%= curAdv.Tell == null ? "<hr><p><i class='icon-cog'></i>تلفن: ----</p>" : string.Format("<hr><p><i class='icon-cog'></i>تلفن: {0}</p>", curAdv.Tell)%>
            <%= curAdv.TellTime == null ? "<hr><p><i class='icon-time'></i>زمان تماس: ----</p>" : string.Format("<hr><p><i class='icon-time'></i>زمان تماس: {0}</p>", curAdv.TellTime)%>
            <%= curAdv.Email == null ? "<hr><p><i class='icon-envelope'></i>ایمیل: ----</p>" : string.Format("<hr><p><i class='icon-envelope'></i>ایمیل: {0}</p>", curAdv.Email )%>
            <%= curAdv.User.Address == null ? "<hr><p><i class='icon-flag'></i>آدرس: ----</p>" : string.Format("<hr><p><i class='icon-flag'></i>آدرس: {0}</p>", curAdv.User.Address )%>
        </div>
    </div>
    <div class="info">
        <h3 class="alert alert-success"style="text-align:center;margin:0;">
            اطلاعات آگهی</h3>
        <div class="white advcontact" style="height: 290px; overflow-y: auto; overflow-x: hidden">
            <p>
                <i class="icon-barcode"></i>کد آگهی: 
                    <%= ID %></p>
            <hr />
            
            <p>
                <i class="icon-eye-open"></i>تعداد بازدید: 
                    <%= curAdv.ReviewCount %></p>
            <hr />
            <%= curAdv.Price == string.Empty ? "<p><i class='icon-shopping-cart'></i>قیمت: ----</p><hr />" : string.Format("<p><i class='icon-shopping-cart'></i>قیمت: {0}</p><hr />", curAdv.Price)%>
            <p>
                <i class="icon-calendar"></i>تاریخ درج: 
                    <%= curAdv.RegistrationDate %></p>
            <hr />
            <p>
                <i class="icon-ok-sign"></i>تاریخ بروز رسانی: 
                    <%= curAdv.LastRenewal %></p>
        </div>
    </div>
    <div class="clear">
    </div>
 
   
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
 <hr />
    <div class="clear"></div>
       <div runat="server" id="subgroupadi">
            <hr />

        <div class="latestwork" style="clear: both;overflow:hidden">
        <asp:Repeater ID="UserAdvsRepeater" runat="server" OnPreRender="UserAdvsRepeater_PreRender">
            <ItemTemplate>
            <div class="span3 hero-unit featuredAdv">
              
                <div class="info-column">
             
                <div class="advContainer">
                        <%# Eval("pic") == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?img={0}&w=300&h=220&path=~/AdvertisePic/' class='img-rounded' title='{1}' alt='{2}' />", Eval("pic"), Eval("Title"), Eval("Title"),Eval("id"))%>
                   </a>
                </div>
               
                    <div class="AdvDesc">                        
                        <h3 style="font-family:'bbcbold';color:#777;">
                     
                       <%# Eval("Title")%> 
                        </h3>
                    
                    </div> 
                   <div class="MoreDesc">
                   <p>
                    <%# Eval("Description") %>
                    </p>
                      <div style="height:25px;overflow:hidden">
                            <span class="right" title="آگهی دهنده"><a href='<%# Eval("UserId","profile.aspx?id={0}") %>'
                                target="_blank"><i class="icon-user"></i>
                                <%# Eval("FullName")%></a></span>
                          
                        </div>
                          <div class="DetailBtn">
                           
                            <%#  Eval("Tell") == null || Eval("Tell").ToString() == string.Empty ? "" : string.Format("<span class='left' title='تلفن تماس آگهی دهنده'><i class='icon-cog'></i>{0} </span>", Eval("Tell").ToString().Length <= 15 ? Eval("Tell") : Eval("Tell").ToString().Substring(0, 15) + "...")%>
                    <a href='<%# Eval("ID", "adv.aspx?id={0}") %>'
                            title='<%# Eval("Title")%>'  class="btn btn-primary">مشاهده جزییات</a>
                   </div>
                   </div>
                    <div>
                  
                   <%--<td style="width:0%">
                   
                   </td>--%>
                 
                 
                  
                 
                       
                   
                     </div>
                     <span class="span"></span>
                </div>
                </div>
            </ItemTemplate>
            
        </asp:Repeater></div>

        </div>
        </asp:Content>