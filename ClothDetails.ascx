﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClothDetails.ascx.cs"
    Inherits=" Cowrie.Modules.ProductList.ClothDetails" %>
<%@ Import Namespace="Common" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src='<%#ResolveUrl("~/DesktopModules/ProductList/Scripts/fancybox/jquery.fancybox-1.3.4.js")%>' type="text/javascript"></script>
<link href='<%#ResolveUrl("~/DesktopModules/ProductList/Scripts/fancybox/jquery.fancybox-1.3.4.css")%>' type="text/css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $("a.sfLightBox").fancybox();
    })
</script>

<h1><%# cloth.Name %></h1>
<h2><%# cloth.UnitCost != null ? Utils.GetCurrencySymbol(cloth.CurrencyCode) + cloth.UnitCost.Value.ToString("#0.00") : String.Empty %></h2>
<telerik:RadRating ID="RadRatingStar" runat="server" Value='<%# cloth.CustomerRating %>' ReadOnly="True" />
<h3><%# cloth.Brand.Name %></h3>
<h3><%# cloth.MerchantCategory != null ? cloth.MerchantCategory.Name : String.Empty %></h3>
<h3><%# cloth.Gender.Name %></h3>
<h3><%# cloth.Colour.Name %></h3>
<div style="padding: 10px; float: left">
    <asp:Image ID="Image1" runat="server" ImageUrl='<%# cloth.Image %>' />
</div>
<div style="padding: 10px; float: left">
    <%# cloth.Description %>
</div>
<div style="padding: 10px; float: left">
    <asp:Repeater ID="RepeaterSizes" runat="server">
        <HeaderTemplate>
            Sizes:
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%# Eval("Name") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div style="padding: 10px; float: left">
    <asp:Repeater ID="RepeaterStyles" runat="server">
        <HeaderTemplate>
            Styles:
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%# Eval("Name") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div style="padding: 10px; float: left">
    <asp:Repeater ID="RepeaterDepartments" runat="server">
        <HeaderTemplate>
            Departments:
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%# Eval("Name") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div style="padding: 10px; clear: both">
    <asp:Repeater ID="RepeaterImages" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" CssClass="sfLightBox" runat="server"
                    rel='<%# String.Format("{0}_mainImageGallery", this.ClientID) %>'
                    NavigateUrl='<%# Eval("URL") %>' Width="100px" Height="100px">
                <asp:Image ID="Image2" runat="server" ImageUrl='<%# Eval("URL") %>' Width="100px" />
            </asp:HyperLink>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
<div id="footer">
    <asp:Button ID="ButtonBackToSearch" runat="server" Text="Back to Search" CausesValidation="False" OnClick="ButtonBackToSearch_Click" UseSubmitBehavior="False" />
    &nbsp;
    <asp:Button ID="ButtonBuyNow" runat="server" Text="Buy Now!" CausesValidation="False" OnClick="ButtonBuyNow_Click" UseSubmitBehavior="False" />
</div>
