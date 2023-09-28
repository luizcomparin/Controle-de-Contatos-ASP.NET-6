using Controle_de_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_Contatos.Data
{
	public class BancoContext : DbContext
	{
		public BancoContext(DbContextOptions<BancoContext> options) : base(options)
		{

		}

		public DbSet<ContatoModel> Contatos { get; set; }
	}
}
