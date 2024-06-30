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
        public IActionResult Editar(int id)
        {
           ContatoModel contato = _IContatoRepositorio.ListarPorId(id);   
            return View(contato);
        }
        public IActionResult ExcluirSpan(int id)
        {
            ContatoModel contato = _IContatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            _IContatoRepositorio.Excluir(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
        _IContatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _IContatoRepositorio.Editar(contato);
            return RedirectToAction("Index");
        }
    }
}
