using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhilStoreApi.Models
{
    public class Products
    {
        //Setup properties for the API
        public Int32 ID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public Boolean IsActive { get; set; }
        public Decimal RetailPrice { get; set; }
        public Decimal RegularPrice { get; set; }
        public Decimal SalePrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}