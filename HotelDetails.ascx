<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HotelDetails.ascx.cs"
    Inherits=" Cowrie.Modules.ProductDetails.HotelDetails" %>
<%@ Import Namespace="Common" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/DesktopModules/ProductDetails/PointOnMap.ascx" TagPrefix="uc1" TagName="PointOnMap" %>

<script src='<%#ResolveUrl("~/DesktopModules/ProductDetails/Scripts/fancybox/jquery.fancybox-1.3.4.js")%>' type="text/javascript"></script>
<link href='<%#ResolveUrl("~/DesktopModules/ProductDetails/Scripts/fancybox/jquery.fancybox-1.3.4.css")%>' type="text/css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $("a.sfLightBox").fancybox();
    })
</script>

<div id="images" style="padding: 10px; float: left; width: 470px">
    <div id="image">
        <asp:Image ID="Image1" runat="server" ImageUrl='<%# hotel.Image %>' Width="450px" />
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
    <div id="location" style="padding: 10px;">
        <h2>Location</h2>
        <%# hotel.Name %><br />
        <%# hotel.Address %><br />
        <asp:Label runat="server" ID="LabelLocation"></asp:Label><br />
        <%# hotel.PostCode %>
    </div>
</div>
<div id="details" style="padding: 10px;">
    <h1><%# hotel.Name %></h1>
    <h2><%# hotel.UnitCost != null ? Utils.GetCurrencySymbol(hotel.CurrencyCode) + hotel.UnitCost.Value.ToString("#0.00") : String.Empty %></h2>
    <telerik:RadRating ID="RadRatingStar" runat="server" Value='<%# hotel.Star ?? 0.0m %>' ReadOnly="True" />
    <div id="description" style="padding: 10px;">
        <%# hotel.Description %>
    </div>
    <div id="extradescription" style="padding: 10px;">
        <%# hotel.ExtraDescription %>
    </div>
</div>
<div id="footer">
    <asp:Button ID="ButtonBackToSearch" runat="server" Text="Back to Search" CausesValidation="False" OnClick="ButtonBackToSearch_Click" UseSubmitBehavior="False" />
    &nbsp;
    <asp:Button ID="ButtonBookNow" runat="server" Text="Book Now!" CausesValidation="False" OnClick="ButtonBookNow_Click" UseSubmitBehavior="False" />
    <p>
        <uc1:PointOnMap runat="server" id="PointOnMap1" />
    </p>
</div>
