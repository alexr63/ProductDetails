using System;
using System.Drawing;
using System.Text;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;

namespace ProductDetails
{
    public partial class PointOnMap : System.Web.UI.UserControl
    {
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public int InitialZoom { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

        public PointOnMap()
        {
            InitialZoom = 12;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    ResetMap();
                    FillHome();
                }
            }
            else
            {
                if (Request["__EVENTTARGET"] == "GMap1")
                {
                    int zoomLevel = int.Parse(Request["__EVENTARGUMENT"]);
                    if (zoomLevel >= 11)
                    {
                    }
                    else
                    {
                    }
                }
            }
        }

        private void ResetMap()
        {
            GMap1.reset();
            //GMap1.addControl(new GControl(GControl.preBuilt.GOverviewMapControl));
            //GMap1.addControl(new GControl(GControl.preBuilt.LargeMapControl));

            GMap1.addGMapUI(new GMapUI());

            KeyDragZoom keyDragZoom = new KeyDragZoom();
            keyDragZoom.key = KeyDragZoom.HotKeyEnum.ctrl;
            keyDragZoom.boxStyle = "{border: '4px solid #FFFF00'}";
            keyDragZoom.paneStyle = "{backgroundColor: 'black', opacity: 0.2, cursor: 'crosshair'}";

            GMap1.addKeyDragZoom(keyDragZoom);

            //GMap1.resetMarkerClusterer();
            GMap1.resetMarkers();
            GMap1.resetMarkerManager();
        }

        private void FillHome()
        {
            GLatLng gLatLng = null;
            if (Lat.HasValue)
            {
                gLatLng = new GLatLng(Lat.Value, Lon.Value);
            }
            else if (Address != null)
            {
                GeoCode geoCode = GMap1.getGeoCodeRequest(Address);
                if (geoCode.valid)
                {
                    gLatLng = geoCode.Placemark.coordinates;
                }
            }
            if (gLatLng != null)
            {
                PinIcon pinIcon = new PinIcon(PinIcons.home, Color.FromArgb(0xB4, 0x97, 0x59));
                var markerOptions = new GMarkerOptions(new GIcon(pinIcon.ToString(), pinIcon.Shadow()),
                    Title.Replace("'", "´"));
                GMarker marker = new GMarker(gLatLng, markerOptions);
                //GMarker marker = new GMarker(gLatLng);
                StringBuilder sb = new StringBuilder();
                sb.Append(Title);
                GInfoWindow window = new GInfoWindow(marker, sb.ToString(), false);
                GMap1.addInfoWindow(window);
                GMap1.setCenter(new GLatLng(gLatLng.lat, gLatLng.lng), InitialZoom);
            }
        }

        protected string GMap1_ZoomEnd(object s, GAjaxServerEventZoomArgs e)
        {
            //return string.Format("__doPostBack('GMap1', '{0}')", e.newLevel);
            return String.Empty;
        }
    }
}