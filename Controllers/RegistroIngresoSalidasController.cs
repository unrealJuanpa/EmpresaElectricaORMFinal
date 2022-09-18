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
    public class RegistroIngresoSalidasController : Controller
    {
        private DbContextEmpresa db = new DbContextEmpresa();

        // GET: RegistroIngresoSalidas
        public ActionResult Index()
        {
            var registroIngresoSalidaes = db.RegistroIngresoSalidaes.Include(r => r.empleado);
            return View(registroIngresoSalidaes.ToList());
        }

        // GET: RegistroIngresoSalidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroIngresoSalida registroIngresoSalida = db.RegistroIngresoSalidaes.Find(id);
            if (registroIngresoSalida == null)
            {
                return HttpNotFound();
            }
            return View(registroIngresoSalida);
        }

        // GET: RegistroIngresoSalidas/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre");
            return View();
        }

        // POST: RegistroIngresoSalidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaHoraIngreso,FechaHoraSalida,EmpleadoId")] RegistroIngresoSalida registroIngresoSalida)
        {
            if (ModelState.IsValid)
            {
                db.RegistroIngresoSalidaes.Add(registroIngresoSalida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroIngresoSalida.EmpleadoId);
            return View(registroIngresoSalida);
        }

        // GET: RegistroIngresoSalidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroIngresoSalida registroIngresoSalida = db.RegistroIngresoSalidaes.Find(id);
            if (registroIngresoSalida == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroIngresoSalida.EmpleadoId);
            return View(registroIngresoSalida);
        }

        // POST: RegistroIngresoSalidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaHoraIngreso,FechaHoraSalida,EmpleadoId")] RegistroIngresoSalida registroIngresoSalida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroIngresoSalida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleadoes, "Id", "Nombre", registroIngresoSalida.EmpleadoId);
            return View(registroIngresoSalida);
        }

        // GET: RegistroIngresoSalidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroIngresoSalida registroIngresoSalida = db.RegistroIngresoSalidaes.Find(id);
            if (registroIngresoSalida == null)
            {
                return HttpNotFound();
            }
            return View(registroIngresoSalida);
        }

        // POST: RegistroIngresoSalidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroIngresoSalida registroIngresoSalida = db.RegistroIngresoSalidaes.Find(id);
            db.RegistroIngresoSalidaes.Remove(registroIngresoSalida);
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
