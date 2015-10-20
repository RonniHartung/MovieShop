using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieStoreUI.Models;

namespace MovieStoreUI.BusinessLogic
{
    public class AlbumUtil
    {
        // Putting the price calculation function in a separate class makes the
        // solution more flexible to changes. One future change could be to offer
        // customers discount under certain circumstances. Rules for calculating
        // discount changes frequently in the real world. Then we have one more
        // argument for putting the price calulation function in a separate class.
        public static decimal CalculateTotalPrice(IList<ShoppingCartItem> items)
        {
            return items.Sum(item => item.Quantity * item.UnitPrice);
        }
    }
}