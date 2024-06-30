using Agenda_de_Contato.Models;

namespace Agenda_de_Contato.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId(int id);

        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar (ContatoModel contato);
        ContatoModel Editar (ContatoModel contato);

        bool Excluir(int id);
    }
}
