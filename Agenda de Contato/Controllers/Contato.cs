using Agenda_de_Contato.Models;
using Agenda_de_Contato.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_de_Contato.Controllers
{
    
    public class Contato : Controller
    {
        private readonly IContatoRepositorio _IContatoRepositorio;
        public Contato(IContatoRepositorio contatoRepositorio)
        {
            _IContatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
           List<ContatoModel> contatos = _IContatoRepositorio.BuscarTodos();
            return View(contatos);
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
        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
        _IContatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
