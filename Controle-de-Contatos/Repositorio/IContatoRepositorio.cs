using Controle_de_Contatos.Models;

namespace Controle_de_Contatos.Repositorio
{
	public interface IContatoRepositorio
	{
		ContatoModel ListarPorId(int id);

		List<ContatoModel> BuscarTodos();

		ContatoModel Adicionar(ContatoModel contato);

		ContatoModel Atualizar(ContatoModel contato);

		bool Apagar(int id);
	}
}
