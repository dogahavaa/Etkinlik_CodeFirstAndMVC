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
            return View();
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
                    model.Resim = "noImage";
                }
                db.Etkinlikler.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}