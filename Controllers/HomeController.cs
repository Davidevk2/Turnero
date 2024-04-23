using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Turnos.Models;

namespace Turnos.Controllers;

public class HomeController : Controller
{
   
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Ingreso(){
        return View(); 
    }

    public IActionResult Categorias(string documento, string tipo){
        ViewBag.Usuario = tipo+"-"+documento;
        return  View();
    }


    public IActionResult Turno(string categoria){

        int countSC = 00;
        int countPF = 00;
        int countAM = 00;
        int countIG = 00;
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
