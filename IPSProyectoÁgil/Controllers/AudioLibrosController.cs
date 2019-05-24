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
    public class AudiolibrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Audiolibros
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.Audiolibros.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: Audiolibros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiolibros audiolibros = db.Audiolibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((audiolibros.UserId != currentUserId) || audiolibros == null))
            {
                return HttpNotFound();
            }
            return View(audiolibros);
        }

        // GET: Audiolibros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audiolibros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,titulo,autorDoblaje,duracion,ano,tipo,precio")] Audiolibros audiolibros)
        {
            string currentUserId = User.Identity.GetUserId();
            audiolibros.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Audiolibros.Add(audiolibros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(audiolibros);
        }

        // GET: Audiolibros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiolibros audiolibros = db.Audiolibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((audiolibros.UserId != currentUserId) || audiolibros == null))
            {
                return HttpNotFound();
            }
            return View(audiolibros);
        }

        // POST: Audiolibros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,titulo,autorDoblaje,duracion,ano,tipo,precio")] Audiolibros audiolibros)
        {
            string currentUserId = User.Identity.GetUserId();
            audiolibros.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(audiolibros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(audiolibros);
        }

        // GET: Audiolibros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Audiolibros audiolibros = db.Audiolibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((audiolibros.UserId != currentUserId) || audiolibros == null))
            {
                return HttpNotFound();
            }
            return View(audiolibros);
        }

        // POST: Audiolibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Audiolibros audiolibros = db.Audiolibros.Find(id);
            db.Audiolibros.Remove(audiolibros);
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
