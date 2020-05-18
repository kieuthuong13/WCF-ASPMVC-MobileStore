using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mobie_store.Controllers
{
    /*
    public class APIController : Controller
    {
        private static ViewService.ViewServiceClient viewSV = new ViewService.ViewServiceClient();
        private static DeleteService.DeleteServiceClient deleteSV = new DeleteService.DeleteServiceClient();
        private static EditService.EditServiceClient editSV = new EditService.EditServiceClient();
        private static AddService.AddServiceClient addSV = new AddService.AddServiceClient();

        // GET: API
        public ActionResult Index(int id = 0, string nametable = "product")
        {
            if (!string.IsNullOrWhiteSpace(nametable) && id >= 0)
            {
                switch (nametable)
                {
                    case "admin":
                        return View("Index_admin", viewSV.Get_admin(Session["token"] as string, (Session["admin"] as Mobie_store.ViewService.admin).id, id));
                    case "category":
                        return View("Index_category", viewSV.Get_category(id));
                    case "comment":
                        return View("Index_comment", viewSV.Get_comment(id));
                    case "discount":
                        return View("Index_discount", viewSV.Get_discount(id));
                    case "image":
                        return View("Index_image", viewSV.Get_image(id));
                    case "order":
                        return View("Index_order", viewSV.Get_order(id));
                    case "post":
                        return View("Index_post", viewSV.Get_post(id));
                    case "product":
                        return View("Index_product", viewSV.Get_product(id));
                    case "review":
                        return View("Index_review", viewSV.Get_review(id));
                    case "user":
                        return View("Index_user", viewSV.Get_user(id));
                    case "token":
                        return View("Index_token", viewSV.Get_token(id));
                    case "utoken":
                        return View("Index_utoken", viewSV.Get_utoken(id));
                    default:
                        break;
                }
            }

            return null;
        }

        public ActionResult Delete(int id, string nametable)
        {
            if (!string.IsNullOrWhiteSpace(nametable) && id >= 0)
            {
                switch (nametable)
                {
                    case "admin":
                        ViewBag.message = deleteSV.Delete_admin(id);
                        break;
                    case "category":
                        ViewBag.message = deleteSV.Delete_category(id);
                        break;
                    case "comment":
                        ViewBag.message = deleteSV.Delete_comment(id);
                        break;
                    case "discount":
                        ViewBag.message = deleteSV.Delete_discount(id);
                        break;
                    case "image":
                        ViewBag.message = deleteSV.Delete_image(id);
                        break;
                    case "order":
                        ViewBag.message = deleteSV.Delete_order(id);
                        break;
                    case "post":
                        ViewBag.message = deleteSV.Delete_post(id);
                        break;
                    case "product":
                        ViewBag.message = deleteSV.Delete_product(id);
                        break;
                    case "review":
                        ViewBag.message = deleteSV.Delete_review(id);
                        break;
                    case "user":
                        ViewBag.message = deleteSV.Delete_user(id);
                        break;
                    case "token":
                        ViewBag.message = deleteSV.Delete_token(id);
                        break;
                    case "utoken":
                        ViewBag.message = deleteSV.Delete_utoken(id);
                        break;
                    default:
                        break;
                }
            }
            return null;
        }

        #region Action result - Add action
        public ActionResult Add_admin(int id, string _username = null, string _pwd = null, string _email = null, string _address = null, string _phone = null, int? _level = null, string _image = null, string _fullname = null)
        {
            addSV.Add_admin(id, _username, _pwd, _email, _address, _phone, _level, _image, _fullname);
            return null;
        }

        public ActionResult Add_category(int id, string _name = null, string _description = null)
        {
            addSV.Add_category(id, _name, _description);
            return null;
        }

        public ActionResult Add_comment(int id, int? _product_id = null, int? _user_id = null, string _comments = null)
        {
            addSV.Add_comment(id, _product_id, _user_id, _comments);
            return null;
        }

        public ActionResult Add_discount(int id, string _value = null, string _name = null)
        {
            addSV.Add_discount(id, _value, _name);
            return null;
        }

        public ActionResult Add_image(int id, string _url = null, int? _product_id = null)
        {
            addSV.Add_image(id, _url, _product_id);
            return null;
        }

        public ActionResult Add_order(int id, int? _user_id = null, string _total_money = null, string _date_create = null, string _method = null)
        {
            addSV.Add_order(id, _user_id, _total_money, _date_create, _method);
            return null;
        }

        public ActionResult Add_post(int id, int? _product_id = null, string _name = null, string _descripton = null)
        {
            addSV.Add_post(id, _product_id, _name, _descripton);
            return null;
        }

        public ActionResult Add_product(int id, string _sku = null, string _name = null, string _price = null, string _Ghz = null, string _color = null, string _sensor = null, string _cpu = null, string _ram = null, string _storage = null, string _camera_front = null, string _camera_rear = null, string _battery = null, string _display = null, string _sim = null, string _status = null, int? _activate = null, int? _product_cate_id = null, int? _discount_id = null, string _image = null)
        {
            addSV.Add_product(id, _sku, _name, _price, _Ghz, _color, _sensor, _cpu, _ram, _storage, _camera_front, _camera_rear, _battery, _display, _sim, _status, _activate, _product_cate_id, _discount_id, _image);
            return null;
        }

        public ActionResult Add_review(int id, int? _product_id = null, int? _user_id = null, string _reviews = null)
        {
            addSV.Add_review(id, _product_id, _user_id, _reviews);
            return null;
        }

        public ActionResult Add_user(int id, string _username = null, string _fullname = null, string _pwd = null, string _email = null, string _address = null, string _phone = null, string _image = null, int? _activated = null)
        {
            addSV.Add_user(id, _username, _fullname, _pwd, _email, _address, _phone, _image, _activated);
            return null;
        }

        public ActionResult Add_token(int id, string _value = null, int? _admin_id = null)
        {
            addSV.Add_token(id, _value, _admin_id);
            return null;
        }

        public ActionResult Add_utoken(int id, string _value = null, int? _user_id = null)
        {
            addSV.Add_utoken(id, _value, _user_id);
            return null;
        }
        #endregion

        #region Action result - Edit action
        public ActionResult Edit_admin(int id, string _username = null, string _pwd = null, string _email = null, string _address = null, string _phone = null, int? _level = null, string _image = null, string _fullname = null)
        {
            editSV.Edit_admin(id, _username, _pwd, _email, _address, _phone, _level, _image, _fullname);
            return null;
        }

        public ActionResult Edit_category(int id, string _name = null, string _description = null)
        {
            editSV.Edit_category(id, _name, _description);
            return null;
        }

        public ActionResult Edit_comment(int id, int? _product_id = null, int? _user_id = null, string _comments = null)
        {
            editSV.Edit_comment(id, _product_id, _user_id, _comments);
            return null;
        }

        public ActionResult Edit_discount(int id, string _value = null, string _name = null)
        {
            editSV.Edit_discount(id, _value, _name);
            return null;
        }

        public ActionResult Edit_image(int id, string _url = null, int? _product_id = null)
        {
            editSV.Edit_image(id, _url, _product_id);
            return null;
        }

        public ActionResult Edit_order(int id, int? _user_id = null, string _total_money = null, string _date_create = null, string _method = null)
        {
            editSV.Edit_order(id, _user_id, _total_money, _date_create, _method);
            return null;
        }

        public ActionResult Edit_post(int id, int? _product_id = null, string _name = null, string _descripton = null)
        {
            editSV.Edit_post(id, _product_id, _name, _descripton);
            return null;
        }

        public ActionResult Edit_product(int id, string _sku = null, string _name = null, string _price = null, string _Ghz = null, string _color = null, string _sensor = null, string _cpu = null, string _ram = null, string _storage = null, string _camera_front = null, string _camera_rear = null, string _battery = null, string _display = null, string _sim = null, string _status = null, int? _activate = null, int? _product_cate_id = null, int? _discount_id = null, string _image = null)
        {
            editSV.Edit_product(id, _sku, _name, _price, _Ghz, _color, _sensor, _cpu, _ram, _storage, _camera_front, _camera_rear, _battery, _display, _sim, _status, _activate, _product_cate_id, _discount_id, _image);
            return null;
        }

        public ActionResult Edit_review(int id, int? _product_id = null, int? _user_id = null, string _reviews = null)
        {
            editSV.Edit_review(id, _product_id, _user_id, _reviews);
            return null;
        }

        public ActionResult Edit_user(int id, string _username = null, string _fullname = null, string _pwd = null, string _email = null, string _address = null, string _phone = null, string _image = null, int? _activated = null)
        {
            editSV.Edit_user(id, _username, _fullname, _pwd, _email, _address, _phone, _image, _activated);
            return null;
        }

        public ActionResult Edit_token(int id, string _value = null, int? _admin_id = null)
        {
            editSV.Edit_token(id, _value, _admin_id);
            return null;
        }

        public ActionResult Edit_utoken(int id, string _value = null, int? _user_id = null)
        {
            editSV.Edit_utoken(id, _value, _user_id);
            return null;
        }
        #endregion
    }
    */
}