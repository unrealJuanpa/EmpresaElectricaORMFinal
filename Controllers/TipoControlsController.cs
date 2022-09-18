using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpresaElectricaORMFinal.Models;

namespace EmpresaElectricaORMFinal.Controllers
{
    public class TipoControlsController : Controller
    {
        private DbContextEmpresa db = new DbContextEmpresa();

        // GET: TipoControls
        public ActionResult Index()
        {
            return View(db.TipoControles.ToList());
        }

        // GET: TipoControls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoControl tipoControl = db.TipoControles.Find(id);
            if (tipoControl == null)
            {
                return HttpNotFound();
            }
            return View(tipoControl);
        }

        // GET: TipoControls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreControl")] TipoControl tipoControl)
        {
            if (ModelState.IsValid)
            {
                db.TipoControles.Add(tipoControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoControl);
        }

        // GET: TipoControls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoControl tipoControl = db.TipoControles.Find(id);
            if (tipoControl == null)
            {
                return HttpNotFound();
            }
            return View(tipoControl);
        }

        // POST: TipoControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreControl")] TipoControl tipoControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoControl);
        }

        // GET: TipoControls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoControl tipoControl = db.TipoControles.Find(id);
            if (tipoControl == null)
            {
                return HttpNotFound();
            }
            return View(tipoControl);
        }

        // POST: TipoControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoControl tipoControl = db.TipoControles.Find(id);
            db.TipoControles.Remove(tipoControl);
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
