using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Turnos.Models;

namespace Turnero.Controllers
{
   
    public class ReceptionController : Controller
    {
        private readonly TurnosContext _context;

        public ReceptionController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Login = HttpContext.Session.GetString("Nombre");

            ViewBag.Modelos = await _context.Modulos.ToListAsync();
            var result  = await _context.Turnos.ToListAsync();

            ViewBag.Total = result.Where(e=> e.Estado.Equals("En Espera"));
            // ViewBag.Categorias = result.Where(e => e.Estado == "En Espera").Select(c => new {c.Categoria}).GroupBy(e=> e.Categoria).Count();
            ViewBag.Categorias = result.Where(t => t.Estado.Equals("Pendiente"))
                                        .GroupBy(t => t.Categoria)
                                        .Select(g => new { Categoria = g.Key, Total = g.Count() })
                                        .ToList();
            
            return View();
        }


        public async Task<IActionResult> Create(Recepcion usuario){

            Recepcion newUser = new Recepcion{
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password),//Encryptar la contraseña
                FechaRegistro = DateTime.Now
            }; 

            /* return Json(newUser); */

            await _context.Usuarios.AddAsync(newUser);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

           public IActionResult Turnos()
        {
            ViewBag.Login = HttpContext.Session.GetString("Nombre");
            return View();
        }

          public async Task<IActionResult> Atencion()
        {
            ViewBag.Login = HttpContext.Session.GetString("Nombre");
            
            return View(await _context.Turnos.Where(t => t.Estado.Equals("En Espera")).ToListAsync());
        }


        public async Task<IActionResult>Modulos()
        {
            ViewBag.Login = HttpContext.Session.GetString("Nombre");
            
            return View(await _context.Modulos.ToListAsync());
        }

        
    }
}