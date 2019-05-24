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
    public class RevistasLibrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RevistasLibros
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.RevistasLibros.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: RevistasLibros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevistasLibros revistasLibros = db.RevistasLibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((revistasLibros.UserId != currentUserId) || revistasLibros == null))
            {
                return HttpNotFound();
            }
            return View(revistasLibros);
        }

        // GET: RevistasLibros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevistasLibros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identificador,titulo,autor,numPaginas,anio,revista_libro,tipo,precio")] RevistasLibros revistasLibros)
        {
            string currentUserId = User.Identity.GetUserId();
            revistasLibros.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.RevistasLibros.Add(revistasLibros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(revistasLibros);
        }

        // GET: RevistasLibros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevistasLibros revistasLibros = db.RevistasLibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((revistasLibros.UserId != currentUserId) || revistasLibros == null))
            {
                return HttpNotFound();
            }
            return View(revistasLibros);
        }

        // POST: RevistasLibros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identificador,titulo,autor,numPaginas,anio,revista_libro,tipo,precio")] RevistasLibros revistasLibros)
        {
            string currentUserId = User.Identity.GetUserId();
            revistasLibros.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(revistasLibros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revistasLibros);
        }

        // GET: RevistasLibros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevistasLibros revistasLibros = db.RevistasLibros.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((revistasLibros.UserId != currentUserId) || revistasLibros == null))
            {
                return HttpNotFound();
            }
            return View(revistasLibros);
        }

        // POST: RevistasLibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RevistasLibros revistasLibros = db.RevistasLibros.Find(id);
            db.RevistasLibros.Remove(revistasLibros);
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
