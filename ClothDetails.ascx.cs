// Copyright (c) 2012 Cowrie

using System;
using System.Linq;
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
                                if (cloth.Sizes.Any())
                                {
                                    RepeaterSizes.Visible = true;
                                    RepeaterSizes.DataSource = cloth.Sizes;
                                    RepeaterSizes.DataBind();
                                }
                                if (cloth.Styles.Any())
                                {
                                    RepeaterStyles.Visible = true;
                                    RepeaterStyles.DataSource = cloth.Styles;
                                    RepeaterStyles.DataBind();
                                }
                                if (cloth.ProductImages.Any())
                                {
                                    RepeaterImages.Visible = true;
                                    RepeaterImages.DataSource = cloth.ProductImages;
                                    RepeaterImages.DataBind();
                                }
                                if (cloth.Departments.Any())
                                {
                                    RepeaterDepartments.Visible = true;
                                    RepeaterDepartments.DataSource = cloth.Departments;
                                    RepeaterDepartments.DataBind();
                                }
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
        protected void ButtonBuyNow_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                int id = int.Parse(Request.QueryString["Id"]);
                using (SelectedHotelsEntities db = new SelectedHotelsEntities())
                {
                    cloth = db.Products.Find(id) as Cloth;
                    if (cloth != null)
                    {
                        Response.Redirect(cloth.URL);
                    }
                }
            }
        }

        protected void ButtonBackToSearch_Click(object sender, EventArgs e)
        {
            Session["ReturnFromDetails"] = true;
            if (Session["ListTabId"] != null)
            {
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(Convert.ToInt32(Session["ListTabId"])));
                Session["ListTabId"] = null;
            }
            else
            {
                Response.Redirect(DotNetNuke.Common.Globals.NavigateURL(PortalSettings.ActiveTab.ParentId));
            }
        }
    }
}