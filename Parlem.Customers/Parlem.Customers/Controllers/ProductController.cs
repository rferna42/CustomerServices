using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Parlem.Customers.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddProduct(ViewModel.ProductViewModel model)
        {
            using (Models.CustomerServicesEntities db = new Models.CustomerServicesEntities())
            {
                var product = new Models.Product();

                product.serviceId = model.serviceId;
                product.productName = model.productName;
                product.productNameType = model.productNameType;
                product.numeracioTerminal = model.numeracioTerminal;
                product.soldAt = model.soldAt;
                product.customerId = model.customerId;

                db.Product.Add(product);
                db.SaveChanges();
            }
            return Ok("Producto añadido.");
        }

        [HttpGet]
        public IHttpActionResult GetProduct(ViewModel.ProductViewModel model)
        {
            List<ViewModel.ProductViewModel> list = new List<ViewModel.ProductViewModel>();

            using (Models.CustomerServicesEntities db = new Models.CustomerServicesEntities())
            {
                list = (from d in db.Product
                        select new ViewModel.ProductViewModel
                        {
                            serviceId = d.serviceId,
                            productName = d.productName,
                            productNameType = d.productNameType,
                            numeracioTerminal = d.numeracioTerminal,
                            soldAt = d.soldAt,
                            customerId = d.customerId
                        }).ToList();
            }
            return Ok(list);
        }
    }
}
