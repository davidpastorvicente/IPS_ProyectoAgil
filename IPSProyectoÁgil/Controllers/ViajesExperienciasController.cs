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
    public class ViajesExperienciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ViajesExperiencias
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.ViajesExperiencias.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: ViajesExperiencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajesExperiencia viajesExperiencia = db.ViajesExperiencias.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((viajesExperiencia.UserId != currentUserId) || viajesExperiencia == null))
            {
                return HttpNotFound();
            }
            return View(viajesExperiencia);
        }

        // GET: ViajesExperiencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViajesExperiencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,nombre,autores,destino,alojamiento,transporte,lugarInteres,presupuesto,duracionVideo,precio")] ViajesExperiencia viajesExperiencia)
        {
            string currentUserId = User.Identity.GetUserId();
            viajesExperiencia.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.ViajesExperiencias.Add(viajesExperiencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajesExperiencia);
        }

        // GET: ViajesExperiencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajesExperiencia viajesExperiencia = db.ViajesExperiencias.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((viajesExperiencia.UserId != currentUserId) || viajesExperiencia == null))
            {
                return HttpNotFound();
            }
            return View(viajesExperiencia);
        }

        // POST: ViajesExperiencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,nombre,autores,destino,alojamiento,transporte,lugarInteres,presupuesto,duracionVideo,precio")] ViajesExperiencia viajesExperiencia)
        {
            string currentUserId = User.Identity.GetUserId();
            viajesExperiencia.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(viajesExperiencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viajesExperiencia);
        }

        // GET: ViajesExperiencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViajesExperiencia viajesExperiencia = db.ViajesExperiencias.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((viajesExperiencia.UserId != currentUserId) || viajesExperiencia == null))
            {
                return HttpNotFound();
            }
            return View(viajesExperiencia);
        }

        // POST: ViajesExperiencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViajesExperiencia viajesExperiencia = db.ViajesExperiencias.Find(id);
            db.ViajesExperiencias.Remove(viajesExperiencia);
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
