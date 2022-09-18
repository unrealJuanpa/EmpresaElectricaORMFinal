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
    public class AsignarTareasController : Controller
    {
        private DbContextEmpresa db = new DbContextEmpresa();

        // GET: AsignarTareas
        public ActionResult Index()
        {
            var asignarTareaes = db.AsignarTareaes.Include(a => a.empleado);
            return View(asignarTareaes.ToList());
        }

        // GET: AsignarTareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarTarea asignarTarea = db.AsignarTareaes.Find(id);
            if (asignarTarea == null)
            {
                return HttpNotFound();
            }
            return View(asignarTarea);
        }

        // GET: AsignarTareas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre");
            return View();
        }

        // POST: AsignarTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTarea,Fecha,EmpleadoId")] AsignarTarea asignarTarea)
        {
            if (ModelState.IsValid)
            {
                db.AsignarTareaes.Add(asignarTarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", asignarTarea.EmpleadoId);
            return View(asignarTarea);
        }

        // GET: AsignarTareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarTarea asignarTarea = db.AsignarTareaes.Find(id);
            if (asignarTarea == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", asignarTarea.EmpleadoId);
            return View(asignarTarea);
        }

        // POST: AsignarTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTarea,Fecha,EmpleadoId")] AsignarTarea asignarTarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignarTarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", asignarTarea.EmpleadoId);
            return View(asignarTarea);
        }

        // GET: AsignarTareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignarTarea asignarTarea = db.AsignarTareaes.Find(id);
            if (asignarTarea == null)
            {
                return HttpNotFound();
            }
            return View(asignarTarea);
        }

        // POST: AsignarTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignarTarea asignarTarea = db.AsignarTareaes.Find(id);
            db.AsignarTareaes.Remove(asignarTarea);
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
