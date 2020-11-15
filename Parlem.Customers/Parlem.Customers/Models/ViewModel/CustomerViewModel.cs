using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parlem.Customers.Models.ViewModel
{
    public class CustomerViewModel
    {
        public int customerId { get; set; }
        public string docType { get; set; }
        public string docNum { get; set; }
        public string email { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public Nullable<int> phone { get; set; }
    }
}