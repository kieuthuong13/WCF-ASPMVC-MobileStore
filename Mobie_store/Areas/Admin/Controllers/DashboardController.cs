using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Mobie_store.Models.Function;
using Mobie_store.LoginService;
using Mobie_store.ViewService;
using Mobie_store.AddService;

namespace Mobie_store.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private LoginServiceClient loginSV = new LoginServiceClient();
        private ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Dashboard");
            }
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            Session["token"] = null;
            return RedirectToAction("Login", "Dashboard");
        }

        [HttpGet]
        public ActionResult profile()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Dasboard");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            Session["admin"] = null;
            Session["token"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin model)
        {
            if (ModelState.IsValid)
            {
                var pwd = Hash.EncMD5(model.pwd);
                int admin_id;
                var token = loginSV.LoginAdmin(model.email, pwd, out admin_id);
                if (token != null)
                {
                    Session["token"] = token;
                    Session["admin"] = viewSV.Get_admin(token, admin_id, admin_id).FirstOrDefault();
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
                RedirectToAction("Login", "main");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(admin model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0 && Session["admin"] != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/Admin"), filename);
                    file.SaveAs(path);
                    addSV.Add_admin(
                        Session["token"] as string,
                        (Session["admin"] as admin).id,
                        addSV.ID_Return("admin"), 
                        model.username,
                        Hash.EncMD5(model.pwd), 
                        model.email,
                        model.address,
                        model.phone,
                        1,
                        "/Upload/Admin/" + filename,
                        model.fullname
                        );
                    ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
                }
                RedirectToAction("Login", "Dashboard");
            }
            else
            {
                RedirectToAction("Register", "Dashboard");
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }
    }
}