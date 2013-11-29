<%@ Page Title="لیست استان ها و شهرها" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="StateCityList.aspx.cs" Inherits="ADVIEWER.Main.StateCityList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<div class="latestwork" style="padding:5px;
    -webkit-border-radius: 5px;border-radius:5px;">
<div class="adv">
        <h2 class="alert hero-unit" style="font-size:25px;margin-bottom:10px;border-color:transparent;padding:8px 10px 8px 14px;border-right:5px solid #b1d700">
        شهر ها و استان ها
        </h2>
            
            <div class="accordion" id="AdviewerAccordion">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    
                    <div class="accordion-group" style="margin-bottom:5px">
                        <div class="accordion-heading">
                            <a class="accordion-toggle" data-parent="#AdviewerAccordion" data-toggle="collapse" href="#<%# Eval("ID") %>">
                                
                                    <%# Eval("Name") %>
                            </a>
                            
                        </div>
                        <div id="<%# Eval("ID") %>" class="accordion-body collapse" style="height:0px;">
                        <div class="accordion-inner">
                            <span style="padding-right:25px"><a href='ShowStateAdvs.aspx?ID=<%# Eval("ID") %>&Title=<%# Eval("Name") %>'
                                        title='<%# Eval("Name","آگهی و تبلیغات استان {0}") %>'>
                                       همه</a></span>
                            <asp:Literal ID="lbl_GroupID" Visible="false" Text='<%# Eval("ID") %>' runat="server"></asp:Literal>
                            
                            <asp:Repeater ID="Repeater1" runat="server" DataSource=<%# Eval("Cities") %>>
                                <ItemTemplate>
                                    <span style="padding-right:25px;display:inline-block"><a href='ShowStateAdvs.aspx?ID=<%# Eval("ID") %>&Title=<%# Eval("Name") %>'
                                        title='<%# Eval("Name","آگهی و تبلیغات شهر {0}") %>'>
                                        <%# Eval("Name") %></a></span>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        </div>
                        </div>
                   
                </ItemTemplate>
            </asp:Repeater>
             </div>
            <div class="clear">
            </div>
    </div></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MoreAdvs" runat="server">
</asp:Content>
