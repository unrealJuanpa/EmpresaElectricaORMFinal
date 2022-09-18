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
    public class RegistroControlsController : Controller
    {
        private DbContextEmpresa db = new DbContextEmpresa();

        // GET: RegistroControls
        public ActionResult Index()
        {
            var registroControles = db.RegistroControles.Include(r => r.empleado).Include(r => r.tipoControl);
            return View(registroControles.ToList());
        }

        // GET: RegistroControls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroControl registroControl = db.RegistroControles.Find(id);
            if (registroControl == null)
            {
                return HttpNotFound();
            }
            return View(registroControl);
        }

        // GET: RegistroControls/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre");
            ViewBag.TipoControlId = new SelectList(db.TipoControles, "Id", "NombreControl");
            return View();
        }

        // POST: RegistroControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Informacion,EmpleadoId,TipoControlId")] RegistroControl registroControl)
        {
            if (ModelState.IsValid)
            {
                db.RegistroControles.Add(registroControl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroControl.EmpleadoId);
            ViewBag.TipoControlId = new SelectList(db.TipoControles, "Id", "NombreControl", registroControl.TipoControlId);
            return View(registroControl);
        }

        // GET: RegistroControls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroControl registroControl = db.RegistroControles.Find(id);
            if (registroControl == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroControl.EmpleadoId);
            ViewBag.TipoControlId = new SelectList(db.TipoControles, "Id", "NombreControl", registroControl.TipoControlId);
            return View(registroControl);
        }

        // POST: RegistroControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Informacion,EmpleadoId,TipoControlId")] RegistroControl registroControl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroControl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroControl.EmpleadoId);
            ViewBag.TipoControlId = new SelectList(db.TipoControles, "Id", "NombreControl", registroControl.TipoControlId);
            return View(registroControl);
        }

        // GET: RegistroControls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroControl registroControl = db.RegistroControles.Find(id);
            if (registroControl == null)
            {
                return HttpNotFound();
            }
            return View(registroControl);
        }

        // POST: RegistroControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroControl registroControl = db.RegistroControles.Find(id);
            db.RegistroControles.Remove(registroControl);
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
