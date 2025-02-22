using Etkinlik_CodeFirstAndMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etkinlik_CodeFirstAndMVC.Controllers
{
    public class EtkinlikController : Controller
    {
        EtkinlikModel db = new EtkinlikModel();
        // GET: Etkinlik
        public ActionResult Index()
        {
            return View(db.Etkinlikler.ToList());
        }

        [HttpGet]
        public ActionResult EtkinlikOlustur()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EtkinlikOlustur(Etkinlik model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (imageFile != null)
                    {
                        FileInfo fi = new FileInfo(imageFile.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            string isim = Guid.NewGuid().ToString() + fi.Extension;
                            imageFile.SaveAs(Server.MapPath("~/Assets/EtkinlikImages/" + isim));
                            model.Resim = isim;
                        }
                    }
                    else
                    {
                        model.Resim = "noImage.jpg";
                    }
                    try
                    {
                        db.Etkinlikler.Add(model);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        TempData["HataMesaji"] = "Kayıt silinirken bir hata oluştu: " + ex.Message;
                    }
                }
                else
                {
                    TempData["HataMesaji"] = "Silinecek kayıt bulunamadı.";
                }
                
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int? id)
        {
            if (id != null)
            {
                Etkinlik model = db.Etkinlikler.Find(id);
                if (model != null)
                {
                    return View(model);
                }
            }
            return RedirectToAction("Index", "Etkinlik");
        }

        [HttpPost]
        public ActionResult Duzenle(Etkinlik model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    if (imageFile != null)
                    {
                        FileInfo fi = new FileInfo(imageFile.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        {
                            string isim = Guid.NewGuid().ToString() + fi.Extension;
                            imageFile.SaveAs(Server.MapPath("~/Assets/EtkinlikImages/" + isim));
                            model.Resim = isim;
                        }
                    }
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Etkinlik");
        }

       
     
        public ActionResult Sil(int? id)
        {
            if (id != null)
            {
                Etkinlik model = db.Etkinlikler.Find(id);
                if (model != null)
                {
                    db.Etkinlikler.Remove(model);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Etkinlik");
        }
    }
}