using Controle_de_Contatos.Models;
using Controle_de_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Controle_de_Contatos.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuarioRepositorio _usuarioRepositorio;

		public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
		{
			_usuarioRepositorio = usuarioRepositorio;
		}

		public IActionResult Index()
		{
			List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
			return View(usuarios);
		}

		public IActionResult Criar()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Criar(UsuarioModel usuario)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_usuarioRepositorio.Adicionar(usuario);
					TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
					return RedirectToAction("Index");
				}

				return View(usuario);
			}
			catch (Exception error)
			{
				TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario. Por favor, tente novamente. Detalhes do erro: {error.Message}";
				return RedirectToAction("Index");
			}
		}
	}
}
