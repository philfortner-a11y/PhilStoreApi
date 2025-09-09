using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhilStoreApi.Data
{
    public class ProductImageData
    {
        //Class declarations
        SqlTools mySqlTools;

        public ProductImageData()
        {
            mySqlTools = new SqlTools();
        }

        public string GetProductImageById(Int32 ProductId)
        {
            string strFileNameAndPath;
            strFileNameAndPath = "C:\\Dogs\\CatBananas.jpg";
            return strFileNameAndPath;
        }
    }
}