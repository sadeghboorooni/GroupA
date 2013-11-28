<%@ Page Title="State Advertisements" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="ShowStateAdvs.aspx.cs" Inherits="ADVIEWER.ShowStateAdvs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
            تبلیغات استان&nbsp<% =Title  %>
        </h2>

        <div class="latestwork" style="clear: both;overflow:hidden;">
        <asp:Repeater ID="GroupAdvRepeater" runat="server">
            <ItemTemplate>
            <div class="span3 hero-unit featuredAdv">
              
                <div class="info-column">
             
                <div class="advContainer" style="height:220px;text-align:center">
                   <a href='<%# Eval("ID", "advcontent.aspx?id={0}") %>'
                        title='<%# Eval("Title")%>'>
<%--                        <img style="height: auto;display: inline-block; max-width: 100%;" src='<%# Eval("Pic","/HPicturer.ashx?w=280&h=200&path={0}") %>' alt='<%# Eval("Title")%>' class="img-rounded" />--%>
<img src='<%# Eval("Pic","/HPicturer.ashx?w=300&h=200&path={0}") %>' class="img-rounded" />
                   </a>
                </div>
               
                    <div class="AdvDesc">                        
                        <h3 style="font-weight:bold;color:#777;">
                       <%# Eval("Title")%> 
                        </h3>
                    
                    </div> 
                   
                    <div>
                  
                   <%--<td style="width:0%">
                   
                   </td>--%>
                 
                   <div class="DetailBtn">
                    <a href='<%# Eval("ID", "advcontent.aspx?id={0}") %>'
                            title='<%# Eval("Title")%>'  class="btn btn-primary">مشاهده جزییات</a>
                   </div>
                  
                     </div>
                     <span class="span"></span>
                </div>
                </div>
            </ItemTemplate>
            
        </asp:Repeater></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>
