using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Turnos.Models;
using Data;
using Microsoft.EntityFrameworkCore;

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
        ViewBag.Usuario = tipo+"-"+documento;
        return  View(await _context.Categorias.Where(c => c.Estado == "Activa").ToArrayAsync());
    }


    public async Task<IActionResult> Turno(string siglas){

        string seleccion = "";
        string turno = "";
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Siglas == siglas);
        int contador = result.Contador +1;

        turno = siglas+"-"+(contador < 10 ? "00"+contador: "0"+contador);

        ViewBag.Turno = turno;
        return View();
    }

    public async Task<IActionResult> TomarTurno(string turno){

        string siglas = turno.Substring(0,2);
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Siglas == siglas);

        result.Contador = result.Contador+1; 

        _context.Categorias.Update(result);
        await _context.SaveChangesAsync();


        return RedirectToAction("Index");
    }

 

}
