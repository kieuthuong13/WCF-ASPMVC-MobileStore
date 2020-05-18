using Mobie_store.AddService;
using Mobie_store.ViewService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        
        public ActionResult listPosts()
        {
            return View(viewSV.Get_post(0).ToList());
        }

        [HttpGet]
        public ActionResult addNew()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult addNew(post obj)
        {
            if (ModelState.IsValid)
            {
                addSV.Add_post(
                    Session["token"] as string,
                    (Session["admin"] as Mobie_store.ViewService.admin).id,
                    addSV.ID_Return("posts"),
                    obj.product_id,
                    obj.name,
                    obj.descripton);
                ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }
    }
}