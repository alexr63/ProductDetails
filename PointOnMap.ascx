<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PointOnMap.ascx.cs" Inherits="ProductDetails.PointOnMap" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<div style="float: left; margin: 4px 0px;">
    <cc1:GMap ID="GMap1" runat="server" serverEventsType="AspNetPostBack" enableServerEvents="true"
        Width="400px" Height="350px" OnZoomEnd="GMap1_ZoomEnd" />
</div>
