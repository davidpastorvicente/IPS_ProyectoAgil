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
    public class PeliSeriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PeliSeries
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            var userProducts = db.PeliSeries.Where(p => p.UserId == currentUserId).ToList();
            return View(userProducts);
        }

        // GET: PeliSeries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliSerie peliSerie = db.PeliSeries.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((peliSerie.UserId != currentUserId) || peliSerie == null))
            {
                return HttpNotFound();
            }
            return View(peliSerie);
        }

        // GET: PeliSeries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeliSeries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeliSerieId,Titulo,CanalProductora,Director,Actores,edadRecomendada,PeliOSerie,tipo,anio,precio")] PeliSerie peliSerie)
        {
            string currentUserId = User.Identity.GetUserId();
            peliSerie.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.PeliSeries.Add(peliSerie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peliSerie);
        }

        // GET: PeliSeries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliSerie peliSerie = db.PeliSeries.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((peliSerie.UserId != currentUserId) || peliSerie == null))
            {
                return HttpNotFound();
            }
            return View(peliSerie);
        }

        // POST: PeliSeries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeliSerieId,Titulo,CanalProductora,Director,Actores,edadRecomendada,PeliOSerie,tipo,anio,precio")] PeliSerie peliSerie)
        {
            string currentUserId = User.Identity.GetUserId();
            peliSerie.UserId = currentUserId;
            if (ModelState.IsValid)
            {
                db.Entry(peliSerie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peliSerie);
        }

        // GET: PeliSeries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeliSerie peliSerie = db.PeliSeries.Find(id);
            string currentUserId = User.Identity.GetUserId();
            if (((peliSerie.UserId != currentUserId) || peliSerie == null))
            {
                return HttpNotFound();
            }
            return View(peliSerie);
        }

        // POST: PeliSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeliSerie peliSerie = db.PeliSeries.Find(id);
            db.PeliSeries.Remove(peliSerie);
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
