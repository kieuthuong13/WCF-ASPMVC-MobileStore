using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Net.Http;
using System.Diagnostics;
using Mobie_store.Models.Function;
using Mobie_store.ViewService;
using Mobie_store.AddService;

namespace Mobie_store.Controllers
{
    public class CartController : Controller
    {
        private AddServiceClient addSV = new AddServiceClient();
        private ViewServiceClient viewSV = new ViewServiceClient();

        #region MyFunction
        public void CreateOrder(int id, int SoLuong)
        {
            AddToCart(id, SoLuong);
        }

        public void VerifyPaymentInfo()
        {
            CheckOut();
        }

        public void UpdateOrderStatus(int id, int SoLuong)
        {
            UpdateQuantity(id, SoLuong);
        }

        public void AddDiscount(int id, int SoLuong)
        {
            AddToCart(id, SoLuong);
        }
        #endregion

        // GET: Cart
        public ActionResult Index()
        {
            Cart gio = (Cart)Session["cart"];
            if (gio == null)
                ViewBag.count = 0;
            else
                ViewBag.count = gio.getCount();
            return View();
        }
        public Cart Get()
        {
            return (Cart)Session["cart"];
        }

        public JsonResult AddToCart(int id, int SoLuong)
        {
            Cart gh;
            if (Session["cart"] == null)
            {
                gh = new Cart();
            }
            else
            {
                gh = Get();
            }
            product prAdd = new product();
            try
            {
                prAdd = viewSV.Get_product(id).FirstOrDefault();

                CartDetail dt = CartDetail.Post(prAdd, SoLuong);
                gh.add(dt);
                Session["cart"] = gh;
            }
            catch (Exception e)
            {
                return Json(new { status = false, mess = e.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { sluong = gh.getCount(), status = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete()
        {
            return RedirectToAction("Index", "Cart");
        }


        public JsonResult UpdateQuantity(int id, int SoLuong)
        {

            Cart gh;
            if (Session["cart"] == null)
            {
                gh = new Cart();
                return Json(new { status = false, mess = "Lỗi" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                gh = (Cart)Session["cart"];
                List<CartDetail> lst = gh.getCartDetailList();
                CartDetail pr = lst.Find(x => x.ID == id);
                pr.Quantity = SoLuong;
                return Json(new { status = true, mess = "Thành công", dongia = SoLuong * pr.Price, totalprice = gh.getTotalPrice() }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult Del(int ID)
        {

            Cart gh;
            if (Session["cart"] == null)
            {
                gh = new Cart();
                return Json(new { status = false, mess = "Lỗi" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                gh = (Cart)Session["cart"];
                List<CartDetail> lst = gh.getCartDetailList();

                if (lst.Count < 0)
                {
                    return Json(new { status = false, mess = "Lỗi" }, JsonRequestBehavior.AllowGet);
                }
                CartDetail pr = lst.SingleOrDefault(x => x.ID == ID);
                if (pr == null)
                {

                    return Json(new { status = false, mess = "Lỗi" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    lst.Remove(pr);
                    Session["cart"] = gh;
                    return Json(new { status = true, mess = "Thành công", totalprice = gh.getTotalPrice() }, JsonRequestBehavior.AllowGet);
                }

            }

        }


        public ActionResult DoneCheckOut(orderFnc bill)
        {
            user userorder = (user)Session["user"];
            if (bill != null)
            {
                //insert DetailBill
                Cart gio = (Cart)Session["cart"];
                List<CartDetail> cardt;
                if (gio != null)
                {
                    try
                    {
                        bill.total_money = gio.getTotalPrice();
                        cardt = gio.getCartDetailList();

                        // Nếu thanh toán thành công thì trả về view();
                        int nextIDOrder = addSV.ID_Return("orders");
                        if (addSV.Add_order(
                                Session["utoken"] as string,
                                userorder.id,
                                nextIDOrder,
                                bill.total_money.ToString(),
                                DateTime.Now.ToString(),
                                "COD").
                            Equals("Add success!"))
                        {
                            string message = "Kết quả:";

                            // Thêm chi tiết hoá đơn
                            foreach (var item in cardt)
                            {
                                message += "\n" 
                                    + addSV.Add_order_detail(
                                        Session["utoken"] as string,
                                        userorder.id,
                                        nextIDOrder,
                                        item.ID,
                                        item.Quantity,
                                        item.Price??0);
                            }

                            Session["message"] = message;
                            return View(); // Thanh toán thành công
                        }
                    }
                    catch (Exception e)
                    {
                        Trace.WriteLine(e.Message);
                        return RedirectToAction("Index", "Cart");
                    }
                }
                return RedirectToAction("Index", "Home"); // không thanh toán thành công
            }
            return RedirectToAction("CheckOut", "Cart");
        }
        public ActionResult CheckOut()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Login", "Customer");
            }
            else
            {
                user users = new user();
                users = (user)Session["user"];
                return View(users);
            }
        }
    }
}