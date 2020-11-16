using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Parlem.Customers.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddCustomer(ViewModel.CustomerViewModel model)
        {
            using (Models.CustomerServicesEntities db = new Models.CustomerServicesEntities())
            {
                var customer = new Models.Customer();

                customer.customerId = model.customerId;
                customer.docType = model.docType;
                customer.docNum = model.docNum;
                customer.email = model.email;
                customer.customerId = model.customerId;
                customer.givenName = model.givenName;
                customer.familyName = model.familyName;
                customer.phone = model.phone;

                db.Customer.Add(customer);
                db.SaveChanges();
            }
            return Ok("Customer añadido.");
        }

        [HttpGet]
        public IHttpActionResult GetCustomer(ViewModel.CustomerViewModel model)
        {
            List<ViewModel.CustomerViewModel> list = new List<ViewModel.CustomerViewModel>();

            using (Models.CustomerServicesEntities db = new Models.CustomerServicesEntities())
            {
                list = (from d in db.Customer select new ViewModel.CustomerViewModel
                {
                    customerId = d.customerId,
                    docType = d.docType,
                    docNum = d.docNum,
                    email = d.email,
                    givenName = d.givenName,
                    familyName = d.familyName,
                    phone = d.phone
                }).ToList();
            }
            return Ok(list);
        }
    }
}
