using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using System.Linq;
using System.Collections.Generic;
using SistemaWebEmpleado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaWebEmpleado.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly EmpleadoContext _context;
        public EmpleadoController(EmpleadoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.empleados.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            Empleado empleado = new Empleado();
            return View("Create", empleado);
        }
        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", empleado);
            }
            else
            {
                _context.empleados.Add(empleado);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet("/empleado/ListaPorTitulo/{titulo}")]
       
        public IActionResult ListaPorTitulo(string titulo)
        {
            List<Empleado> lista = (from p in _context.empleados
                                    where p.Titulo == titulo
                                    select p).ToList();
            return View("Index", lista);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Empleado empleado = _context.empleados.Find(id);

            return View("Edit", empleado);

        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {

            if (ModelState.IsValid)
            {

                _context.Entry(empleado).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Empleado empleado = _context.empleados.Find(id);

            return View("Delete", empleado);
        }

        //GET: /Turno/Delete/id
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = _context.empleados.Find(id);
            if (empleado != null)
            {
                _context.empleados.Remove(empleado);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    } 

}
