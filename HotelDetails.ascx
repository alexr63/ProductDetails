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

<asp:FormView ID="FormViewDetails" runat="server" ItemType="SelectedHotelsModel.Hotel" SelectMethod ="GetHotel" RenderOuterTable="false">
    <ItemTemplate>
        <div id="images" style="padding: 10px; float: left; width: 470px">
            <div id="image">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#:Item.Image %>' Width="450px" />
            </div>
            <div id="gallery" style="padding: 10px; clear: both">
                <asp:Repeater ID="Repeater1" runat="server" ItemType="SelectedHotelsModel.ProductImage">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" CssClass="sfLightBox" runat="server"
                            rel='<%# String.Format("{0}_mainImageGallery", ClientID) %>'
                            NavigateUrl='<%#:Item.URL %>' Width="100px" Height="100px">
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#:Item.URL %>' Width="100px" />
                        </asp:HyperLink>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div id="location" style="padding: 10px;">
                <h2>Location</h2>
                <%#:Item.Name %><br />
                <%#:Item.Address %><br />
                <%#:Item.GeoName.Name %><br />
                <%#:Item.PostCode %>
            </div>
        </div>
        <div id="details" style="padding: 10px;">
            <h1><%#:Item.Name %></h1>
            <h2><%#:Item.UnitCost != null ? Utils.GetCurrencySymbol(Item.CurrencyCode) + Item.UnitCost.Value.ToString("#0.00") : String.Empty %></h2>
            <telerik:RadRating ID="RadRatingStar" runat="server" Value='<%#:Item.Star ?? 0.0m %>' ReadOnly="True" />
            <%#:Item.CustomerRating != null ? String.Format("({0}/5 )", Item.CustomerRating) : String.Empty %>
            <div id="description" style="padding: 10px;">
                <%#:Item.Description %>
            </div>
            <div id="extradescription" style="padding: 10px;">
                <%#:Item.ExtraDescription %>
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
    </ItemTemplate>
</asp:FormView>
