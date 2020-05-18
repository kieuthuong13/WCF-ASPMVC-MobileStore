using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.ViewService;

namespace Mobie_store.Controllers
{
    public class HomeController : Controller
    {
        private ViewServiceClient db = new ViewServiceClient();
        public ActionResult Index()
        {
            List<product> lproducts = db.Get_product(0).ToList();
            lproducts = lproducts.OrderByDescending(m => m.follow).ToList();
            return View(lproducts);
        }
        ~HomeController()
        {
            db.Close();
        }
    }
}