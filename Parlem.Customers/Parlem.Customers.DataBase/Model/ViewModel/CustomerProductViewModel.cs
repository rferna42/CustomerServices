using System;

namespace Parlem.Customers.DataBase.Model.ViewModel
{
    public class CustomerProductViewModel
    {
        public int customerId { get; set; }
        public string docNum { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public int serviceId { get; set; }
        public string productName { get; set; }
        public Nullable<System.DateTime> soldAt { get; set; }
    }
}
