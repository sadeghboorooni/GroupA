<%@ Page Title="محتویات آگهی" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="AdvContent.aspx.cs" Inherits="ADVIEWER.Main.AdvContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="styles/member.css" rel="stylesheet" type="text/css" />
    
    <link href="Styles/RateIt/RateIt.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/RateIt/RateIt.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<div class="latestwork" style="padding:5px;
    -webkit-border-radius: 5px;">

    
    <div class="adv">
        <h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
            <%= curAdv.Title %>

           
        </h2>
        <div style="float:left;text-align:center;margin-left:100px;direction:ltr">
        <div class="rateit" data-rateit-value="<%=AverageAdvRate %>" data-rateit-ispreset="true" id="RateAdv">
        </div>
        <button class="btn btn-primary" onclick="SetRate($('#RateAdv').rateit('value'))" type="button">ثبت امتیاز شما</button>
        <div>
        نمره دهی شما: <%=UserAdvRate %>
        </div>
        <div>
        <%--<button onclick="alert($('#RateAdv').rateit('value'))" type="button">Get value</button>--%>
        <%--<button onclick="$('#RateAdv').rateit('value', prompt('Input numerical value'))" type="button">Set value</button>--%>
        
        </div>
        </div>
        <script>
            function SetRate(value) {
                var advId = <%= curAdv.ID %>
                $.ajax({
                    url: 'RatingHandler.ashx?advId='+advId+'&val='+value,
                    dataType: 'json',
                    context: 'PUT'
                });
            
            }
        </script>


        <br /><br /><br />
        <div style="padding-right:10px;padding-bottom:10px">
            <asp:Literal ID="ltrstars" runat="server" Visible="false"></asp:Literal>
           
           
            <div class="contactinfo rounded" style="vertical-align:top;">
              
                <div class="info-column">
             
                <div class="advContainer">
                  
                        <%= curAdv.Pic == "noimage.png" ? "<img src='noimage.png' class='advpic' />" : string.Format("<a href='AdvertisePic/{0}' title='{1}' style='line-height:12px;' rel='slide'><img src='/HPicturer.ashx?w=300&h=300&path={0}' class='advpic' alt='{1}' /></a>", curAdv.Pic, curAdv.Title)%>
                        </div>

                 <h2 class="alert alert-success" style="text-align:center;padding-left:0;padding-right:0;">
                        اطـلـاعـات تـمـاس
                    </h2>
                    <div>
                   <h3>
                        <i class="icon-user"></i>
                            <%= curAdv.FullName.Trim() %>
                    </h3>
                  
                    <%= curAdv.Mobile == null ? "" : string.Format("<hr/><p><i class='icon-mobile-phone' style='padding-right:2px;padding-left:3px'></i> <b>{0}</b></p> <hr />", curAdv.Mobile)%>
                     
                    <%= curAdv.Tell == null ? "" : string.Format("<p><i class='icon-phone'></i> <b>{0}</b></p>", curAdv.Tell)%>
                    
                    
                </div>
                </div>
            </div>
           
            <%= curAdv.Description %>
           
                </div>
            <div class="clear">
            </div>
            <div runat="server" id="imglist" class="adslider">
                <br />
             
            </div>
   
    </div>
       </div>
    <hr />
    <asp:Literal ID="ltrexmsg" Visible="false" runat="server"></asp:Literal>
    <div class="main container AdvContent" style="padding-right:25%">
    <div class="info">
        <h3 class="alert alert-success" style="text-align:center;margin:0;">
            اطلاعات آگهي دهنده</h3>
        <div class="white advcontact" style="height: 290px; overflow-y: auto; overflow-x: hidden">
            <p>
                <i class="icon-user"></i>نام: <a href='<%= string.Format("/profile.aspx?id={0}",curAdv.UserId) %>'>
                    <%= curAdv.User.FullName %>  
                    </a>
            </p>
          
           
            <%= curAdv.Mobile == null ? "<hr><p><i class='icon-mobile-phone'></i>موبايل: ----</p>" : string.Format("<hr><p><i class='icon-mobile-phone'></i>موبايل: {0}</p>", curAdv.Mobile)%>
            <%= curAdv.Tell == null ? "<hr><p><i class='icon-phone'></i>تلفن: ----</p>" : string.Format("<hr><p><i class='icon-phone'></i>تلفن: {0}</p>", curAdv.Tell)%>
            <%= curAdv.TellTime == null ? "<hr><p><i class='icon-time'></i>زمان تماس: ----</p>" : string.Format("<hr><p><i class='icon-time'></i>زمان تماس: {0}</p>", curAdv.TellTime)%>
            <%= curAdv.Email == null ? "<hr><p><i class='icon-envelope'></i>ايميل: ----</p>" : string.Format("<hr><p><i class='icon-envelope'></i>ايميل: {0}</p>", curAdv.Email )%>
            <%= curAdv.User.Address == null ? "<hr><p><i class='icon-flag'></i>آدرس: ----</p>" : string.Format("<hr><p><i class='icon-flag'></i>آدرس: {0}</p>", curAdv.User.Address )%>
        </div>
    </div>
    <div class="info">
        <h3 class="alert alert-success"style="text-align:center;margin:0;">
            اطلاعات آگهي</h3>
        <div class="white advcontact" style="height: 290px; overflow-y: auto; overflow-x: hidden">
            <p>
                <i class="icon-barcode"></i>کد آگهي: 
                    <%= curAdv.ID %></p>
            <hr />
            
            <p>
                <i class="icon-eye-open"></i>تعداد بازديد: 
                    <%= curAdv.ReviewCount %></p>
            <hr />
            <%= curAdv.Price == string.Empty ? "<p><i class='icon-shopping-cart'></i>قيمت: ----</p><hr />" : string.Format("<p><i class='icon-shopping-cart'></i>قيمت: {0}</p><hr />", curAdv.Price)%>
            <p>
                <i class="icon-calendar"></i>تاريخ درج: 
                    <%= ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( curAdv.RegistrationDate) %></p>
            <hr />
            <p>
                <i class="icon-ok-sign"></i>تاريخ بروز رساني: 
                    <%= ADVIEWER.BAL.PublicFunctions.SolarDateConvertor( curAdv.LastRenewal ) %></p>
        </div>
    </div>
    </div>
    <div class="clear">
    </div>
 
   
 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
    <div class="clear"></div>
       <div runat="server" id="subgroupadi">
            <hr />

        <div class="latestwork" style="clear: both;overflow:hidden">
        <asp:Repeater ID="UserAdvsRepeater" runat="server" OnPreRender="UserAdvsRepeater_PreRender">
            <ItemTemplate>
            <div class="span3 hero-unit featuredAdv">
              
                <div class="info-column">
             
                <div class="advContainer">
                        <%# Eval("pic") == "noimage.png" ? "" : string.Format("<img src='/HPicturer.ashx?w=300&h=220&path={0}' class='img-rounded' title='{1}' alt='{2}' />", Eval("pic"), Eval("Title"), Eval("Title"), Eval("id"))%>
                   </a>
                </div>
               
                    <div class="AdvDesc">                        
                        <h3 style="font-weight:bold;color:#777;">
                     
                       <%# Eval("Title")%> 
                        </h3>
                    
                    </div> 
                   <div class="MoreDesc">
                   <p>
                    <%# Eval("Description") %>
                    </p>
                      <div style="height:25px;overflow:hidden">
                            <span class="right" title="آگهي دهنده"><a href='<%# Eval("UserId","profile.aspx?id={0}") %>'
                                target="_blank"><i class="icon-user"></i>
                                <%# Eval("FullName")%></a></span>
                          
                        </div>
                          <div class="DetailBtn">
                           
                            <%#  Eval("Tell") == null || Eval("Tell").ToString() == string.Empty ? "" : string.Format("<span class='left' title='تلفن تماس آگهي دهنده'><i class='icon-cog'></i>{0} </span>", Eval("Tell").ToString().Length <= 15 ? Eval("Tell") : Eval("Tell").ToString().Substring(0, 15) + "...")%>
                    <a href='<%# Eval("ID", "AdvContent.aspx?id={0}") %>'
                            title='<%# Eval("Title")%>'  class="btn btn-primary">مشاهده جزييات</a>
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