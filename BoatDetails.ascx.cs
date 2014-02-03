// Copyright (c) 2012 Cowrie

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using SelectedHotelsModel;

namespace Cowrie.Modules.ProductDetails
{
    public partial class BoatDetails : PortalModuleBase
    {
        public Boat boat;

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
                            boat = db.Products.Find(id) as Boat;
                            if (boat != null)
                            {
                                ((DotNetNuke.Framework.CDefault)Page).Title = boat.Name;
                                Repeater1.DataSource = boat.ProductImages;
                                Repeater1.DataBind();
                                RepeaterSpecs.DataSource = boat.ProductSpecs;
                                RepeaterSpecs.DataBind();
                                DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Exceptions.ProcessModuleLoadException(this, ex);
                }
            }
        }
    }
}