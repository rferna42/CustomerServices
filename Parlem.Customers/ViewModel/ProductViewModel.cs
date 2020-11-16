using System;

namespace ViewModel
{
    public class ProductViewModel
    {
        public int serviceId { get; set; }
        public string productName { get; set; }
        public string productNameType { get; set; }
        public Nullable<int> numeracioTerminal { get; set; }
        public Nullable<System.DateTime> soldAt { get; set; }
        public Nullable<int> customerId { get; set; }
    }
}