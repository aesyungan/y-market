using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using y_market.Models;

namespace y_market.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public ProductOrder Product { get; set; }
        public ICollection<ProductOrder> Products { get; set; }
    }
}