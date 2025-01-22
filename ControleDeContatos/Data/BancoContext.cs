using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
//Entity Framework Core
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools
//Microsoft.EntityFrameworkCore.SqlServer
//cria  PM> o Migration: add-Migration CriandoTabelaContatos -Context BancoContext
//roda PM> Update-Database -Context BancoContext

{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
