using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OSpital.Models;



namespace OSpital.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly SignInManager<Persona> _signInManager;
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }

       public async Task<IActionResult> cerrarSesion()
        {
                
            HttpContext.Session.SetString("LogOut", "true");
            HttpContext.Session.SetString("User", "notUser");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login loginModel)
        {
            if(loginModel.Email != null && loginModel.Password != null)
            {
                Administrativo administrativo = new Administrativo
                {
                    Email = "mail@hotmail.com",
                    Password = "1",
                    Dni = 123456789,
                    Name = "Julio"
                };
                if (loginModel.Email.Equals(administrativo.Email) && loginModel.Password.Equals(administrativo.Password))
                {
                    HttpContext.Session.SetString("User", loginModel.Email);
                    HttpContext.Session.SetString("LogOut", "false");
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(String.Empty, "credenciales invalidas");
            }
            return RedirectToAction("Login");
        }
    }
}
