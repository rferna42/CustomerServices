using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Parlem.Customers.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddProduct(DataBase.Model.ViewModel.ProductViewModel model)
        {
            try
            {
                using (DataBase.Model.CustomerServicesEntities db = new DataBase.Model.CustomerServicesEntities())
                {
                    var product = new DataBase.Model.Product();

                    product.serviceId = model.serviceId;
                    product.productName = model.productName;
                    product.productNameType = model.productNameType;
                    product.numeracioTerminal = model.numeracioTerminal;
                    product.soldAt = model.soldAt;
                    product.customerId = model.customerId;

                    db.Product.Add(product);
                    db.SaveChanges();

                    return Ok("Producto añadido");
                } 
            }
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error al hacer el método AddProduct: " +e);
            }
        }

        [HttpGet]
        public IHttpActionResult GetProduct(DataBase.Model.ViewModel.ProductViewModel model)
        {
            List<DataBase.Model.ViewModel.ProductViewModel> list = new List<DataBase.Model.ViewModel.ProductViewModel>();

            try
            {
                using (DataBase.Model.CustomerServicesEntities db = new DataBase.Model.CustomerServicesEntities())
                {
                    list = (from d in db.Product
                            select new DataBase.Model.ViewModel.ProductViewModel
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
            catch (Exception e)
            {
                throw new Exception("Se ha producido un error al hacer el método GetProduct: " + e);
            }
        }
    }
}
