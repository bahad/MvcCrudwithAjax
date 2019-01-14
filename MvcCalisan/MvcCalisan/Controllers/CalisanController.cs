using MvcCalisan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCalisan.Controllers
{
    public class CalisanController : Controller
    {
        MvcExampleEntities db = new MvcExampleEntities();
        // GET: Calisan
        public ActionResult Index()
        {
            List<CalisanViewModel> lemp = db.Calisans.Select(x => new CalisanViewModel { calisanIsim = x.calisanIsim,
                calisanAdres = x.calisanAdres, calisanKod= x.calisanKod, calisanID= x.calisanID, calisanEmail=x.calisanEmail,
                calisanMaas = x.calisanMaas, calisanTelefon = x.calisanTelefon, calisanYas = x.calisanYas, DepartmentName = x.Departman.departmanAd,
                PozisyonName = x.Pozisyon.pozisyonAd
                
            }).ToList();
            ViewBag.CalisanList = lemp;
            List<Departman> listd = db.Departmen.ToList();
            List<Pozisyon> listp = db.Pozisyons.ToList();
            ViewBag.DepartmentList = new SelectList(listd, "departmanID", "departmanAd");
            ViewBag.PozisyonList = new SelectList(listp, "pozisyonID", "pozisyonAd");
            return View();
            //return View(db.Calisans.ToList());
        }
        public ActionResult Info(int id)
        {
            List<Calisan> inf = db.Calisans.Where(x => x.calisanID == id).ToList();

            return View(inf);
        }
        public JsonResult DeleteCalisan(int calisanID)
        {
            bool result = false;
            Calisan cls = db.Calisans.SingleOrDefault(x=>x.calisanID==calisanID);

            if (cls != null)
            {
                db.Calisans.Remove(cls);
                db.SaveChanges();
                result = true;
            }
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //GET
        public ActionResult CalisanEkle()
        {          
            List<Departman> listd = db.Departmen.ToList();
            List<Pozisyon> listp = db.Pozisyons.ToList();
            ViewBag.DepartmentList = new SelectList(listd,"departmanID","departmanAd");
            ViewBag.PozisyonList = new SelectList(listp, "pozisyonID", "pozisyonAd");
            if(Session["UserID"] != null )
            { 
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult CalisanEkle(CalisanViewModel Model)
        {
            try
            {
                List<Departman> listd = db.Departmen.ToList();
                List<Pozisyon> listp = db.Pozisyons.ToList();
                ViewBag.DepartmentList = new SelectList(listd, "departmanID", "departmanAd");
                ViewBag.PozisyonList = new SelectList(listp, "pozisyonID", "pozisyonAd");
                Calisan calisan = new Calisan();
                calisan.calisanAdres = Model.calisanAdres;
                calisan.calisanIsim = Model.calisanIsim;
                calisan.calisanEmail = Model.calisanEmail;
                calisan.calisanKod = Model.calisanKod;
                calisan.calisanTelefon = Model.calisanTelefon;
                calisan.calisanYas = Model.calisanYas;
                calisan.departmanID = Model.departmanID;
                calisan.pozisyonID = Model.pozisyonID;
                calisan.calisanYetkiID = Model.calisanYetkiID;
                calisan.calisanMaas = Model.calisanMaas;
                db.Calisans.Add(calisan);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View();
        }
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<CalisanViewModel> calisan = db.Calisans.Select(x => new CalisanViewModel
            {
                calisanIsim = x.calisanIsim,
                calisanAdres = x.calisanAdres,
                calisanKod = x.calisanKod,
                calisanID = x.calisanID,
                calisanEmail = x.calisanEmail,
                calisanMaas = x.calisanMaas,
                calisanTelefon = x.calisanTelefon,
                calisanYas = x.calisanYas,
                DepartmentName = x.Departman.departmanAd,
                PozisyonName = x.Pozisyon.pozisyonAd

            }).ToList();
            if (SearchBy == "ID")
            {
                try
                {
                    int Id = Convert.ToInt32(SearchValue);
                    calisan = db.Calisans.Where(x => x.calisanID == Id || SearchValue == null).Select(x =>
                    new CalisanViewModel {
                        calisanIsim = x.calisanIsim,
                        calisanAdres = x.calisanAdres,
                        calisanKod = x.calisanKod,
                        calisanID = x.calisanID,
                        calisanEmail = x.calisanEmail,
                        calisanMaas = x.calisanMaas,
                        calisanTelefon = x.calisanTelefon,
                        calisanYas = x.calisanYas,
                        DepartmentName = x.Departman.departmanAd,
                        PozisyonName = x.Pozisyon.pozisyonAd
                    }
                    ).ToList();
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not ID", SearchValue);
                }
                return Json(calisan, JsonRequestBehavior.AllowGet);
            }
            else
            {
                calisan = db.Calisans.Where(x => x.calisanIsim.Contains(SearchValue) || SearchValue == null).Select(x => new CalisanViewModel {
                    calisanIsim = x.calisanIsim,
                    calisanAdres = x.calisanAdres,
                    calisanKod = x.calisanKod,
                    calisanID = x.calisanID,
                    calisanEmail = x.calisanEmail,
                    calisanMaas = x.calisanMaas,
                    calisanTelefon = x.calisanTelefon,
                    calisanYas = x.calisanYas,
                    DepartmentName = x.Departman.departmanAd,
                    PozisyonName = x.Pozisyon.pozisyonAd

                }).ToList();
                return Json(calisan, JsonRequestBehavior.AllowGet);
            }
        }
        //Edit Calisan
        public JsonResult GetCalisanById(int calisanID)
        {
            Calisan calisan = db.Calisans.Where(x => x.calisanID == calisanID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(calisan, Formatting.Indented, new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        } 
       /* public ActionResult EditCalisan(int calisanID)
        {
            CalisanViewModel model = new CalisanViewModel();
            Calisan calisan = db.Calisans.SingleOrDefault(x => x.calisanID == calisanID);
            model.calisanID = calisan.calisanID;
            model.calisanIsim = calisan.calisanIsim;
            model.calisanMaas = calisan.calisanMaas;
            model.calisanYas = calisan.calisanYas;
            model.calisanTelefon = calisan.calisanTelefon;
            model.departmanID = calisan.departmanID;
            model.pozisyonID = calisan.pozisyonID;
            model.calisanYetkiID = calisan.calisanYetkiID;
            model.calisanAdres = calisan.calisanAdres;
            model.calisanEmail = calisan.calisanEmail;

            return PartialView("PartialEdit",model);
        } */


    }
}