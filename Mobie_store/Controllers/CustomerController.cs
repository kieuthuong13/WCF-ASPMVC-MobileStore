using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mobie_store.Hellper;
using System.Data;
//using Mobie_store.Models.Entity;
using Mobie_store.Models.Function;
using Mobie_store.ViewService;
using Mobie_store.AddService;
using Mobie_store.LoginService;

namespace Mobie_store.Controllers
{
    public class CustomerController : Controller
    {
        private static ViewServiceClient viewSV = new ViewServiceClient();
        private AddServiceClient addSV = new AddServiceClient();
        private LoginServiceClient loginSV = new LoginServiceClient();
        // GET: Customer
        public List<order> getorder(int id = 0)
        {
            try
            {
                string utoken = Session["utoken"] as string;
                var user2 = Session["user"] as user;
                return viewSV.Get_order(utoken, id, user2.id, null).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ActionResult Index(int id = 0)
        {
            if (Session["user"] != null)
            {
                user user = (user)Session["user"];
                if (user.activated == 1) {
                    ViewBag.Order = getorder(id);
                    return View(user);
                }
                else
                {
                    Session["user"] = null;
                    return RedirectToAction("Deni", "Customer");
                }
            }
            else
            {
                return RedirectToAction("Login","Customer");
            }
            
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user obj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    var _ex = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Upload/Users"), Hash.EncMD5(filename) + _ex);
                    file.SaveAs(path);

                    var pwd = Hash.EncMD5(obj.pwd);
                    // them nguoi dung
                    addSV.Add_user(addSV.ID_Return("users"), obj.username, obj.fullname, pwd, obj.email, obj.address, 
                        obj.phone, "/Upload/Users/" + Hash.EncMD5(filename) + _ex, 1);
                    
                    ViewBag.HtmlStr = "<div class=\"alert alert-info alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Complete!.</span></div>";
                }
            }
            else
            {
                ViewBag.HtmlStr = "<div class=\"alert alert-rose alert-with-icon col-md-6 col-md-offset-3\" data-notify=\"container\"><i class=\"material-icons\" data-notify=\"icon\">notifications</i><button type = \"button\" aria-hidden=\"true\" class=\"close\"><i class=\"material-icons\">close</i></button><span data-notify=\"message\">Insert Error!.</span></div>";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(user model)
        {
            Session["utoken"] = null;
            if (ModelState.IsValid)
            {
                var pwd = Hash.EncMD5(model.pwd);
                int userid;
                var token = loginSV.LoginUser(model.username, Hash.EncMD5(model.pwd), out userid);//db.users.Where(a => a.username.Equals(model.username) && a.pwd.Equals(pwd)).FirstOrDefault();
                Session["utoken"] = token;
                if (token != null)
                {
                    Session["user"] = viewSV.Get_user(token, userid, null).FirstOrDefault();
                    return RedirectToAction("Index", "Customer");
                }
            }
            else
            {
                RedirectToAction("Login", "Customer");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["utoken"] = null;
            return RedirectToAction("Login", "Customer");
        }

        public ActionResult Deni()
        {
            return View();
        }
        ~CustomerController()
        {
            viewSV.Close();
        }
    }
}