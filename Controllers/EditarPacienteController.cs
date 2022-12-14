using Microsoft.AspNetCore.Mvc;

namespace OSpital.Controllers
{
    public class EditarPacienteController : Controller
    {
        public IActionResult EditarPaciente()
        {
            return View();
        }
    }
}
