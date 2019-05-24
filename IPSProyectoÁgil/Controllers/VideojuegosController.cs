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
    public class VideojuegosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Videojuegos
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.Videojuegos.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: Videojuegos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((videojuegos.UserId != currentUserId) || videojuegos == null))
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // GET: Videojuegos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videojuegos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "identificador,nombre,creador,edad,tipo,precio")] Videojuegos videojuegos)
        {
            string currentUserId = User.Identity.GetUserId();
            videojuegos.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Videojuegos.Add(videojuegos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videojuegos);
        }

        // GET: Videojuegos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((videojuegos.UserId != currentUserId) || videojuegos == null))
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // POST: Videojuegos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "identificador,nombre,creador,edad,tipo,precio")] Videojuegos videojuegos)
        {
            string currentUserId = User.Identity.GetUserId();
            videojuegos.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(videojuegos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videojuegos);
        }

        // GET: Videojuegos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((videojuegos.UserId != currentUserId) || videojuegos == null))
            {
                return HttpNotFound();
            }
            return View(videojuegos);
        }

        // POST: Videojuegos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Videojuegos videojuegos = db.Videojuegos.Find(id);
            db.Videojuegos.Remove(videojuegos);
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
