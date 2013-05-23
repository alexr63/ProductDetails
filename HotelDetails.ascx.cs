// Copyright (c) 2012 Cowrie

using System;
using DotNetNuke.Entities.Modules;
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
    }
}