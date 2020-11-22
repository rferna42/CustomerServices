using Parlem.Customers.DataBase.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Parlem.Customers.Controllers
{
    public class FormsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetProductsByCustomerId(DataBase.Model.ViewModel.CustomerProductViewModel model, string customerDocNum)
        {
            var list = new List<DataBase.Model.ViewModel.CustomerProductViewModel>();
            
            using (var db = new CustomerServicesEntities())
            {
                list = (from d in db.Customer
                        join p in db.Product 
                        on d.customerId equals p.customerId
                        where d.docNum == customerDocNum
                        select new DataBase.Model.ViewModel.CustomerProductViewModel
                        {
                            customerId = d.customerId,
                            docNum = d.docNum,
                            givenName = d.givenName,
                            familyName = d.familyName,
                            serviceId = p.serviceId,
                            productName = p.productName,
                            soldAt = p.soldAt
                        }).ToList();
            }
            return Ok(list);
        }
    }
}
