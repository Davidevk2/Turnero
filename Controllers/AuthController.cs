
using BCrypt.Net;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Turnos.Controllers
{
    
    public class AuthController : Controller
    {
       
       public readonly TurnosContext _context;

       public AuthController(TurnosContext context){
        _context = context;
       }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string correo, string password){

            //return Json(correo+password);
            var user = await  _context.Usuarios.FirstOrDefaultAsync(em => em.Correo == correo);

            if(user!= null){
                if(BCrypt.Net.BCrypt.Verify(password, user.Password)){
                    HttpContext.Session.SetString("Nombre", user.Nombre); //crear variable de sesion 
                    HttpContext.Session.SetString("Id", user.Id.ToString()); //crear variable de sesion 

                    return RedirectToAction("Index", "Reception");

                }else{
                    ViewBag.Error = "Correo y/o contraseña incorrectos";
                    return View();

                }

            }else{
                    ViewBag.Error = "Correo y/o contraseña incorrectos";
                    return View();
               
            }

            


        }

        public IActionResult Logout(){

            return RedirectToAction("Index");
        }
    }
}