// Copyright (c) 2012 Cowrie

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using SelectedHotelsModel;

namespace Cowrie.Modules.ProductList
{
    public partial class ClothDetails : PortalModuleBase
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
                                RepeaterSizes.DataSource = cloth.ClothSizes;
                                RepeaterSizes.DataBind();
                                RepeaterImages.DataSource = cloth.ProductImages;
                                RepeaterImages.DataBind();
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
        protected void ButtonBackToSearch_Click(object sender, EventArgs e)
        {
            Session["ReturnFromDetails"] = true;
            Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.ParentId));
        }
    }
}