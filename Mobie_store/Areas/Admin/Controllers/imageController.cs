using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mobie_store.Models.Function;
using Mobie_store.ViewService;
using Mobie_store.AddService;
using Mobie_store.DeleteService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        private DeleteServiceClient deleteSV = new DeleteServiceClient();

        ~ImageController()
        {
            viewSV.Close();
            addSV.Close();
            deleteSV.Close();
        }

        [HttpGet]
        public ActionResult listImage()
        {
            return View(viewSV.Get_image(0).ToList());
        }
        [HttpGet]
        public ActionResult addNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addNew(image obj, List<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                foreach (HttpPostedFileBase img in files)
                {
                    if (img != null && img.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(img.FileName);
                        var _ex = Path.GetExtension(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Upload/Products"), Hash.EncMD5(filename) + _ex);
                        img.SaveAs(path);
                        
                        addSV.Add_image(
                            Session["token"] as string,
                            (Session["admin"] as Mobie_store.ViewService.admin).id,
                            addSV.ID_Return("image"),
                            "/Upload/Products/" + Hash.EncMD5(filename) + _ex,
                            obj.product_id);

                        ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
                        ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", filename);
                    }
                }
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }
        public bool delete(int id)
        {
            // Remove image
            deleteSV.Delete_image(
                Session["token"] as string,
                (Session["admin"] as Mobie_store.ViewService.admin).id,
                id);
            return true;
        }

        [HttpPost]
        public JsonResult deleteImage(int id)
        {
            var _result = this.delete(id);
            return Json(new
            {
                status = _result
            });
        }
    }
}