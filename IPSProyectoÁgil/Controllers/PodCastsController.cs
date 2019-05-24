using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IPSProyectoÁgil.Models;
using Microsoft.AspNet.Identity;

namespace IPSProyectoÁgil.Controllers
{
    [Authorize]
    public class PodCastsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PodCasts
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.PodCasts.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: PodCasts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PodCasts podCasts = db.PodCasts.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((podCasts.UserId != currentUserId) || podCasts == null))
            {
                return HttpNotFound();
            }
            return View(podCasts);
        }

        // GET: PodCasts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PodCasts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,emisora,programa,participantes,duracion,fecha,tematica,precio")] PodCasts podCasts)
        {
            string currentUserId = User.Identity.GetUserId();
            podCasts.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.PodCasts.Add(podCasts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podCasts);
        }

        // GET: PodCasts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PodCasts podCasts = db.PodCasts.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((podCasts.UserId != currentUserId) || podCasts == null))
            {
                return HttpNotFound();
            }
            return View(podCasts);
        }

        // POST: PodCasts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,emisora,programa,participantes,duracion,fecha,tematica,precio")] PodCasts podCasts)
        {
            string currentUserId = User.Identity.GetUserId();
            podCasts.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(podCasts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podCasts);
        }

        // GET: PodCasts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PodCasts podCasts = db.PodCasts.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((podCasts.UserId != currentUserId) || podCasts == null))
            {
                return HttpNotFound();
            }
            return View(podCasts);
        }

        // POST: PodCasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PodCasts podCasts = db.PodCasts.Find(id);
            db.PodCasts.Remove(podCasts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
