﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoatDetails.ascx.cs"
    Inherits=" Cowrie.Modules.ProductDetails.BoatDetails" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src='<%#ResolveUrl("~/DesktopModules/ProductDetails/Scripts/fancybox/jquery.fancybox-1.3.4.js")%>' type="text/javascript"></script>
<link href='<%#ResolveUrl("~/DesktopModules/ProductDetails/Scripts/fancybox/jquery.fancybox-1.3.4.css")%>' type="text/css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $("a.sfLightBox").fancybox();
    })
</script>

<div id="images" style="padding: 10px; float: left; width: 470px">
    <div id="image">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%# boat.Image %>' />
    </div>
    <div id="gallery" style="padding: 10px; clear: both">
        <asp:Repeater ID="Repeater1" runat="server">
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
</div>
<div id="details" style="padding: 10px;">
    <h1><%# boat.Name %></h1>
    <div id="description" style="padding: 10px;">
        <%# boat.Description %>
    </div>
</div>