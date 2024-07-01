using Agenda_de_Contato.Models;
using Agenda_de_Contato.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            try
            {
                bool excluido = _IContatoRepositorio.Excluir(id);

                if (excluido)
                {
                    TempData["MensagemSucesso"] = "Apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, Não foi possivel Apagar seu contato!, Tente novamente!";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel cadastrar seu contato!, Tente novamente, Detalhe do erro :{erro.Message}";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IContatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel cadastrar seu contato!, Tente novamente, Detalhe do erro :{erro.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _IContatoRepositorio.Editar(contato);
                    TempData["MensagemSucesso"] = "Editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, Não foi possivel editado seu contato!, Tente novamente, Detalhe do erro :{erro.Message}";
                return RedirectToAction("Index");

            }

        }
    }
}
