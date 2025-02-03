using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
//Entity Framework Core
//Microsoft.EntityFrameworkCore.Design
//Microsoft.EntityFrameworkCore.Tools
//Microsoft.EntityFrameworkCore.SqlServer
//cria  PM> o Migration: add-Migration CriandoTabelaContatos -Context BancoContext
//roda PM> Update-Database -Context BancoContext -- use sempre para enviar as alterações para o banco de dados
//roda PM> add-Migration CriandoTabelaUsuarios -Context BancoContext

{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
