using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using DotNetNuke;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using SelectedHotelsModel;

namespace Cowrie.ProductDetails.Components
{
    public class ProductDetailsController : ISearchable
	{
		#region ISearchable Members

		/// <summary>
		/// Implements the search interface required to allow DNN to index/search the content of your
		/// module
		/// </summary>
		/// <param name="modInfo"></param>
		/// <returns></returns>
		public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(ModuleInfo modInfo)
		{
			SearchItemInfoCollection searchItems = new SearchItemInfoCollection();
		    using (SelectedHotelsEntities db = new SelectedHotelsEntities())
		    {
                IList<Product> products = (from p in db.Products
                                       where !p.IsDeleted
                                       select p).ToList();
		        foreach (var product in products)
		        {
                    SearchItemInfo searchInfo = new SearchItemInfo(product.Name, product.Description, product.CreatedByUser, product.CreatedDate,
                                                        modInfo.ModuleID, product.Id.ToString(), product.Description, "Id=" + product.Id);
                    searchItems.Add(searchInfo);
                }
            }

			return searchItems;
		}

		#endregion
	}
}
