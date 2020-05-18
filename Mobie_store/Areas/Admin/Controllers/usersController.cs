using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Mobie_store.Models.Function;
using Mobie_store.ViewService;
using Mobie_store.AddService;
using Mobie_store.EditService;
using Mobie_store.DeleteService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        public string complete = "Insert Complete!";
        public string error = "Insert Error!";
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        private EditServiceClient editSV = new EditServiceClient();
        private DeleteServiceClient deleteSV = new DeleteServiceClient();

        [HttpGet]
        public ActionResult listUsers()
        {
            return View(viewSV.Get_user(
                Session["token"] as string,
                0,
                (Session["admin"] as Mobie_store.ViewService.admin).id).ToList());
        }
        [HttpGet]
        public ActionResult addNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addNew(user obj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    var _ex = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/Users"), Hash.EncMD5(filename)+_ex );
                    file.SaveAs(path);

                    var pwd = Hash.EncMD5(obj.pwd);
                    addSV.Add_user(
                        addSV.ID_Return("users"),
                        obj.username,
                        obj.fullname,
                        pwd,
                        obj.email,
                        obj.address,
                        obj.phone,
                        "/Upload/Users/" + Hash.EncMD5(filename) + _ex,
                        1);
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
            var user = viewSV.Get_user(Session["token"] as string,
                id,
                (Session["admin"] as Mobie_store.ViewService.admin).id).ToList().FirstOrDefault();
            if (user.activated == 1)
            {
                // Set active = 0
                user.activated = 0;
                editSV.Edit_user(
                        Session["token"] as string,
                        user.id,
                        (Session["admin"] as Mobie_store.ViewService.admin).id,
                        user.username,
                        user.fullname,
                        user.pwd,
                        user.email,
                        user.address,
                        user.phone,
                        user.image,
                        0);
                return st;
            }
            if (user.activated == 0)
            {
                // Set active = 1
                editSV.Edit_user(
                        Session["token"] as string,
                        user.id,
                        (Session["admin"] as Mobie_store.ViewService.admin).id,
                        user.username,
                        user.fullname,
                        user.pwd,
                        user.email,
                        user.address,
                        user.phone,
                        user.image,
                        1);
                st = true;
            }
            return st;
        }

        public bool delete(int id)
        {
            deleteSV.Delete_user(
                Session["token"] as string,
                id,
                (Session["admin"] as Mobie_store.ViewService.admin).id);
            return true;
        }

        [HttpPost]
        public JsonResult deleteUser(int id)
        {
            var _result = new UsersController().delete(id);
            return Json(new {
                status = _result
            });
        }

        [HttpPost]
        public JsonResult changeStatus(int id)
        {
            var result = new UsersController().status(id);
            return Json(new {
                status = result
            });
        }
    }
}