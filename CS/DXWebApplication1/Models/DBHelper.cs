using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models {

    public class DBHelper {

        const string NorthwindDataContextKey = "DXNorthwindDataContext";

        public static NwindDataClassesDataContext DB {
            get {
                if (HttpContext.Current.Items[NorthwindDataContextKey] == null)
                    HttpContext.Current.Items[NorthwindDataContextKey] = new NwindDataClassesDataContext();
                return (NwindDataClassesDataContext)HttpContext.Current.Items[NorthwindDataContextKey];
            }
        }

        public static int GetKeyIdByDisplayIndex(int? displayIndex) {
            var model = DB.Products;
            var rowKey = model.Where(q => q.DisplayIndex == displayIndex).Select(q => q.ProductID).FirstOrDefault();
            return rowKey;
        }

        public static void UpdateDisplayIndex(int? rowKey, int? displayIndex) {
            var model = DB.Products;
            var product = model.Where(q => q.ProductID == rowKey).FirstOrDefault();
            product.DisplayIndex = displayIndex;
            DB.SubmitChanges();
        }
    }
}