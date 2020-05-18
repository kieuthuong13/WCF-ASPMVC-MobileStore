using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.ViewService;
using Mobie_store.DeleteService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class khaiController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        private DeleteServiceClient deleteSV = new DeleteServiceClient();

        // GET: Admin/khai
        public ActionResult Order(int id = 0)
        {
            var lrecord = viewSV.Get_order(Session["token"] as string, id, null, (Session["admin"] as admin).id);

            ViewBag.message = "";
            return View(lrecord);
        }

        public ActionResult DeleteOrder(int id)
        {
            ViewBag.message = deleteSV.Delete_order(Session["token"] as string, (Session["admin"] as admin).id, id);
            return RedirectToAction("Order", "khai");
        }
    }
}