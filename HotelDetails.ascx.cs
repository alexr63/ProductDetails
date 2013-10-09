// Copyright (c) 2012 Cowrie

using System;
using System.Text;
using System.Web.UI;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Services.Exceptions;
using ProductDetails;
using ProductList;

namespace Cowrie.Modules.ProductDetails
{
    public partial class HotelDetails : PortalModuleBase
    {
        public Hotel hotel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["Id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["Id"]);
                        using (SelectedHotelsEntities db = new SelectedHotelsEntities())
                        {
                            hotel = db.Products.Find(id) as Hotel;
                            if (hotel != null)
                            {
                                ((DotNetNuke.Framework.CDefault)Page).Title = hotel.Name;
                                Repeater1.DataSource = hotel.ProductImages;
                                Repeater1.DataBind();
                            }
                            var page = (DotNetNuke.Framework.CDefault) this.Page;
                            page.Title = String.Format("{0} | {1}", PortalSettings.PortalName, hotel.Name);
                            page.Description = hotel.Description;
                            var keyWords = hotel.Name;
                            if (!String.IsNullOrEmpty(hotel.Address))
                            {
                                keyWords += ", " + hotel.Address;
                            }
                            if (hotel.Location != null)
                            {
                                keyWords += ", " + hotel.Location.Name;
                                if (hotel.Location.ParentLocation != null)
                                {
                                    keyWords += ", " + hotel.Location.ParentLocation.Name;
                                    if (hotel.Location.ParentLocation.ParentLocation != null)
                                    {
                                        keyWords += ", " + hotel.Location.ParentLocation.ParentLocation.Name;
                                    }
                                }
                            }
                            page.KeyWords = keyWords;
                            DataBind();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Exceptions.ProcessModuleLoadException(this, ex);
                }
            }
        }

        protected void ButtonBookNow_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                using (SelectedHotelsEntities db = new SelectedHotelsEntities())
                {
                    hotel = db.Products.Find(id) as Hotel;
                    if (hotel != null)
                    {
                        Response.Redirect(hotel.URL);
                    }
                }
            }
        }

        protected void ButtonBackToSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.ParentId));
        }
    }
}