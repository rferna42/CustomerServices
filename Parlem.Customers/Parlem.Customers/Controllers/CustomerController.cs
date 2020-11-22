using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Parlem.Customers.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddCustomer(DataBase.Model.ViewModel.CustomerViewModel model)
        {
            using (DataBase.Model.CustomerServicesEntities db = new DataBase.Model.CustomerServicesEntities())
            {
                var customer = new DataBase.Model.Customer();

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
        public IHttpActionResult GetCustomer(DataBase.Model.ViewModel.CustomerViewModel model)
        {
            List<DataBase.Model.ViewModel.CustomerViewModel> list = new List<DataBase.Model.ViewModel.CustomerViewModel>();

            using (DataBase.Model.CustomerServicesEntities db = new DataBase.Model.CustomerServicesEntities())
            {
                list = (from d in db.Customer select new DataBase.Model.ViewModel.CustomerViewModel
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
