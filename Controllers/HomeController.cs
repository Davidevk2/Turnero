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
        return  View(await _context.Categorias.ToListAsync());
    }


    public IActionResult Turno(string categoria){

        int? countSC = HttpContext.Session.GetInt32("countSC");
        int? countPF = HttpContext.Session.GetInt32("countPF");
        int? countAM = HttpContext.Session.GetInt32("countAM");
        int? countIG = HttpContext.Session.GetInt32("countIG");

        string seleccion = "";
        string turno = "";

        switch (categoria)
        {
            case "SC":
                seleccion = "SC";
                countSC++;
                turno = seleccion+"-"+(countSC < 10 ? "0"+countSC: countSC);
                break;
            case "PF":
                seleccion = "PF";
                countPF++;
                turno = seleccion+"-"+(countPF < 10 ? "0"+countPF: countPF);
                
                break;
            case "AM":
                seleccion = "AM";
                countAM++;
                turno = seleccion+"-"+(countAM < 10 ? "0"+countAM: countAM);
                
                break;
            case "IG":
                seleccion = "IG";
                countIG++;
                turno = seleccion+"-"+(countIG < 10 ? "0"+countIG: countIG);
                
                break;
            
            default:
            seleccion = "IG";
                countIG++;
                turno = seleccion+"-"+(countIG < 10 ? "0"+countIG: countIG);
                break;
        }

        ViewBag.Turno = turno;
        return View();
    }

 

}
