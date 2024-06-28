using Agenda_de_Contato.Models;
using Microsoft.EntityFrameworkCore;

namespace Agenda_de_Contato.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options): base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
