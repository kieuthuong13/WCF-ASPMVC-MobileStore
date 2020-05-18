using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.ViewService;

namespace Mobie_store.Controllers
{
    public class ListProductController : Controller
    {
        private ViewServiceClient db = new ViewServiceClient();
        // GET: ListProduct
        public ActionResult Index()
        {
            List<product> product = db.Get_product(0).ToList();
            return View(product);
        }
        [HttpPost]
        public ActionResult Search(string Desc)
        {
            Desc = Desc.ToUpper();
            List<product> lproducts = db.Get_product(0).Where(m => m.name.ToUpper().Contains(Desc)).ToList();
            return View(lproducts);
        }
        ~ListProductController()
        {
            db.Close();
        }
    }
}