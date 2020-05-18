using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.AddService;
using Mobie_store.DeleteService;
using Mobie_store.ViewService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        private DeleteServiceClient deleteSV = new DeleteServiceClient();
        ~CategoryController()
        {
            viewSV.Close();
            addSV.Close();
            deleteSV.Close();
        }
        // GET: category
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult listCategory()
        {
            List<category> cate = viewSV.Get_category(0).ToList();
            return View(cate);

        }
        [HttpGet]
        public ActionResult addNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addNew(category model)
        {
            if (ModelState.IsValid)
            {
                addSV.Add_category(
                    Session["token"] as string,
                    (Session["admin"] as Mobie_store.ViewService.admin).id,
                    addSV.ID_Return("category"), 
                    model.name, 
                    model.description);
                ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }

        public bool delete(int id)
        {
            deleteSV.Delete_category(
                Session["token"] as string,
                (Session["admin"] as Mobie_store.ViewService.admin).id,
                id);
            return true;
        }

        [HttpPost]
        public JsonResult deleteCate(int id)
        {
            var _result = new CategoryController().delete(id);
            return Json(new
            {
                status = _result
            });
        }
    }
}