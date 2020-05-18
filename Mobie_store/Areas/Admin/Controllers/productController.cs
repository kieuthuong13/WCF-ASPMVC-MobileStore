using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.Models.Function;
using Mobie_store.ViewService;
using Mobie_store.AddService;
using Mobie_store.EditService;
using Mobie_store.DeleteService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        private EditServiceClient editSV = new EditServiceClient();
        private DeleteServiceClient deleteSV = new DeleteServiceClient();
        // GET: product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult listProduct()
        {
            List<product> product = viewSV.Get_product(0).ToList();
            return View(product);

        }
        [HttpGet]
        public ActionResult addNew()
        {
            List<category> cate = viewSV.Get_category(0).ToList();
            return View(cate);
        }
        [HttpPost]
        public ActionResult addNew(product model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    var _ex = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/SingleProduct"), Hash.EncMD5(filename) + _ex);
                    file.SaveAs(path);
                    
                    addSV.Add_product(
                        Session["token"] as string,
                        (Session["admin"] as Mobie_store.ViewService.admin).id,
                        addSV.ID_Return("products"),
                        model.sku,
                        model.name,
                        model.price,
                        model.Ghz,
                        model.color,
                        model.sensor,
                        model.cpu,
                        model.ram,
                        model.storage,
                        model.camera_front,
                        model.camera_rear,
                        model.battery,
                        model.display,
                        model.sim,
                        model.status,
                        1,
                        model.product_cate_id,
                        model.discount_id,
                        "/Upload/SingleProduct/" + Hash.EncMD5(filename) + _ex);
                    ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
                }
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }
        public bool status(int id)
        {
            var st = false;
            var products = viewSV.Get_product(id).FirstOrDefault();
            if (products.activate == 1)
            {
                // Set active  = 0
                //products.activate = 0;
                editSV.Edit_product(
                    Session["token"] as string,
                    (Session["admin"] as Mobie_store.ViewService.admin).id,
                    products.id,
                    products.sku,
                    products.name,
                    products.price,
                    products.Ghz,
                    products.color,
                    products.sensor,
                    products.cpu,
                    products.ram,
                    products.storage,
                    products.camera_front,
                    products.camera_rear,
                    products.battery,
                    products.display,
                    products.sim,
                    products.status,
                    0,
                    products.product_cate_id,
                    products.discount_id,
                    products.image);
                return st;
            }
            else if (products.activate == 0)
            {
                // Set active = 1
                editSV.Edit_product(
                    Session["token"] as string,
                    (Session["admin"] as Mobie_store.ViewService.admin).id,
                    products.id,
                    products.sku,
                    products.name,
                    products.price,
                    products.Ghz,
                    products.color,
                    products.sensor,
                    products.cpu,
                    products.ram,
                    products.storage,
                    products.camera_front,
                    products.camera_rear,
                    products.battery,
                    products.display,
                    products.sim,
                    products.status,
                    1,
                    products.product_cate_id,
                    products.discount_id,
                    products.image);
                st = true;
            }
            return st;
        }
        public bool delete(int id)
        {
            // Remove product
            deleteSV.Delete_product(
                Session["token"] as string,
                (Session["admin"] as Mobie_store.ViewService.admin).id,
                id);
            return true;
        }
        [HttpPost]
        public JsonResult deleteProduct(int id)
        {
            var _result = new ProductController().delete(id);
            return Json(new
            {
                status = _result
            });
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new ProductController().status(id);
            return Json(new
            {
                status = result
            });
        }
    }
}