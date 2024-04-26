using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Turnos.Controllers;

public class HomeController : Controller
{
    public readonly TurnosContext _context;

    public HomeController(TurnosContext context){
        _context = context;
    }
   

    public IActionResult Index(){
        return View(); 
    }

    public async Task<IActionResult> Categorias(string documento, string tipo){
        HttpContext.Session.SetString("Usuario",tipo+"-"+documento );

        ViewBag.Usuario = HttpContext.Session.GetString("Usuario");

        return  View(await _context.Categorias.Where(c => c.Estado == "Activa").ToArrayAsync());
    }


    public async Task<IActionResult> Turno(string siglas){

        ViewBag.Usuario = HttpContext.Session.GetString("Usuario");


        string ficho = "";
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Siglas == siglas);
        int contador = result.Contador +1;

        ficho = siglas+"-"+(contador < 10 ? "00"+contador: "0"+contador);

        ViewBag.Ficho = ficho;
        return View();
    }

    public async Task<IActionResult> TomarTurno(string ficho){

        string? usuario = HttpContext.Session.GetString("Usuario");
        string tipod = usuario.Substring(0,2);
        string documento = usuario.Substring(3);

        string siglas = ficho.Substring(0,2);
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Siglas == siglas);

        result.Contador = result.Contador+1; 

        _context.Categorias.Update(result);
        await _context.SaveChangesAsync();

        var turnoIn = new Turno{
            Categoria = result.Nombre,
            TipoDocumento = tipod,
            Identificacion = documento,
            Ficho = ficho,
            FechaEntrada = DateTime.Now,
            Estado = "Pendiente"

        };

        _context.Turnos.Add(turnoIn);
        await _context.SaveChangesAsync();


        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Turnos(){

        var resultTurnos = await _context.Turnos.ToListAsync();

        ViewBag.TAtencion = resultTurnos.Where(e=> e.Estado == "Atendiendo").Take(6); 

        return View();
    }

 

}
