using MvcCalisan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCalisan.Controllers
{
    public class LoginController : Controller
    {
        MvcExampleEntities db = new MvcExampleEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult CheckValidUser(Calisan model)
        {
            string result = "Fail";
            var DataItem = db.Calisans.Where(x => x.calisanEmail == model.calisanEmail && x.calisanKod == model.calisanKod).SingleOrDefault();
            if(DataItem != null)
            {
                Session["UserID"] = DataItem.calisanID.ToString();
                Session["UserCode"] = DataItem.calisanKod.ToString();
                Session["Yetki"] = DataItem.calisanYetkiID.ToString();
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AfterLogin()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        
    }
}