// Copyright (c) 2012 Cowrie

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using SelectedHotelsModel;

namespace Cowrie.Modules.ProductList
{
    public partial class ClothesDetails : PortalModuleBase
    {
        public Cloth cloth;

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
                            cloth = db.Products.Find(id) as Cloth;
                            if (cloth != null)
                            {
                                Repeater1.DataSource = cloth.ProductImages;
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
    }
}