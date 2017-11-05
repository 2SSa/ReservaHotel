using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcReserHotel.Models;

namespace mvcReserHotel.Controllers
{
    //Este es un comentario
    public class ReservacionController : Controller
    {
        private ctxHotel db = new ctxHotel();

        // GET: Reservacion
        public ActionResult Index()
        {
            var reservacion = db.reservacion.Include(r => r.cliente).Include(r => r.estado).Include(r => r.recepcionista);
            return View(reservacion.ToList());
        }

        // GET: Reservacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            return View(reservacion);
        }

        // GET: Reservacion/Create
        public ActionResult Create()
        {

            var recepcionista = from m in db.recepcionista
                       select new { cod_usuario = m.cod_usuario, nombres = m.nombres + " " + m.apellidos };

            var estado = from p in db.estado
                         where p.cod_estado >= 4
                         select p;


             ViewBag.cod_cliente = new SelectList(db.cliente, "cod_cliente", "nombres");
            ViewBag.cod_estado = new SelectList(db.estado, "cod_estado", "nombre");
            ViewBag.cod_usuario = new SelectList(recepcionista, "cod_usuario", "nombres");
            return View();
        }

        // POST: Reservacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_reservacion,fecha_inicio,fecha_fin,fecha_creacion,observacion,precio,cod_estado,cod_usuario,cod_cliente")] reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                db.reservacion.Add(reservacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_cliente = new SelectList(db.cliente, "cod_cliente", "nombres", reservacion.cod_cliente);
            ViewBag.cod_estado = new SelectList(db.estado, "cod_estado", "nombre", reservacion.cod_estado);
            ViewBag.cod_usuario = new SelectList(db.recepcionista, "cod_usuario", "nombres", reservacion.cod_usuario);
            return View(reservacion);
        }

        // GET: Reservacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_cliente = new SelectList(db.cliente, "cod_cliente", "nombres", reservacion.cod_cliente);
            ViewBag.cod_estado = new SelectList(db.estado, "cod_estado", "nombre", reservacion.cod_estado);
            ViewBag.cod_usuario = new SelectList(db.recepcionista, "cod_usuario", "nombres", reservacion.cod_usuario);
            return View(reservacion);
        }

        // POST: Reservacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_reservacion,fecha_inicio,fecha_fin,fecha_creacion,observacion,precio,cod_estado,cod_usuario,cod_cliente")] reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_cliente = new SelectList(db.cliente, "cod_cliente", "nombres", reservacion.cod_cliente);
            ViewBag.cod_estado = new SelectList(db.estado, "cod_estado", "nombre", reservacion.cod_estado);
            ViewBag.cod_usuario = new SelectList(db.recepcionista, "cod_usuario", "nombres", reservacion.cod_usuario);
            return View(reservacion);
        }

        // GET: Reservacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservacion reservacion = db.reservacion.Find(id);
            if (reservacion == null)
            {
                return HttpNotFound();
            }
            return View(reservacion);
        }

        // POST: Reservacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservacion reservacion = db.reservacion.Find(id);
            db.reservacion.Remove(reservacion);
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


        

        public JsonResult BuscarCliente(string term)
        {
            var Cliente = from m in db.cliente
                          select new { cod_usuario = m.cod_cliente, nombres = m.nombres + " " + m.apellidos };


            var cliente = Cliente.Where(x => x.nombres.Contains(term))
                .Select(x => x.nombres).Take(5).ToList();
                          
            
            

            return Json(cliente, JsonRequestBehavior.AllowGet);
        }
    }
}
