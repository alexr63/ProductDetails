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
using ProductList;

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
                IList<Hotel> hotels = (from p in db.Products
                                       where !p.IsDeleted
                                       select p).OfType<Hotel>().ToList();
		        foreach (var hotel in hotels)
		        {
                    SearchItemInfo searchInfo = new SearchItemInfo(hotel.Name, hotel.Description, hotel.CreatedByUser, hotel.CreatedDate,
                                                        modInfo.ModuleID, hotel.Id.ToString(), hotel.Description, "Id=" + hotel.Id);
                    searchItems.Add(searchInfo);
                }
            }

			return searchItems;
		}

		#endregion
	}
}
