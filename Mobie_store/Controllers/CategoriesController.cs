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
            var litem = db.Get_product(0);
            if (litem == null)
                return View();

            List<product> product = litem.ToList();
            return View(product.Where(m => m.product_cate_id == id));
        }
    }
}