
using Data;
using Microsoft.AspNetCore.Mvc;


namespace Turnos.Controllers
{
    
    public class AuthController : Controller
    {
       
       public readonly TurnosContext _context;

       public AuthController(TurnosContext context){
        _context = context;
       }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public async Task<IActionResult> Login(string correo, string password){

            return Json(correo+password);
            // var usuarioLoggeado = await  _context.Recepcions.FirstOrDefaultAsync(em => em.correo == identificacion);

            // if(usuarioLoggeado != null && usuarioLoggeado.Password == password){
            //     HttpContext.Session.SetString("Nombre", usuarioLoggeado.Nombres); //crear variable de sesion 
            //     return RedirectToAction("Index", "Empleados");
            // }else{

            //  return RedirectToAction("Index"); //retornar al login
            // }

            return RedirectToAction("Index");

        }

        public IActionResult Logout(){

            return RedirectToAction("Index");
        }
    }
}