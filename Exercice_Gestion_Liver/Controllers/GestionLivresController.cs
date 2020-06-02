using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Exercice_Gestion_Liver.Controllers
{
    public class GestionLivresController : Controller
    {
        private GestionLiverEntities db = new GestionLiverEntities();
        // GET: GestionLivres
        public ActionResult Index()
        {
            var ListeLiver = db.Liver.ToList();
            return View(ListeLiver);
        }
        
        public ActionResult CreerLivre()
        {
            
            return View();
        }
        //CreerLivre
        [HttpPost]
        public ActionResult CreerLivre( Liver liver)
        {
            if (ModelState.IsValid)
            {
                db.Liver.Add(liver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //DetailsLivre
        public ActionResult DetailsLivre(int? id)
        {
            Liver liver = db.Liver.Find(id);
            if (liver==null)
            {
                return HttpNotFound();
            }
            return View(liver);
        }


        public ActionResult EditLivre(int? id)
        {
            if (id == null)
            {
                return new  HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liver liver = db.Liver.Find(id);
            if (liver == null)
            {
                return HttpNotFound();
            }
            return View(liver);
        }

        [HttpPost]
        
        public ActionResult Edit(Liver liver)
        {

            if (ModelState.IsValid)
            {
                db.Entry(liver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liver);
        }

        public ActionResult SupprimerLivre(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liver liver = db.Liver.Find(id);
            if (liver == null)
            {
                return HttpNotFound();
            }
            return View(liver);
        }

        [HttpPost,ActionName("SupprimerLivre ")]

        public ActionResult SuppressionConfirmee(int id)
        {

            Liver liver = db.Liver.Find(id);
            db.Liver.Remove(liver);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}