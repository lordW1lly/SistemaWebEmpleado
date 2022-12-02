using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleado.Data;
using System.Linq;
using System.Collections.Generic;
using SistemaWebEmpleado.Models;

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
    } 

}
