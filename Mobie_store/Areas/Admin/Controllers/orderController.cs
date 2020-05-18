using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.ViewService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        [HttpGet]
        public ActionResult listOrder()
        {
            return View(viewSV.Get_order(
                Session["token"] as string,
                0,
                null,
                (Session["admin"] as Mobie_store.ViewService.admin).id).ToList());
        }

        ~OrderController()
        {
            viewSV.Close();
        }
    }
}