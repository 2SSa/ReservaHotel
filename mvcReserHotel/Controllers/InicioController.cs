using mvcReserHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcReserHotel.Controllers
{
    //Puto el que lo lea
    public class InicioController : Controller
    {
        public static int codigoCliente;
        public static int codigoHab;
        public int cont = 0;
        ctxHotel db = new ctxHotel();
        // GET: Habitaciones
        public ActionResult Index()
        {
            
            var simple = from p in db.habitacion
                         join d in db.estado on p.cod_estado equals d.cod_estado
                         where p.cod_tipo_habitacion == 1
                         select new HabitacionInicio{
                             Numero = p.cod_habitacion,
                             Estado = d.nombre
                         };

            var simpleD = from p in db.habitacion
                          join d in db.estado on p.cod_estado equals d.cod_estado
                          where p.cod_tipo_habitacion == 2
                          select new HabitacionInicio
                          {
                              Numero = p.cod_habitacion,
                              Estado = d.nombre
                          };

            var ejecutivo = from p in db.habitacion
                            join d in db.estado on p.cod_estado equals d.cod_estado
                            where p.cod_tipo_habitacion == 3
                            select new HabitacionInicio
                            {
                                Numero = p.cod_habitacion,
                                Estado = d.nombre
                            };

            var ejecutivoD = from p in db.habitacion
                             join d in db.estado on p.cod_estado equals d.cod_estado
                             where p.cod_tipo_habitacion == 4
                             select new HabitacionInicio
                             {
                                 Numero = p.cod_habitacion,
                                 Estado = d.nombre
                             };

            var suit = from p in db.habitacion
                       join d in db.estado on p.cod_estado equals d.cod_estado
                       where p.cod_tipo_habitacion == 5
                       select new HabitacionInicio
                       {
                           Numero = p.cod_habitacion,
                           Estado = d.nombre
                       };

            var suitP = from p in db.habitacion
                        join d in db.estado on p.cod_estado equals d.cod_estado
                        where p.cod_tipo_habitacion == 6
                        select new HabitacionInicio
                        {
                            Numero = p.cod_habitacion,
                            Estado = d.nombre
                        };

            ViewBag.simple = simple;

            ViewBag.simpleD = simpleD;

            ViewBag.ejecutivo = ejecutivo;

            ViewBag.ejecutivoD = ejecutivoD;

            ViewBag.suit = suit;

            ViewBag.suitP = suitP;

            return View();
        }

        public ActionResult Detalles (int codigoHabitacion)
        {
            codigoHab = codigoHabitacion;
            var habitacion = from p in db.habitacion
                              where codigoHabitacion == p.cod_habitacion
                              select p;
            return View(habitacion.Single());
        }

        public ActionResult Cliente()
        {
            ViewBag.cod_estado_civil = new SelectList(db.estado_civil, "cod_estado_civil", "estado_civil1");
            return View();
        }

        [HttpPost]
        public ActionResult Cliente(cliente cliente)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in db.cliente)
                {
                    if (item.cui == cliente.cui)
                    {
                        break;
                    }
                    else
                    {
                        cont++;
                    }
                }
                if (cont == db.cliente.Count())
                {
                    db.cliente.Add(cliente);
                }
                db.SaveChanges();
                foreach (var item in db.cliente)
                {
                    if (item.cui == cliente.cui)
                    {
                        codigoCliente = item.cod_cliente;
                        break;
                    }
                }
        }
            return RedirectToAction("Reservacion");
        }

        public ActionResult Reservacion()
        {
            var recepcionista = from m in db.recepcionista
                                select new { cod_usuario = m.cod_usuario, nombres = m.nombres + " " + m.apellidos };

            ViewBag.cod_estado = new SelectList(db.estado, "cod_estado", "nombre");
            ViewBag.cod_usuario = new SelectList(recepcionista, "cod_usuario", "nombres");
            return View();
        }

        [HttpPost]
        public ActionResult Reservacion(reservacion reservacion)
        {
            reservacion.cod_cliente = codigoCliente;
            db.reservacion.Add(reservacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}