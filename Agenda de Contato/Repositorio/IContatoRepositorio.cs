using Agenda_de_Contato.Models;

namespace Agenda_de_Contato.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar (ContatoModel contato);
    }
}
