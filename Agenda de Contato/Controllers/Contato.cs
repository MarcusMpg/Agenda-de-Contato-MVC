using Microsoft.AspNetCore.Mvc;

namespace Agenda_de_Contato.Controllers
{
    public class Contato : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ExcluirSpan()
        {
            return View();
        }
    }
}
