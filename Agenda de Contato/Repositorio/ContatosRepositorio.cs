using Agenda_de_Contato.Controllers;
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
        public ContatoModel ListarPorId(int id) => _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
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

        public ContatoModel Editar(ContatoModel contato)
        {
           ContatoModel contatoDB = ListarPorId(contato.Id);
            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Numero = contato.Numero;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Excluir(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);
            if (contatoDB == null) throw new Exception("Houve um erro na exclução do contato");
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
