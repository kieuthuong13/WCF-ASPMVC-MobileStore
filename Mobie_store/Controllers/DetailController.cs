using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using Mobie_store.Hellper;
using System.Data;
using Mobie_store.ViewService;

namespace Mobie_store.Controllers
{
    public class DetailController : Controller
    {
        private ViewServiceClient db = new ViewServiceClient();
        // GET: Detail
        public ActionResult Index(int id)
        {
            return View(db.Get_product(id).FirstOrDefault());
        }

        ~DetailController()
        {
            db.Close();
        }
    }
}