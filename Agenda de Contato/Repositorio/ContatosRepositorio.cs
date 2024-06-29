using Agenda_de_Contato.Data;
using Agenda_de_Contato.Models;

namespace Agenda_de_Contato.Repositorio
{
    public class ContatosRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
           _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

    }
}
