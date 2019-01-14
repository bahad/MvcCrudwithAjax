using MvcCalisan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCalisan.Controllers
{
    public class DepartmanController : Controller
    {
        MvcExampleEntities db = new MvcExampleEntities();
        // GET: Departman
        public ActionResult Index(int departmanID)
        {
            List<Departman> listd = db.Departmen.ToList(); 
            return View(db.Departmen.ToList());
        }
        //UPDATE
        public JsonResult DeleteDepartman(int departmanID)
        {
            bool result = false;
            Departman dp = db.Departmen.SingleOrDefault(x => x.departmanID == departmanID);

            if (dp != null)
            {
                db.Departmen.Remove(dp);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDepartman()
        {
            List<Departman> StuList = db.Departmen.ToList();
            return Json(StuList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDepartmanById(int departmanID)
        {
            Departman departman = db.Departmen.Where(x => x.departmanID == departmanID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(departman, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
    }
}