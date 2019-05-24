using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IPSProyectoÁgil.Models;

namespace IPSProyectoÁgil.Controllers
{
    public class OpinionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Opiniones
        public ActionResult Index()
        {
            return View(db.Opiniones.ToList());
        }

        // GET: Opiniones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiniones opiniones = db.Opiniones.Find(id);
            if (opiniones == null)
            {
                return HttpNotFound();
            }
            return View(opiniones);
        }

        // GET: Opiniones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opiniones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,nombre_ocio,tipo_ocio,voto")] Opiniones opiniones)
        {
            if (ModelState.IsValid)
            {
                db.Opiniones.Add(opiniones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opiniones);
        }

        // GET: Opiniones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiniones opiniones = db.Opiniones.Find(id);
            if (opiniones == null)
            {
                return HttpNotFound();
            }
            return View(opiniones);
        }

        // POST: Opiniones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,nombre_ocio,tipo_ocio,voto")] Opiniones opiniones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opiniones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opiniones);
        }

        // GET: Opiniones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiniones opiniones = db.Opiniones.Find(id);
            if (opiniones == null)
            {
                return HttpNotFound();
            }
            return View(opiniones);
        }

        // POST: Opiniones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opiniones opiniones = db.Opiniones.Find(id);
            db.Opiniones.Remove(opiniones);
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
