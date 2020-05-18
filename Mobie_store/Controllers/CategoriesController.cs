using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.ViewService;


namespace Mobie_store.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Product(int id)
        {
            ViewServiceClient db = new ViewServiceClient();
            List<product> product = db.Get_product(0).ToList();
            return View(product.Where(m => m.product_cate_id == id));
        }
    }
}